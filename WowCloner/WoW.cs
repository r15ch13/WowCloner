/*
 * Copyright 2012 Richard 'r15ch13' Kuhnt
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace wowcloner
{
    public class WoW
    {

        // Fehlerliste
        List<Exception> errors = new List<Exception>();
        // Quell-WoW-Ordner
        private string source = "";
        // Ziel-WoW-Ordner
        private string target = "";
        // WoW-Ordner Prefix
        private string prefix = "WoW_";

        // Funktion aus der Windows API um symbolische Links zu erstellen
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        static extern bool CreateSymbolicLink(string symlink, string source, UInt32 Flags);


        public WoW(string source)
        {
            try
            {

                if (source.Trim() != "")
                {
                    // Bei Sonderzeichen gibt es einen Fehler
                    this.source = Path.GetFullPath(source);
                }
                else
                {
                    throw new MyException("Quellpfad darf nicht leer sein!");
                }
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        private void CreateFileSymLink(string sourcefile, string symlink)
        {
            try
            {
                if (File.Exists(symlink)) File.Delete(symlink);
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }

            bool success = WoW.CreateSymbolicLink(symlink, sourcefile, 0x0);
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
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }

            bool success = WoW.CreateSymbolicLink(symlink, sourcedir, 0x1);
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
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
        }

        private void CopyMultibleFiles(string soruce, string wildcard, string target)
        {
            foreach (string file in Directory.GetFiles(source, wildcard, SearchOption.TopDirectoryOnly))
            {
                if (!Path.GetFileName(file).Contains("tools-patch") &&
                    !Path.GetFileName(file).Contains("tools-downloader") &&
                    Path.GetFileName(file) != Path.GetFileName(Application.ExecutablePath))
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
            this.CopyMultibleFiles(this.source, "*.exe", this.target);
            this.CopyMultibleFiles(this.source, "*.mfil", this.target);
            this.CopyMultibleFiles(this.source, "*.tfil", this.target);
            this.CopyMultibleFiles(this.source, "*.dll", this.target);
            this.CopyMultibleFiles(this.source, "*.manifest", this.target);
            this.CopyMultibleFiles(this.source, "*.wtf", this.target);
        }

        public void Create(string name)
        {
            try
            {

                if (name.Trim() != "")
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
                        throw new MyException("Es existiert bereits eine WoW-Kopie mit diesem Namen!");
                    }
                }
                else
                {
                    throw new MyException("Der Name der neuen WoW-Kopie darf nicht leer sein!");
                }
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        public void Delete(string name)
        {
            try
            {
                if (name.Trim() != "")
                {
                    bool hasSubDirs = false;
                    try
                    {
                        Directory.Delete(Path.Combine(this.source, this.prefix + name), true);
                    }
                    catch (Exception ex)
                    {
                        hasSubDirs = true;
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
                    catch (Exception ex)
                    {
                        this.errors.Add(ex); // Fehler sammeln
                    }
                }
                else
                {
                    throw new MyException("Der Name der neuen WoW-Kopie darf nicht leer sein!");
                }
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
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
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            
        }


        public void UpdateAll()
        {
            foreach (string folder in this.GetFolders())
            {
                this.Update(folder);
            }
        }

        public void Update(string name)
        {
            try
            {

                if (name.Trim() != "")
                {
                    // Pfad des Zielordners erstellen
                    this.target = Path.Combine(this.source, this.prefix + name);

                    // Bei Sonderzeichen einen Fehler werfen
                    this.target = Path.GetFullPath(this.target);
                    this.CopyCat();
                }
                else
                {
                    throw new MyException("Der Name der neuen WoW-Kopie darf nicht leer sein!");
                }
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            if (errors.Count > 0) throw new AggregateException(this.errors); // Fehlerlist werfen
        }

        public List<string> GetFolders()
        {
            List<string> folders = new List<string>();
            try
            {
                foreach (string folder in Directory.GetDirectories(this.source, this.prefix + "*"))
                {
                    folders.Add(Path.GetFileName(folder.Replace(this.prefix, "")));
                }
            }
            catch (Exception ex)
            {
                this.errors.Add(ex); // Fehler sammeln
            }
            return folders;
        }
    }
}
