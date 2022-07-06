using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSModMan.data
{
    public class Group : IEquatable<Group>
    {

        public string Name { get; set; }

        public List<Addon> addons = new();

        public Group(string _Name)
        {

            addons = new List<Addon>();
            Name = _Name;

        }

        public bool Add(Addon addon)
        {

            if (addons.Contains(addon))
                return false;

            addons.Add(addon);

            return true;

        }

        public bool Remove(Addon addon)
        {
            return addons.Remove(addon);
        }

        public void Clear()
        {
            addons.Clear();
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Group other) return false;
            return Equals(other);
        }

        public bool Equals(Group? other)
        {
            if(other == null) return false;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

    }
}
