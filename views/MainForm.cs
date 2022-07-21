using FSModMan.controller;
using FSModMan.data;
using System.Diagnostics;

namespace FSModMan
{
    public partial class MainForm : Form
    {

        private readonly DataController dataController;

        private Addon? currentAddon;

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

            // Add all addons to default group
            if(dataController.library.defaultGroup != null)
            {
                TreeNode defaultGroupNode = new(dataController.library.defaultGroup.Name);
                defaultGroupNode.Tag = dataController.library.defaultGroup;

                addonTreeView.Nodes.Add(defaultGroupNode);

                foreach (Addon addon in dataController.library.defaultGroup.addons)
                {
                    TreeNode addonNode = new(addon.ToString());
                    addonNode.Tag = addon;
                    addonNode.ContextMenuStrip = addonContextMenu;
                    defaultGroupNode.Nodes.Add(addonNode);
                }
            }
            

            // Create nodes for each group and add addons of this group
            foreach(Group group in dataController.library.groups)
            {

                TreeNode groupNode = new(group.ToString());
                groupNode.Tag = group;

                addonTreeView.Nodes.Add(groupNode); 

                foreach(Addon addon in group.addons)
                {
                    TreeNode addonNode = new(addon.ToString());
                    addonNode.Tag= addon;
                    groupNode.Nodes.Add(addon.ToString());
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
            installButton.Visible = true;

            dataName.Text = data.Name;
            dataDescription.Text = data.Description;

            if (data is Addon)
            {
                Addon addon = (Addon)data;
                installButton.Text = addon.IsInstalled ? "Uninstall" : "Install";
            }
            else if(data is Group)
            {
                Group group = (Group)data;
                if(group.addons.Count > 0)
                {
                    installButton.Text = group.IsInstalled() ? "Uninstall" : "Install";
                }
                else
                {
                    installButton.Visible = false;
                } 
            }
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

        private void installBtn_Click(object sender, EventArgs e)
        {
            Object selectedNode = addonTreeView.SelectedNode.Tag;

            if (selectedNode == null)
                return;

            if(selectedNode is Addon)
                dataController.MoveAddon((Addon)selectedNode);
            else if(selectedNode is Group)
                dataController.MoveGroup((Group)selectedNode);

            UpdateInfoView(selectedNode);
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

            dataController.AddAddonToGroup(currentAddon, group);

            UpdateAddonTreeView();

           
        }

        private void addonTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateInfoView(addonTreeView.SelectedNode.Tag);
        }
    }
}