using FSModMan.controller;
using FSModMan.data;
using System.Diagnostics;

namespace FSModMan
{
    public partial class MainForm : Form
    {

        private readonly DataController dataController;

        private Addon? currentAddon;

        bool busy = false;

        public MainForm()
        {
            InitializeComponent();

            dataController = new DataController();

            originPath.Text = "Origin: " + dataController.library.originLocation;
            targetPath.Text = "Target: " + dataController.library.targetLocation;

            UpdateAddonTreeView();
        }

        private void UpdateAddonTreeView()
        {
            // Stop redrawing of the tree view
            addonTreeView.BeginUpdate();

            addonTreeView.Nodes.Clear();

            // Create nodes for each group and add addons of this group
            foreach(Group group in dataController.library.groups)
            {

                TreeNode groupNode = new(group.ToString());
                groupNode.Tag = group;

                addonTreeView.Nodes.Add(groupNode); 

                foreach(Addon addon in group.addons)
                {
                    TreeNode addonNode = new(addon.ToString());
                    addonNode.Tag = addon;
                    addonNode.ContextMenuStrip = addonContextMenu;
                    groupNode.Nodes.Add(addonNode);
                }
            }

            addonTreeView.ExpandAll();
            addonTreeView.EndUpdate();

        }

        private void UpdateInfoView(Object node)
        {

            if (node is not Data)
                return;

            Data data = (Data)node;

            dataName.Visible = true;
            dataDescription.Visible = true;
            saveButton.Visible = true;
            installedLabel.Visible = true;

            dataName.Text = data.Name;
            dataDescription.Text = data.Description;


            installedLabel.Text = data.IsInstalled() ? "Installed" : "Not Installed";

        }

        private void addAddonnMenuBtn_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {

                dataController.CreateAddon(folderDialog.SelectedPath);

                UpdateAddonTreeView();
            }
        }

        private void addGroupMenuBtn_Click(object sender, EventArgs e)
        {
            dataController.CreateGroup();

            UpdateAddonTreeView();
        }

        private void installButton_Click(object sender, EventArgs e)
        {

            // Loop over all groups
            foreach(TreeNode groupNode in addonTreeView.Nodes)
            {
                // Loop over all addon nodes
                foreach(TreeNode addonNode in groupNode.Nodes)
                {
                    // Install addon if checked
                    if (addonNode.Checked)
                    {
                        Object nodeTag = addonNode.Tag;
                        if (nodeTag is Addon)
                        {
                            if(((Button)sender).Text.Equals("Install"))
                                dataController.InstallAddon((Addon)nodeTag);
                            else
                                dataController.UninstallAddon((Addon)nodeTag);
                        }
                    }
                }
            }

            if(addonTreeView.SelectedNode != null)
                UpdateInfoView(addonTreeView.SelectedNode.Tag);
        }

        private void targetButton_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                dataController.library.targetLocation = folderDialog.SelectedPath;
                targetPath.Text = "Target: " + dataController.library.targetLocation;
            }
        }

        private void originButton_Click(object sender, EventArgs e)
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                dataController.library.originLocation = folderDialog.SelectedPath;
                originPath.Text = "Origin: " + dataController.library.originLocation;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataController.Save();
        }
       

        private void addonTreeView_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {

                TreeNode node = addonTreeView.GetNodeAt(e.X, e.Y);

                if (node.Tag is not Addon)
                    return;

                currentAddon = (Addon)node.Tag;

                ToolStripMenuItem addItem = (ToolStripMenuItem)addonContextMenu.Items[0];
                addItem.DropDownItems.Clear();

                List<Group> groups = dataController.GetNotAssignedGroups(currentAddon);

                foreach (Group group in groups)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = group.Name;
                    item.Tag = group;
                    item.Click += new EventHandler(addTo_MouseClick);
                    addItem.DropDownItems.Add(item);
                }
            }
        }

        private void addTo_MouseClick(object? sender, EventArgs e)
        {

            if (sender == null) return;

            if (currentAddon == null) return;

            ToolStripMenuItem? item = sender as ToolStripMenuItem;

            if (item == null) return;

            Group group = (Group)item.Tag;

            dataController.MoveAddonToGroup(currentAddon, group);

            UpdateAddonTreeView();

           
        }

        private void addonTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateInfoView(addonTreeView.SelectedNode.Tag);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Get the current addon or group

            if(addonTreeView.SelectedNode == null) return;

            Object tag = addonTreeView.SelectedNode.Tag;

            if(tag == null) return;

            if(tag is Data)
            {
                Data data = (Data)tag;
                data.Name = dataName.Text;
                data.Description = dataDescription.Text;
            }

            dataController.Save();

            UpdateAddonTreeView();
        }

        private void addonTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if(e.Action == TreeViewAction.Unknown) return;

            if(e.Node == null) return;

            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }

            busy = false;

        }

        private void addonTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {

            // Ignore if node is null
            if (e.Node == null) return;

            if (busy && e.Action != TreeViewAction.Unknown)
            {
                e.Cancel = true;
                return;
            }
                
            if (e.Node.Parent == null)
            {
                if (busy)
                    e.Cancel = true;
                else
                    busy = true;

                return;
            }
              
            // Do not allow changing of the check box if group is checked
            if(e.Node.Parent.Checked && e.Action != TreeViewAction.Unknown)
                e.Cancel = true;
        }
    }
}