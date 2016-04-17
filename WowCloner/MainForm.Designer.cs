namespace WowCloner
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
            this.logBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelSource = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelWowCopies = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonUpdateAll = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.linkLabelBy = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSource
            // 
            this.textBoxSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(21)))), ((int)(((byte)(7)))));
            this.textBoxSource.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxSource, "textBoxSource");
            this.textBoxSource.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxSourceKeyDown);
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(21)))), ((int)(((byte)(7)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
            this.textBoxName.Name = "textBoxName";
            // 
            // listViewWowCopies
            // 
            this.listViewWowCopies.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(21)))), ((int)(((byte)(7)))));
            this.listViewWowCopies.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewWowCopies.CheckBoxes = true;
            this.listViewWowCopies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewWowCopies.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
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
            this.listBoxLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(21)))), ((int)(((byte)(7)))));
            this.listBoxLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxLog.DataSource = this.logBindingSource;
            this.listBoxLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
            this.listBoxLog.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxLog, "listBoxLog");
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.SelectionMode = System.Windows.Forms.SelectionMode.None;
            // 
            // labelSource
            // 
            resources.ApplyResources(this.labelSource, "labelSource");
            this.labelSource.Name = "labelSource";
            // 
            // labelName
            // 
            resources.ApplyResources(this.labelName, "labelName");
            this.labelName.Name = "labelName";
            // 
            // labelWowCopies
            // 
            resources.ApplyResources(this.labelWowCopies, "labelWowCopies");
            this.labelWowCopies.Name = "labelWowCopies";
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
            this.labelTitle.Image = global::WowCloner.Properties.Resources.titlebg;
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelTitleMouseDown);
            this.labelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LabelTitleMouseMove);
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::WowCloner.Properties.Resources.close1;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            this.buttonClose.MouseLeave += new System.EventHandler(this.ButtonCloseMouseLeave);
            this.buttonClose.MouseHover += new System.EventHandler(this.ButtonCloseMouseHover);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackgroundImage = global::WowCloner.Properties.Resources.mini1;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonMinimize, "buttonMinimize");
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.TabStop = false;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.ButtonMinimizeClick);
            this.buttonMinimize.MouseLeave += new System.EventHandler(this.ButtonMinimizeMouseLeave);
            this.buttonMinimize.MouseHover += new System.EventHandler(this.ButtonMinimizeMouseHover);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.ButtonUpdateClick);
            this.buttonUpdate.MouseLeave += new System.EventHandler(this.ButtonGreatMouseLeave);
            this.buttonUpdate.MouseHover += new System.EventHandler(this.ButtonGreatMouseHover);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = global::WowCloner.Properties.Resources.button1_50x38;
            this.buttonSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.ButtonSearchClick);
            this.buttonSearch.MouseLeave += new System.EventHandler(this.ButtonSmallMouseLeave);
            this.buttonSearch.MouseHover += new System.EventHandler(this.ButtonSmallMouseHover);
            // 
            // buttonUpdateAll
            // 
            resources.ApplyResources(this.buttonUpdateAll, "buttonUpdateAll");
            this.buttonUpdateAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateAll.FlatAppearance.BorderSize = 0;
            this.buttonUpdateAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.buttonUpdateAll.Name = "buttonUpdateAll";
            this.buttonUpdateAll.UseVisualStyleBackColor = true;
            this.buttonUpdateAll.Click += new System.EventHandler(this.ButtonUpdateAllClick);
            this.buttonUpdateAll.MouseLeave += new System.EventHandler(this.ButtonGreatMouseLeave);
            this.buttonUpdateAll.MouseHover += new System.EventHandler(this.ButtonGreatMouseHover);
            // 
            // buttonDelete
            // 
            resources.ApplyResources(this.buttonDelete, "buttonDelete");
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            this.buttonDelete.MouseLeave += new System.EventHandler(this.ButtonGreatMouseLeave);
            this.buttonDelete.MouseHover += new System.EventHandler(this.ButtonGreatMouseHover);
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackgroundImage = global::WowCloner.Properties.Resources.button1_130x38;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.buttonCreate, "buttonCreate");
            this.buttonCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreateClick);
            this.buttonCreate.MouseLeave += new System.EventHandler(this.ButtonGreatMouseLeave);
            this.buttonCreate.MouseHover += new System.EventHandler(this.ButtonGreatMouseHover);
            // 
            // mainPictureBox
            // 
            resources.ApplyResources(this.mainPictureBox, "mainPictureBox");
            this.mainPictureBox.Image = global::WowCloner.Properties.Resources.window;
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBoxMouseDown);
            this.mainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBoxMouseMove);
            // 
            // linkLabelBy
            // 
            this.linkLabelBy.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            resources.ApplyResources(this.linkLabelBy, "linkLabelBy");
            this.linkLabelBy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelBy.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
            this.linkLabelBy.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelBy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(174)))), ((int)(((byte)(0)))));
            this.linkLabelBy.Name = "linkLabelBy";
            this.linkLabelBy.TabStop = true;
            this.linkLabelBy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelByClicked);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(16)))), ((int)(((byte)(7)))));
            this.Controls.Add(this.linkLabelBy);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.labelWowCopies);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelSource);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonUpdateAll);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.listViewWowCopies);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.mainPictureBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(154)))), ((int)(((byte)(103)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.logBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
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
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelWowCopies;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.LinkLabel linkLabelBy;
        private System.Windows.Forms.BindingSource logBindingSource;
    }
}

