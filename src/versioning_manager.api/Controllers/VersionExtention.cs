using System;

namespace versioning_manager.api.Controllers
{
    public static class VersionExtention
    {
        public static Version IncrementMajor(this Version version)
        {
            var newVersion = new Version(version.Major + 1, 0, 0, 0);
            return newVersion;
        }

        public static Version IncrementMinor(this Version version)
        {
            var newVersion = new Version(version.Major, version.Minor + 1, 0, 0);
            return newVersion;
        }

        public static Version IncrementBuild(this Version version)
        {
            var newVersion = new Version(version.Major, version.Minor, version.Build + 1, 0);
            return newVersion;
        }

        public static Version IncrementRevision(this Version version)
        {
            var newVersion = new Version(version.Major, version.Minor, version.Build, version.Revision + 1);
            return newVersion;
        }
    }
}
