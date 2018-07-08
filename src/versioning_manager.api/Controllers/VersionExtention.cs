using versioning_manager.data.Models;

namespace versioning_manager.api.Controllers
{
    public static class VersionExtention
    {
        public static VersionSimple IncrementMajor(this VersionSimple version)
        {
            var newVersion = new VersionSimple(version.Major + 1, 0, 0, 0);
            return newVersion;
        }

        public static VersionSimple IncrementMinor(this VersionSimple version)
        {
            var newVersion = new VersionSimple(version.Major, version.Minor + 1, 0, 0);
            return newVersion;
        }

        public static VersionSimple IncrementBuild(this VersionSimple version)
        {
            var newVersion = new VersionSimple(version.Major, version.Minor, version.Build + 1, 0);
            return newVersion;
        }

        public static VersionSimple IncrementRevision(this VersionSimple version)
        {
            var newVersion = new VersionSimple(version.Major, version.Minor, version.Build, version.Revision + 1);
            return newVersion;
        }
    }
}
