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
            this.btnAddAddon = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.addonTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnAddAddon
            // 
            this.btnAddAddon.Location = new System.Drawing.Point(16, 12);
            this.btnAddAddon.Name = "btnAddAddon";
            this.btnAddAddon.Size = new System.Drawing.Size(110, 47);
            this.btnAddAddon.TabIndex = 0;
            this.btnAddAddon.Text = "Add Addon";
            this.btnAddAddon.UseVisualStyleBackColor = true;
            this.btnAddAddon.Click += new System.EventHandler(this.btnAddAddon_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(132, 12);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(110, 47);
            this.btnAddGroup.TabIndex = 1;
            this.btnAddGroup.Text = "Add Group";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // addonTreeView
            // 
            this.addonTreeView.Location = new System.Drawing.Point(16, 65);
            this.addonTreeView.Name = "addonTreeView";
            this.addonTreeView.Size = new System.Drawing.Size(226, 214);
            this.addonTreeView.TabIndex = 2;
            this.addonTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.addonTreeView_AfterSelect);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addonTreeView);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.btnAddAddon);
            this.Name = "MainForm";
            this.Text = "FSModMan";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnAddAddon;
        private Button btnAddGroup;
        private TreeView addonTreeView;
    }
}