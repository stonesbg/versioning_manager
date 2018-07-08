namespace versioning_manager.data.Models
{
    public class VersionSimple
    {
        public int Major { get; set; }

        public int Minor { get; set; }

        public int Build { get; set; }

        public int Revision { get; set; }

        public VersionSimple()
        {
            Major = 1;
            Minor = 0;
            Build = 0;
            Revision = 0;
        }

        public VersionSimple(int major, int minor, int build, int revision)
        {
            Major = major;
            Minor = minor;
            Build = build;
            Revision = revision;
        }
    }

}
