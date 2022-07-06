using System;

namespace FSModMan.data
{
    public class Addon : IEquatable<Addon>
    {
        public string Name { get; set; }

        public Addon(string _Name)
        {

            Name = _Name;

        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Addon other) return false;
            return Equals(other);
        }

        public bool Equals(Addon? other)
        {
            if (other == null) return false;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}