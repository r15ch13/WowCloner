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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace wowcloner
{
	public partial class Form1 : Form
	{
		private List<string> log = new List<string>();

		public Form1()
		{
			InitializeComponent();

			this.logBindingSource.DataSource = this.log;
			
			this.textBoxSource.Text = Properties.Settings.Default.wowsource;
			
			this.loadWoWFolders();
			try
			{
				this.label4.Text = "World of Warcraft Cloner - " + FileVersionInfo.GetVersionInfo(Application.ExecutablePath).ProductVersion.ToString();
			}
			catch (Exception) { }
			
			//43;21;7
			//26;16;7
			//192;154;103
			//255;174;0
		}

		private void loadWoWFolders()
		{
			this.listView1.Items.Clear();
			try
			{
				WoW wow = new WoW(Properties.Settings.Default.wowsource);
				List<string> folders = wow.GetFolders();
				if (folders.Count == 0) writeLog("Keine WoW-Kopien gefunden.");
				foreach (string folder in folders)
				{
					this.listView1.Items.Add(folder);
				}
			}
			catch (AggregateException ex)
			{
				AggregateHandler(ex);
			}
			this.enableButtons();
		}

		private void disableButtons()
		{
			this.buttonCreate.Enabled = false;
			this.buttonUpdate.Enabled = false;
			this.buttonUpdateAll.Enabled = false;
			this.buttonDelete.Enabled = false;
			this.buttonSearch.Enabled = false;
			this.textBoxName.Enabled = false;
			this.textBoxSource.Enabled = false;

			this.buttonCreate.BackgroundImage = global::wowcloner.Properties.Resources.button3_130x38;
			this.buttonUpdate.BackgroundImage = global::wowcloner.Properties.Resources.button3_130x38;
			this.buttonUpdateAll.BackgroundImage = global::wowcloner.Properties.Resources.button3_130x38;
			this.buttonDelete.BackgroundImage = global::wowcloner.Properties.Resources.button3_130x38;
			this.buttonSearch.BackgroundImage = global::wowcloner.Properties.Resources.button3_50x38;
			Application.DoEvents();
		}
		private void enableButtons()
		{
			this.buttonCreate.Enabled = true;
			this.buttonUpdate.Enabled = true;
			this.buttonUpdateAll.Enabled = true;
			this.buttonDelete.Enabled = true;
			this.buttonSearch.Enabled = true;
			this.textBoxName.Enabled = true;
			this.textBoxSource.Enabled = true;

			this.buttonCreate.BackgroundImage = global::wowcloner.Properties.Resources.button1_130x38;
			this.buttonUpdate.BackgroundImage = global::wowcloner.Properties.Resources.button1_130x38;
			this.buttonUpdateAll.BackgroundImage = global::wowcloner.Properties.Resources.button1_130x38;
			this.buttonDelete.BackgroundImage = global::wowcloner.Properties.Resources.button1_130x38;
			this.buttonSearch.BackgroundImage = global::wowcloner.Properties.Resources.button1_50x38;
			Application.DoEvents();
		}

		private void writeLog(string msg)
		{
			this.logBindingSource.Add(msg);
			Application.DoEvents();
		}

		private void buttonCreate_Click(object sender, EventArgs e)
		{
			this.logBindingSource.Clear();
			this.disableButtons();
			try
			{
				this.writeLog("Bitte warten ...");
				WoW wow = new WoW(Properties.Settings.Default.wowsource);
				wow.Create(this.textBoxName.Text);
				this.writeLog(this.textBoxName.Text + " wurde erstellt.");
			}
			catch (AggregateException ex)
			{
				AggregateHandler(ex);
			}

			this.loadWoWFolders();
			this.textBoxName.Text = "";
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			this.logBindingSource.Clear();
			this.disableButtons();
			if (this.listView1.CheckedItems.Count > 0)
			{
				try
				{
					this.writeLog("Bitte warten ...");
					WoW wow = new WoW(Properties.Settings.Default.wowsource);
					foreach (ListViewItem item in this.listView1.CheckedItems)
					{
						wow.Update(item.Text);
						this.writeLog(item.Text + " wurde aktualisiert.");
					}
					this.writeLog("Fertig!");
				}
				catch (AggregateException ex)
				{
					AggregateHandler(ex);
				}
			}
			else
			{
				this.writeLog("Nichts ausgewählt!");
			}
			this.loadWoWFolders();
		}

		private void buttonUpdateAll_Click(object sender, EventArgs e)
		{
			this.logBindingSource.Clear();
			this.disableButtons();
			try
			{
				if (this.listView1.Items.Count > 0)
				{
					this.writeLog("Bitte warten ...");
					WoW wow = new WoW(Properties.Settings.Default.wowsource);
					foreach (ListViewItem item in this.listView1.Items)
					{
						wow.Update(item.Text);
						this.writeLog(item.Text + " wurde aktualisiert.");
					}
					this.writeLog("Fertig!");
				}
			}
			catch (AggregateException ex)
			{
				AggregateHandler(ex);
			}
			this.loadWoWFolders();
		}
		
		private void buttonDelete_Click(object sender, EventArgs e)
		{
			this.logBindingSource.Clear();
			this.disableButtons();
			if (this.listView1.CheckedItems.Count > 0)
			{
				if (MessageBox.Show(null,
									String.Format("Sollen die ausgewählten WoW-Kopien wirklich gelöscht werden?{0}Alle AddOns, Einstellungen und Profile werden ebenfalls gelöscht!", Environment.NewLine),
									"Löschen?",
									MessageBoxButtons.YesNo,
									MessageBoxIcon.Warning,
									MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
				{
					try
					{
						this.writeLog("Bitte warten ...");
						WoW wow = new WoW(Properties.Settings.Default.wowsource);
						foreach (ListViewItem item in this.listView1.CheckedItems)
						{
							wow.Delete(item.Text);
							this.writeLog(item.Text + " wurde gelöscht.");
						}
						this.writeLog("Fertig!");
					}
					catch (AggregateException ex)
					{
						AggregateHandler(ex);
					}
				}
			}
			else
			{
				this.writeLog("Nichts ausgewählt!");
			}
			this.loadWoWFolders();
		}



		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F5:
					this.loadWoWFolders();
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
						this.writeLog(String.Format("SymLink Fehler ({0}): {1}", ((Win32Exception)ex).NativeErrorCode, ex.Message));
						break;
					case "MyException":
						this.writeLog(String.Format("{0}", ex.Message));
						break;
					case "Exception":
						this.writeLog(String.Format("Unbekannter Fehler: {0}", ex.Message));
						break;
					default:
						this.writeLog(String.Format("Unbekannter Fehler: {0}", ex.Message));
						break;
				}

			}
		}

		private void textBoxSource_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				try
				{
					Properties.Settings.Default.wowsource = Path.GetFullPath(this.textBoxSource.Text);
					if (this.isWoWDir(folderBrowserDialog1.SelectedPath))
					{
						Properties.Settings.Default.Save();
						this.loadWoWFolders();
					}
					else
					{
						Properties.Settings.Default.wowsource = "";
						Properties.Settings.Default.Save();
						this.textBoxSource.Text = "";
						this.writeLog("Wow.exe nicht gefunden! Bitte richtiges Installationsverzeichnis wählen.");
					}
				}
				catch (Exception ex)
				{
					Properties.Settings.Default.wowsource = "";
					Properties.Settings.Default.Save();
					this.textBoxSource.Text = "";
					AggregateHandler(new AggregateException(ex));
				}
				
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.logBindingSource.Clear();

			// Workaround to avoid ArgumentException when disposing
			this.listBox1.SelectionMode = SelectionMode.One;

			Properties.Settings.Default.Save();
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			this.logBindingSource.Clear();
			if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				if (this.isWoWDir(folderBrowserDialog1.SelectedPath))
				{
					this.textBoxSource.Text = folderBrowserDialog1.SelectedPath;
					Properties.Settings.Default.wowsource = folderBrowserDialog1.SelectedPath;
					Properties.Settings.Default.Save();
					this.loadWoWFolders();
				}
				else
				{
					Properties.Settings.Default.wowsource = "";
					Properties.Settings.Default.Save();
					this.textBoxSource.Text = "";
					this.writeLog("Wow.exe nicht gefunden! Bitte richtiges Installationsverzeichnis wählen.");
				}
			}
		}

		private bool isWoWDir(string path)
		{
			try 
			{
				if (Directory.GetFiles(path, "Wow.exe", SearchOption.TopDirectoryOnly).Length > 0)
				{
					return true;
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		

		private void buttonGreat_MouseHover(object sender, EventArgs e)
		{
			((Button)sender).BackgroundImage = global::wowcloner.Properties.Resources.button2_130x38;
			this.ResumeLayout();
		}

		private void buttonGreat_MouseLeave(object sender, EventArgs e)
		{
			((Button)sender).BackgroundImage = global::wowcloner.Properties.Resources.button1_130x38;
			this.ResumeLayout();
		}

		private void buttonSmall_MouseHover(object sender, EventArgs e)
		{
			((Button)sender).BackgroundImage = global::wowcloner.Properties.Resources.button2_50x38;
			this.ResumeLayout();
		}

		private void buttonSmall_MouseLeave(object sender, EventArgs e)
		{
			((Button)sender).BackgroundImage = global::wowcloner.Properties.Resources.button1_50x38;
			this.ResumeLayout();
		}

		private void buttonMinimize_MouseHover(object sender, EventArgs e)
		{
			this.buttonMinimize.BackgroundImage = global::wowcloner.Properties.Resources.mini2;
			this.ResumeLayout();
		}

		private void buttonMinimize_MouseLeave(object sender, EventArgs e)
		{
			this.buttonMinimize.BackgroundImage = global::wowcloner.Properties.Resources.mini1;
			this.ResumeLayout();
		}

		private void buttonMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void buttonClose_MouseHover(object sender, EventArgs e)
		{
			this.buttonClose.BackgroundImage = global::wowcloner.Properties.Resources.close2;
			this.ResumeLayout();
		}

		private void buttonClose_MouseLeave(object sender, EventArgs e)
		{
			this.buttonClose.BackgroundImage = global::wowcloner.Properties.Resources.close1;
			this.ResumeLayout();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://r15ch13.de");
		}


		private int mouse_x = 0;
		private int mouse_y = 0;
		private bool move = false;

		private void label4_MouseMove(object sender, MouseEventArgs e)
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

		private void label4_MouseDown(object sender, MouseEventArgs e)
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

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
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

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
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
