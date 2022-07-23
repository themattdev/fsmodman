namespace FSModMan.data
{
    public abstract class Data
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public abstract bool IsInstalled();

    }
}
