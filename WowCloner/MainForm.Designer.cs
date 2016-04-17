namespace Wowcloner
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.listViewWowCopies = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdateAll = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            this.SuspendLayout();
            //
            // textBoxSource
            //
            this.textBoxSource.BackColor = System.Drawing.Color.FromArgb(43, 21, 7);
            this.textBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxSource, "textBoxSource");
            this.textBoxSource.ForeColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSource_KeyDown);
            //
            // textBoxName
            //
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(43, 21, 7);
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.textBoxName.Name = "textBoxName";
            //
            // listViewWowCopies
            //
            this.listViewWowCopies.BackColor = System.Drawing.Color.FromArgb(43, 21, 7);
            this.listViewWowCopies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWowCopies.CheckBoxes = true;
            this.listViewWowCopies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewWowCopies.ForeColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.listViewWowCopies.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            resources.ApplyResources(this.listViewWowCopies, "listViewWowCopies");
            this.listViewWowCopies.MultiSelect = false;
            this.listViewWowCopies.Name = "listViewWowCopies";
            this.listViewWowCopies.UseCompatibleStateImageBehavior = false;
            this.listViewWowCopies.View = System.Windows.Forms.View.Details;
            //
            // columnHeader1
            //
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            //
            // listBoxLog
            //
            this.listBoxLog.BackColor = System.Drawing.Color.FromArgb(43, 21, 7);
            this.listBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxLog.DataSource = this.logBindingSource;
            this.listBoxLog.ForeColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.listBoxLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxLog, "listBoxLog");
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            //
            // label1
            //
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            //
            // label2
            //
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            //
            // label3
            //
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            //
            // folderBrowserDialog1
            //
            resources.ApplyResources(this.folderBrowserDialog1, "folderBrowserDialog1");
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            //
            // labelTitle
            //
            resources.ApplyResources(this.labelTitle, "labelTitle");
            this.labelTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelTitle.Image = global::Wowcloner.Properties.Resources.titlebg;
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseMove);
            //
            // buttonClose
            //
            this.buttonClose.BackgroundImage = global::Wowcloner.Properties.Resources.close1;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseLeave += new System.EventHandler(this.buttonClose_MouseLeave);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseHover);
            //
            // buttonMinimize
            //
            this.buttonMinimize.BackgroundImage = global::Wowcloner.Properties.Resources.mini1;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonMinimize, "buttonMinimize");
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.TabStop = false;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            this.buttonMinimize.MouseLeave += new System.EventHandler(this.buttonMinimize_MouseLeave);
            this.buttonMinimize.MouseHover += new System.EventHandler(this.buttonMinimize_MouseHover);
            //
            // buttonUpdate
            //
            this.buttonUpdate.BackgroundImage = global::Wowcloner.Properties.Resources.button1_130x38;
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.ForeColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            this.buttonUpdate.MouseLeave += new System.EventHandler(this.buttonGreat_MouseLeave);
            this.buttonUpdate.MouseHover += new System.EventHandler(this.buttonGreat_MouseHover);
            //
            // buttonSearch
            //
            this.buttonSearch.BackgroundImage = global::Wowcloner.Properties.Resources.button1_50x38;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.ForeColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.MouseLeave += new System.EventHandler(this.buttonSmall_MouseLeave);
            this.buttonSearch.MouseHover += new System.EventHandler(this.buttonSmall_MouseHover);
            //
            // buttonUpdateAll
            //
            resources.ApplyResources(this.buttonUpdateAll, "buttonUpdateAll");
            this.buttonUpdateAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateAll.FlatAppearance.BorderSize = 0;
            this.buttonUpdateAll.ForeColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.buttonUpdateAll.Name = "buttonUpdateAll";
            this.buttonUpdateAll.UseVisualStyleBackColor = true;
            this.buttonUpdateAll.Click += new System.EventHandler(this.buttonUpdateAll_Click);
            this.buttonUpdateAll.MouseLeave += new System.EventHandler(this.buttonGreat_MouseLeave);
            this.buttonUpdateAll.MouseHover += new System.EventHandler(this.buttonGreat_MouseHover);
            //
            // buttonDelete
            //
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            this.buttonDelete.MouseLeave += new System.EventHandler(this.buttonGreat_MouseLeave);
            this.buttonDelete.MouseHover += new System.EventHandler(this.buttonGreat_MouseHover);
            //
            // buttonCreate
            //
            this.buttonCreate.BackgroundImage = global::Wowcloner.Properties.Resources.button1_130x38;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonCreate, "buttonCreate");
            this.buttonCreate.ForeColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            this.buttonCreate.MouseLeave += new System.EventHandler(this.buttonGreat_MouseLeave);
            this.buttonCreate.MouseHover += new System.EventHandler(this.buttonGreat_MouseHover);
            //
            // pictureBox1
            //
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::Wowcloner.Properties.Resources.window;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            //
            // linkLabel1
            //
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(255, 174, 0);
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(255, 174, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            //
            // MainForm
            //
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(26, 16, 7);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonUpdateAll);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewWowCopies);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(192, 154, 103);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.ListView listViewWowCopies;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdateAll;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.BindingSource logBindingSource;
    }
}

