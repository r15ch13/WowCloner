/*
 * Licensed under the MIT License (http://r15ch13.mit-license.org/)
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Linq;

namespace WowCloner
{
    public partial class MainForm : Form
    {
        private List<string> log = new List<string>();
        private int mouse_x = 0;
        private int mouse_y = 0;
        private bool move = false;

        public MainForm()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureInfo.InstalledUICulture.TwoLetterISOLanguageName);
            InitializeComponent();

            this.logBindingSource.DataSource = this.log;

            this.textBoxSource.Text = Properties.Settings.Default.wowsource;

            this.LoadWowFolders();
            try
            {
                this.labelTitle.Text = String.Format(CultureInfo.CurrentCulture, "World of Warcraft Cloner - {0}", GetProductVersion);
            }
            catch (FileNotFoundException) { }
            catch (NullReferenceException) { }
        }

        public static string GetProductVersion
        {
            get
            {
                var attribute = (AssemblyFileVersionAttribute)Assembly
                .GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyFileVersionAttribute), true)
                .Single();
                return attribute.Version;
            }
        }

        private void LoadWowFolders()
        {
            this.listViewWowCopies.Items.Clear();
            try
            {
                Wow wow = new Wow(Properties.Settings.Default.wowsource);
                ReadOnlyCollection<string> folders = wow.Folders;
                if (folders.Count == 0) this.WriteLog(WowCloner.Properties.Resources.No_WoW_Copies_found);
                foreach (string folder in folders)
                {
                    this.listViewWowCopies.Items.Add(folder);
                }
            }
            catch (AggregateException ex)
            {
                AggregateHandler(ex);
            }
            this.EnableButtons();
        }

        private void DisableButtons()
        {
            this.buttonCreate.Enabled = false;
            this.buttonUpdate.Enabled = false;
            this.buttonUpdateAll.Enabled = false;
            this.buttonDelete.Enabled = false;
            this.buttonSearch.Enabled = false;
            this.textBoxName.Enabled = false;
            this.textBoxSource.Enabled = false;

            this.buttonCreate.BackgroundImage = global::WowCloner.Properties.Resources.button3_130x38;
            this.buttonUpdate.BackgroundImage = global::WowCloner.Properties.Resources.button3_130x38;
            this.buttonUpdateAll.BackgroundImage = global::WowCloner.Properties.Resources.button3_130x38;
            this.buttonDelete.BackgroundImage = global::WowCloner.Properties.Resources.button3_130x38;
            this.buttonSearch.BackgroundImage = global::WowCloner.Properties.Resources.button3_50x38;
            Application.DoEvents();
        }

        private void EnableButtons()
        {
            this.buttonCreate.Enabled = true;
            this.buttonUpdate.Enabled = true;
            this.buttonUpdateAll.Enabled = true;
            this.buttonDelete.Enabled = true;
            this.buttonSearch.Enabled = true;
            this.textBoxName.Enabled = true;
            this.textBoxSource.Enabled = true;

            this.buttonCreate.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonUpdate.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonUpdateAll.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonDelete.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonSearch.BackgroundImage = global::WowCloner.Properties.Resources.button1_50x38;
            Application.DoEvents();
        }

        private void WriteLog(string msg)
        {
            this.logBindingSource.Add(msg);
            Application.DoEvents();
        }

        private void ButtonCreateClick(object sender, EventArgs e)
        {
            this.logBindingSource.Clear();
            this.DisableButtons();
            try
            {
                this.WriteLog(WowCloner.Properties.Resources.Please_wait);
                Wow wow = new Wow(Properties.Settings.Default.wowsource);
                wow.Create(this.textBoxName.Text);
                this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources._0_created, this.textBoxName.Text));
            }
            catch (AggregateException ex)
            {
                AggregateHandler(ex);
            }

            this.LoadWowFolders();
            this.textBoxName.Text = "";
        }

        private void ButtonUpdateClick(object sender, EventArgs e)
        {
            this.logBindingSource.Clear();
            this.DisableButtons();
            if (this.listViewWowCopies.CheckedItems.Count > 0)
            {
                try
                {
                    this.WriteLog(WowCloner.Properties.Resources.Please_wait);
                    Wow wow = new Wow(Properties.Settings.Default.wowsource);
                    foreach (ListViewItem item in this.listViewWowCopies.CheckedItems)
                    {
                        wow.Update(item.Text);
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources._0_updated, item.Text));
                    }
                    this.WriteLog(WowCloner.Properties.Resources.Done);
                }
                catch (AggregateException ex)
                {
                    AggregateHandler(ex);
                }
            }
            else
            {
                this.WriteLog(WowCloner.Properties.Resources.Nothing_selected);
            }
            this.LoadWowFolders();
        }

        private void ButtonUpdateAllClick(object sender, EventArgs e)
        {
            this.logBindingSource.Clear();
            this.DisableButtons();
            try
            {
                if (this.listViewWowCopies.Items.Count > 0)
                {
                    this.WriteLog(WowCloner.Properties.Resources.Please_wait);
                    Wow wow = new Wow(Properties.Settings.Default.wowsource);
                    foreach (ListViewItem item in this.listViewWowCopies.Items)
                    {
                        wow.Update(item.Text);
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources._0_updated, item.Text));
                    }
                    this.WriteLog(WowCloner.Properties.Resources.Done);
                }
            }
            catch (AggregateException ex)
            {
                AggregateHandler(ex);
            }
            this.LoadWowFolders();
        }

        private void ButtonDeleteClick(object sender, EventArgs e)
        {
            this.logBindingSource.Clear();
            this.DisableButtons();
            if (this.listViewWowCopies.CheckedItems.Count > 0)
            {
                if (MessageBox.Show(null,
                                    WowCloner.Properties.Resources.Should_the_selected_WoW_Copies,
                                    WowCloner.Properties.Resources.Delete,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button2, (MessageBoxOptions)0) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        this.WriteLog(WowCloner.Properties.Resources.Please_wait);
                        Wow wow = new Wow(Properties.Settings.Default.wowsource);
                        foreach (ListViewItem item in this.listViewWowCopies.CheckedItems)
                        {
                            wow.Delete(item.Text);
                            this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources._0_deleted, item.Text));
                        }
                        this.WriteLog(WowCloner.Properties.Resources.Done);
                    }
                    catch (AggregateException ex)
                    {
                        AggregateHandler(ex);
                    }
                }
            }
            else
            {
                this.WriteLog(WowCloner.Properties.Resources.Nothing_selected);
            }
            this.LoadWowFolders();
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    this.LoadWowFolders();
                    this.logBindingSource.Clear();
                    break;
                case Keys.Escape:
                    if (this.Created) this.Close();
                    break;
            }
        }

        private void AggregateHandler(AggregateException errors)
        {
            this.logBindingSource.Clear();
            foreach (Exception ex in errors.InnerExceptions)
            {
                switch (ex.GetType().Name)
                {
                    case "Win32Exception":
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources.SymLink_Error_0_1, ((Win32Exception)ex).NativeErrorCode, ex.Message));
                        break;
                    case "MyException":
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, "{0}", ex.Message));
                        break;
                    case "Exception":
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources.Unknown_Error_0, ex.Message));
                        break;
                    default:
                        this.WriteLog(String.Format(CultureInfo.CurrentCulture, WowCloner.Properties.Resources.Unknown_Error_0, ex.Message));
                        break;
                }

            }
        }

        private void TextBoxSourceKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                try
                {
                    if (IsWowDir(this.textBoxSource.Text))
                    {
                        Properties.Settings.Default.wowsource = Path.GetFullPath(this.textBoxSource.Text);
                        Properties.Settings.Default.Save();
                        this.LoadWowFolders();
                    }
                    else
                    {
                        Properties.Settings.Default.wowsource = "";
                        Properties.Settings.Default.Save();
                        this.textBoxSource.Text = "";
                        this.WriteLog(WowCloner.Properties.Resources.Wow_exe_not_found_Please_selec);
                    }
                }
                catch (Exception ex)
                {
                    Properties.Settings.Default.wowsource = "";
                    Properties.Settings.Default.Save();
                    this.textBoxSource.Text = "";
                    AggregateHandler(new AggregateException(ex));
                    throw;
                }

            }
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.logBindingSource.Clear();

            // Workaround to avoid ArgumentException when disposing
            this.listBoxLog.SelectionMode = SelectionMode.One;

            Properties.Settings.Default.Save();
        }

        private void ButtonSearchClick(object sender, EventArgs e)
        {
            this.logBindingSource.Clear();
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (IsWowDir(folderBrowserDialog1.SelectedPath))
                {
                    this.textBoxSource.Text = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.wowsource = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.Save();
                    this.LoadWowFolders();
                }
                else
                {
                    Properties.Settings.Default.wowsource = "";
                    Properties.Settings.Default.Save();
                    this.textBoxSource.Text = "";
                    this.WriteLog(WowCloner.Properties.Resources.Wow_exe_not_found_Please_selec);
                }
            }
        }

        private static bool IsWowDir(string path)
        {
            try
            {
                if (Directory.GetFiles(path, "Wow.exe", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    return true;
                }
                if (Directory.GetFiles(path, "Wow-64.exe", SearchOption.TopDirectoryOnly).Length > 0)
                {
                    return true;
                }
            }
            catch (Exception) { throw; }
            return false;
        }

        private void ButtonGreatMouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = global::WowCloner.Properties.Resources.button2_130x38;
            this.ResumeLayout();
        }

        private void ButtonGreatMouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.ResumeLayout();
        }

        private void ButtonSmallMouseHover(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = global::WowCloner.Properties.Resources.button2_50x38;
            this.ResumeLayout();
        }

        private void ButtonSmallMouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackgroundImage = global::WowCloner.Properties.Resources.button1_50x38;
            this.ResumeLayout();
        }

        private void ButtonMinimizeMouseHover(object sender, EventArgs e)
        {
            this.buttonMinimize.BackgroundImage = global::WowCloner.Properties.Resources.mini2;
            this.ResumeLayout();
        }

        private void ButtonMinimizeMouseLeave(object sender, EventArgs e)
        {
            this.buttonMinimize.BackgroundImage = global::WowCloner.Properties.Resources.mini1;
            this.ResumeLayout();
        }

        private void ButtonMinimizeClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ButtonCloseMouseHover(object sender, EventArgs e)
        {
            this.buttonClose.BackgroundImage = global::WowCloner.Properties.Resources.close2;
            this.ResumeLayout();
        }

        private void ButtonCloseMouseLeave(object sender, EventArgs e)
        {
            this.buttonClose.BackgroundImage = global::WowCloner.Properties.Resources.close1;
            this.ResumeLayout();
        }

        private void ButtonCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LinkLabelByClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://r15ch13.de");
        }

        private void LabelTitleMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && sender.GetType() == typeof(Label) && move == true)
            {
                this.Left = this.Left - (this.mouse_x - e.X);
                this.Top = this.Top - (this.mouse_y - e.Y);
            }
            else
            {
                this.move = false;
            }
        }

        private void LabelTitleMouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(Label))
            {
                this.mouse_x = e.X;
                this.mouse_y = e.Y;
                this.move = true;
            }
            else
            {
                this.move = false;
            }
        }

        private void MainPictureBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType() == typeof(PictureBox))
            {
                this.mouse_x = e.X;
                this.mouse_y = e.Y;
                this.move = true;
            }
            else
            {
                this.move = false;
            }
        }

        private void MainPictureBoxMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left && sender.GetType() == typeof(PictureBox) && move == true)
            {
                this.Left = this.Left - (this.mouse_x - e.X);
                this.Top = this.Top - (this.mouse_y - e.Y);
            }
            else
            {
                this.move = false;
            }
        }
    }
}
