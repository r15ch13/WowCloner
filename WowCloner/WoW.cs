/*
 * Licensed under the MIT License (http://r15ch13.mit-license.org/)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security;
using System.Collections.ObjectModel;

[assembly: CLSCompliant(true)]

namespace Wowcloner
{
    public class Wow
    {

        // Fehlerliste
        List<Exception> errors = new List<Exception>();
        // Quell-WoW-Ordner
        private string source = "";
        // Ziel-WoW-Ordner
        private string target = "";
        // WoW-Ordner Prefix
        private string prefix = "WoW_";

        internal static class NativeMethods
        {
            // Funktion aus der Windows API um symbolische Links zu erstellen
            [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            [return: MarshalAs(UnmanagedType.I1)]
            internal static extern bool CreateSymbolicLink(string symlink, string source, UInt32 Flags);
        }

        public Wow(string source)
        {
            if (!String.IsNullOrEmpty(source.Trim()))
            {
                // Bei Sonderzeichen gibt es einen Fehler
                this.source = Path.GetFullPath(source);
            }
            else
            {
                this.errors.Add(new MyException(Wowcloner.Properties.Resources.Sourcepath_should_not_be_empty));
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }


        private void CreateFileSymLink(string sourcefile, string symlink)
        {
            try
            {
                if (File.Exists(symlink)) File.Delete(symlink);
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }

            bool success = Wow.NativeMethods.CreateSymbolicLink(symlink, sourcefile, 0x0);
            if (success == false)
            {
                this.errors.Add(new Win32Exception(Marshal.GetLastWin32Error()));
            }
        }

        private void CreateDirectorySymLink(string sourcedir, string symlink)
        {
            try
            {
                if (Directory.Exists(symlink)) Directory.Delete(symlink);
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }

            bool success = Wow.NativeMethods.CreateSymbolicLink(symlink, sourcedir, 0x1);
            if (success == false)
            {
                this.errors.Add(new Win32Exception(Marshal.GetLastWin32Error())); // Fehler sammeln
            }
        }

        private void CopyFile(string sourcefile, string targetfolder)
        {
            try
            {
                if (File.Exists(sourcefile))
                {
                    string filename = Path.GetFileName(sourcefile);
                    File.Copy(sourcefile, Path.Combine(targetfolder, filename), true);
                }
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }
        }

        private void CopyMultibleFiles(string source, string wildcard, string target)
        {
            foreach (string file in Directory.GetFiles(source, wildcard, SearchOption.TopDirectoryOnly))
            {
                if (!Path.GetFileName(file).Contains("tools-patch") &&
                    !Path.GetFileName(file).Contains("tools-downloader") &&
                    Path.GetFileName(file).ToLower() != Path.GetFileName(Application.ExecutablePath).ToLower())
                {
                    this.CopyFile(file, target);
                }
            }
        }

        private void CopyCat()
        {
            Directory.CreateDirectory(Path.Combine(this.target, "Interface", "AddOns"));
            Directory.CreateDirectory(Path.Combine(this.target, "WTF", "Account"));

            this.CreateDirectorySymLink(Path.Combine(this.source, "Data"), Path.Combine(this.target, "Data"));
            this.CreateDirectorySymLink(Path.Combine(this.source, "Updates"), Path.Combine(this.target, "Updates"));

            this.CopyFile(Path.Combine(this.source, "WTF", "config.wtf"), Path.Combine(this.target, "WTF"));
            this.CopyFile(Path.Combine(this.source, "realmlist.wtf"), this.target);
            this.CopyMultibleFiles(this.source, "*.*", this.target);
        }

        public void Create(string name)
        {
            try
            {

                if (!String.IsNullOrEmpty(name.Trim()))
                {
                    // Pfad des Zielordners erstellen
                    this.target = Path.Combine(this.source, this.prefix + name);

                    // Bei Sonderzeichen einen Fehler werfen
                    this.target = Path.GetFullPath(this.target);

                    if (!Directory.Exists(this.target))
                    {
                        this.CopyCat();
                    }
                    else
                    {
                        this.errors.Add(new MyException(Wowcloner.Properties.Resources.A_WoW_Copy_with_this_name_alre));
                    }
                }
                else
                {
                    this.errors.Add(new MyException(Wowcloner.Properties.Resources.Please_enter_a_name_for_the_Wo));
                }
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        public void Delete(string name)
        {
            if (!String.IsNullOrEmpty(name.Trim()))
            {
                bool hasSubDirs = false;
                try
                {
                    Directory.Delete(Path.Combine(this.source, this.prefix + name), true);
                }
                catch (IOException)
                {
                    hasSubDirs = true;
                }
                catch (UnauthorizedAccessException)
                {
                    hasSubDirs = true;
                }
                catch (Exception)
                {
                    hasSubDirs = true;
                    throw;
                }

                try
                {
                    if (hasSubDirs)
                    {
                        DirectoryInfo dir = new DirectoryInfo(Path.Combine(this.source, this.prefix + name));
                        DeleteRecursive(dir);
                        Delete(name);
                    }
                }
                catch (IOException ex)
                {
                    this.errors.Add(ex); // Fehler sammeln
                }
                catch (SecurityException ex)
                {
                    this.errors.Add(ex); // Fehler sammeln
                }
                catch (UnauthorizedAccessException ex)
                {
                    this.errors.Add(ex); // Fehler sammeln
                }
                catch (Exception ex)
                {
                    this.errors.Add(ex); // Fehler sammeln
                    throw;
                }
            }
            else
            {
                this.errors.Add(new MyException(Wowcloner.Properties.Resources.Please_enter_a_name_for_the_Wo));
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        public void DeleteRecursive(DirectoryInfo dir)
        {
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo fi in files)
                {
                    File.SetAttributes(fi.FullName, FileAttributes.Normal);
                    fi.Delete();
                }

                DirectoryInfo[] subdirs = dir.GetDirectories();
                foreach (DirectoryInfo di in subdirs)
                {
                    DeleteRecursive(di);
                }
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }
        }


        public void UpdateAll()
        {
            foreach (string folder in this.Folders)
            {
                this.Update(folder);
            }
        }

        public void Update(string name)
        {
            try
            {

                if (!String.IsNullOrEmpty(name.Trim()))
                {
                    // Pfad des Zielordners erstellen
                    this.target = Path.Combine(this.source, this.prefix + name);

                    // Bei Sonderzeichen einen Fehler werfen
                    this.target = Path.GetFullPath(this.target);
                    this.CopyCat();
                }
                else
                {
                    this.errors.Add(new MyException(Wowcloner.Properties.Resources.Please_enter_a_name_for_the_Wo));
                }
            }
            catch (IOException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (SecurityException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (UnauthorizedAccessException ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
                throw;
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        public ReadOnlyCollection<string> Folders
        {
            get
            {
                ReadOnlyCollection<string> folders = null;
                try
                {
                    List<string> tmp = new List<string>();
                    foreach (string folder in Directory.GetDirectories(this.source, this.prefix + "*"))
                    {
                        tmp.Add(Path.GetFileName(folder.Replace(this.prefix, "")));
                    }
                    folders = new ReadOnlyCollection<string>(tmp);
                }
                catch (Exception ex)
                {
                    this.errors.Add(ex); // Fehler sammeln
                    throw;
                }
                return folders;
            }
        }
    }
}
