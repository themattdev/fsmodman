using FSModMan.controller;
using FSModMan.data;
using System.Diagnostics;

namespace FSModMan
{
    public partial class MainForm : Form
    {

        private readonly AddonController addonController;
        private readonly GroupController groupController;
        

        public MainForm()
        {

            InitializeComponent();

            addonController = new AddonController();
            groupController = new GroupController();
        }

        private void btnAddAddon_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Add Addon");

            addonController.Add("Test Addon");

            UpdateAddonTreeView();
            
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Add Group");

            groupController.Add("Test Group");

            UpdateAddonTreeView();
          
        }

        private void UpdateAddonTreeView()
        {
            // Stop redrawing of the tree view
            addonTreeView.BeginUpdate();

            addonTreeView.Nodes.Clear();

            // Add all addons to default group
            TreeNode defaultGroupNode = new(groupController.defaultGroup.Name);
            defaultGroupNode.Tag = groupController.defaultGroup;

            addonTreeView.Nodes.Add(defaultGroupNode);

            foreach(Addon addon in addonController.addons)
            {
                TreeNode addonNode = new(addon.ToString());
                addonNode.Tag = addon;
                defaultGroupNode.Nodes.Add(addonNode);
            }

            // Create nodes for each group and add addons of this group
            foreach(Group group in groupController.groups)
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

        private void addonTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if(e.Node == null)
                return;

            if(e.Node.Tag is Addon)
            {
                Debug.WriteLine("Addon selected");
            }
            else if(e.Node.Tag is Group)
            {
                Debug.WriteLine("Group selected");
            }
        }
    }
}