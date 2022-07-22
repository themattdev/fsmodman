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
            installButton.Visible = true;
            uninstallButton.Visible = true;

            dataName.Text = data.Name;
            dataDescription.Text = data.Description;

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
            Object selectedNode = addonTreeView.SelectedNode.Tag;

            if (selectedNode == null)
                return;

            if(selectedNode is Addon)
                dataController.InstallAddon((Addon)selectedNode);
            else if(selectedNode is Group)
                dataController.InstallGroup((Group)selectedNode);

            UpdateInfoView(selectedNode);
        }

        private void uninstallButton_Click(object sender, EventArgs e)
        {
            Object selectedNode = addonTreeView.SelectedNode.Tag;

            if (selectedNode == null)
                return;

            if (selectedNode is Addon)
                dataController.UninstallAddon((Addon)selectedNode);
            else if (selectedNode is Group)
                dataController.UninstallGroup((Group)selectedNode);

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

            dataController.MoveAddonToGroup(currentAddon, group);

            UpdateAddonTreeView();

           
        }

        private void addonTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            UpdateInfoView(addonTreeView.SelectedNode.Tag);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // TODO: Implement Addon Saving
        }
    }
}