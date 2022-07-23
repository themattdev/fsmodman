using FSModMan.data;
using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace FSModMan.controller
{
    public class DataController
    {

        public Library library;

        public DataController() 
        {
            
            library = new Library();
            library.groups.Add(new Group("No Group"));

            if (File.Exists(Application.StartupPath + "\\fslib.xml"))
            {
                var mySerializer = new XmlSerializer(typeof(Library));

                using var myFileStream = new FileStream(Application.StartupPath + "\\fslib.xml", FileMode.Open);

                Object? result = mySerializer.Deserialize(myFileStream);

                if(result != null)
                    library = (Library)result;
            }

        }

        public void CreateAddon(string path)
        {

            string[] folderSplit = path.Split('\\');
            string addonFolder = folderSplit[folderSplit.Length - 1];

            CopyDirectory(path, library.originLocation + '\\' + addonFolder, true);

            Addon addon = new Addon(addonFolder, addonFolder);

            library.addons.Add(addon);
            library.groups[0].Add(addon);

        }

        public void CreateGroup()
        {

            bool foundGroupName = false;
            int groupIndex = 0;
            string groupName = "New Group";

            while (!foundGroupName)
            {
                groupIndex++;
                foundGroupName = true;

                if (groupIndex > 0)
                    groupName = "New Group " + groupIndex.ToString();

                foreach (Group group in library.groups)
                {
                    if (group.Name is not null && group.Name.Equals(groupName)){
                        foundGroupName = false;
                        break;
                    }
                }
            }

            library.groups.Add(new Group(groupName));
            
        }

        public void MoveAddonToGroup(Addon addon, Group group)
        {
            // Remove addon from current group
            foreach(Group g in library.groups)
            {
                if(g.addons.Contains(addon))
                {
                    g.addons.Remove(addon);
                    break;
                }
            }

            // Add addon to new group
            foreach(Group g in library.groups)
            {
                if (g.Equals(group))
                {
                    g.Add(addon);
                    break;
                }
            }
        }

        public void InstallAddon(Addon addon)
        {
            if (addon.IsInstalled())
                return;

            Directory.Move(library.originLocation + '\\' + addon.Path, library.targetLocation + '\\' + addon.Path);

            addon.SetInstalled(true);
        }

        public void UninstallAddon(Addon addon)
        {
            if (!addon.IsInstalled())
                return;

            addon.SetInstalled(false);

            Directory.Move(library.targetLocation + '\\' + addon.Path, library.originLocation + '\\' + addon.Path);
        }

        public List<Group> GetNotAssignedGroups(Addon addon)
        {
            List<Group> groups = new List<Group>();

            foreach(Group group in library.groups)
            {
                if(!group.addons.Contains(addon) && !groups.Contains(group))
                    groups.Add(group);
            }

            return groups;
        }

        static void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourceDir);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);

            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        public void Save()
        {

            XmlSerializer mySerializer = new XmlSerializer(typeof(Library));
            TextWriter writer = new StreamWriter(Application.StartupPath + "\\fslib.xml");
            mySerializer.Serialize(writer, library);

            writer.Close();
        }


    }
}
