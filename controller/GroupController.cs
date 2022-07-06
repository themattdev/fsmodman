using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSModMan.data;

namespace FSModMan.controller
{
    public class GroupController
    {

        public List<Group> groups = new();
        public Group defaultGroup;

        public GroupController()
        {
            defaultGroup = new Group("All");
        }

        public bool Add(string name)
        {
            Group group = new (name);


            if (groups.Contains(group))
                return false;

            groups.Add(group);

            return true;
        }

    }
}
