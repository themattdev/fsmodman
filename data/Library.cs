using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSModMan.data
{
    public class Library
    {

        public string targetLocation = "";
        public string originLocation = "";
        public List<Group> groups = new();
        public List<Addon> addons = new();
    }
}
