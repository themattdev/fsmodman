using System;

namespace FSModMan.data
{
    public class Addon : Data
    {

        bool installed;
        public string? Path;

        public List<string> files = new();

        public Addon(string _Name, string _Path)
        {
            Name = _Name;
            Path = _Path;
            installed = false;
            Description = "Enter Description";

        }

        public Addon() { }


        public override string ToString()
        {
            if (Name == null)
                return "";

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
            if(Name == null) return false;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            int result = (string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode()) + (string.IsNullOrEmpty(Path) ? 0 : Path.GetHashCode());

            return result;
        }

        public override bool IsInstalled()
        {
            return installed;
        }

        public void SetInstalled(bool _installed)
        {
            installed = _installed;
        }
    }
}