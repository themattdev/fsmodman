using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSModMan.data;

namespace FSModMan.controller
{
    public class AddonController
    {

        public List<Addon> addons = new();

        public AddonController()
        {

        }

        public bool Add(string name)
        {

            Addon addon = new(name);

            if (addons.Contains(addon))
                return false;

            addons.Add(addon);

            return true;

        }

        public bool Remove(string name)
        {

            foreach(Addon addon in addons)
            {
                if (addon.Name.Equals(name))
                {
                    addons.Remove(addon);
                    return true;
                }
            }

            return false;
        }


    }


   
}
