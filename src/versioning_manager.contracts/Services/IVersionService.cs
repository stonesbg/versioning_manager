using System;
using System.Collections.Generic;

namespace versioning_manager.contracts.Services
{
    public interface IVersionService
    {
        Version GetVersion();

        Version GetVersion(int major);

        Version GetVersion(int major, int minor);

        Version GetVersion(int major, int minor, int build);

        Version GetVersion(int major, int minor, int build, int revision);

        IEnumerable<Version> GetVersions();

        IEnumerable<Version> GetVersions(int major);

        IEnumerable<Version> GetVersions(int major, int minor);

        IEnumerable<Version> GetVersions(int major, int minor, int build);

        IEnumerable<Version> GetVersions(int major, int minor, int build, int revision);

        Version IncrementBuildVersion();

        Version IncrementMajorVersion();

        Version IncrementMinorVersion();

        Version IncrementRevisionVersion();
    }

}
