namespace FSModMan
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAddonnMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupMenuBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.installButton = new System.Windows.Forms.Button();
            this.dataName = new System.Windows.Forms.TextBox();
            this.dataDescription = new System.Windows.Forms.TextBox();
            this.targetPath = new System.Windows.Forms.Label();
            this.originPath = new System.Windows.Forms.Label();
            this.targetButton = new System.Windows.Forms.Button();
            this.originButton = new System.Windows.Forms.Button();
            this.addonContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addonTreeView = new FSModMan.ui.MyTreeView();
            this.installedLabel = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.addonContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 24);
            this.mainMenu.TabIndex = 3;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAddonnMenuBtn,
            this.addGroupMenuBtn});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addAddonnMenuBtn
            // 
            this.addAddonnMenuBtn.Name = "addAddonnMenuBtn";
            this.addAddonnMenuBtn.Size = new System.Drawing.Size(135, 22);
            this.addAddonnMenuBtn.Text = "Add Addon";
            this.addAddonnMenuBtn.Click += new System.EventHandler(this.addAddonnMenuBtn_Click);
            // 
            // addGroupMenuBtn
            // 
            this.addGroupMenuBtn.Name = "addGroupMenuBtn";
            this.addGroupMenuBtn.Size = new System.Drawing.Size(135, 22);
            this.addGroupMenuBtn.Text = "Add Group";
            this.addGroupMenuBtn.Click += new System.EventHandler(this.addGroupMenuBtn_Click);
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(12, 398);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(75, 23);
            this.installButton.TabIndex = 5;
            this.installButton.Text = "Install";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // dataName
            // 
            this.dataName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dataName.Location = new System.Drawing.Point(244, 85);
            this.dataName.Name = "dataName";
            this.dataName.Size = new System.Drawing.Size(544, 29);
            this.dataName.TabIndex = 6;
            this.dataName.Text = "Name";
            this.dataName.Visible = false;
            // 
            // dataDescription
            // 
            this.dataDescription.Location = new System.Drawing.Point(244, 120);
            this.dataDescription.Multiline = true;
            this.dataDescription.Name = "dataDescription";
            this.dataDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataDescription.Size = new System.Drawing.Size(544, 91);
            this.dataDescription.TabIndex = 8;
            this.dataDescription.Text = "Description";
            this.dataDescription.Visible = false;
            // 
            // targetPath
            // 
            this.targetPath.AutoSize = true;
            this.targetPath.Location = new System.Drawing.Point(244, 31);
            this.targetPath.Name = "targetPath";
            this.targetPath.Size = new System.Drawing.Size(39, 15);
            this.targetPath.TabIndex = 9;
            this.targetPath.Text = "Target";
            // 
            // originPath
            // 
            this.originPath.AutoSize = true;
            this.originPath.Location = new System.Drawing.Point(244, 60);
            this.originPath.Name = "originPath";
            this.originPath.Size = new System.Drawing.Size(40, 15);
            this.originPath.TabIndex = 10;
            this.originPath.Text = "Origin";
            // 
            // targetButton
            // 
            this.targetButton.Location = new System.Drawing.Point(713, 27);
            this.targetButton.Name = "targetButton";
            this.targetButton.Size = new System.Drawing.Size(75, 23);
            this.targetButton.TabIndex = 11;
            this.targetButton.Text = "Open";
            this.targetButton.UseVisualStyleBackColor = true;
            this.targetButton.Click += new System.EventHandler(this.targetButton_Click);
            // 
            // originButton
            // 
            this.originButton.Location = new System.Drawing.Point(713, 56);
            this.originButton.Name = "originButton";
            this.originButton.Size = new System.Drawing.Size(75, 23);
            this.originButton.TabIndex = 12;
            this.originButton.Text = "Open";
            this.originButton.UseVisualStyleBackColor = true;
            this.originButton.Click += new System.EventHandler(this.originButton_Click);
            // 
            // addonContextMenu
            // 
            this.addonContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToToolStripMenuItem});
            this.addonContextMenu.Name = "addonContextMenu";
            this.addonContextMenu.Size = new System.Drawing.Size(120, 26);
            // 
            // addToToolStripMenuItem
            // 
            this.addToToolStripMenuItem.Name = "addToToolStripMenuItem";
            this.addToToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.addToToolStripMenuItem.Text = "Move To";
            // 
            // uninstallButton
            // 
            this.uninstallButton.Location = new System.Drawing.Point(93, 398);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(75, 23);
            this.uninstallButton.TabIndex = 13;
            this.uninstallButton.Text = "Uninstall";
            this.uninstallButton.UseVisualStyleBackColor = true;
            this.uninstallButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(244, 232);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // addonTreeView
            // 
            this.addonTreeView.CheckBoxes = true;
            this.addonTreeView.Location = new System.Drawing.Point(12, 27);
            this.addonTreeView.Name = "addonTreeView";
            this.addonTreeView.Size = new System.Drawing.Size(226, 365);
            this.addonTreeView.TabIndex = 15;
            this.addonTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.addonTreeView_BeforeCheck);
            this.addonTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.addonTreeView_AfterCheck);
            this.addonTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.addonTreeView_AfterSelect);
            // 
            // installedLabel
            // 
            this.installedLabel.AutoSize = true;
            this.installedLabel.Location = new System.Drawing.Point(246, 214);
            this.installedLabel.Name = "installedLabel";
            this.installedLabel.Size = new System.Drawing.Size(51, 15);
            this.installedLabel.TabIndex = 16;
            this.installedLabel.Text = "Installed";
            this.installedLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.installedLabel);
            this.Controls.Add(this.addonTreeView);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.originButton);
            this.Controls.Add(this.targetButton);
            this.Controls.Add(this.originPath);
            this.Controls.Add(this.targetPath);
            this.Controls.Add(this.dataDescription);
            this.Controls.Add(this.dataName);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "FSModMan";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.addonContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem addAddonnMenuBtn;
        private ToolStripMenuItem addGroupMenuBtn;
        private FolderBrowserDialog folderDialog;
        private Button installButton;
        private TextBox dataName;
        private TextBox dataDescription;
        private Label targetPath;
        private Label originPath;
        private Button targetButton;
        private Button originButton;
        private ContextMenuStrip addonContextMenu;
        private ToolStripMenuItem addToToolStripMenuItem;
        private Button uninstallButton;
        private Button saveButton;
        private ui.MyTreeView addonTreeView;
        private Label installedLabel;
    }
}