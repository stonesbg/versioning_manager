using System;
using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Services
{
    public interface IVersionService
    {
        IVersionDetail GetVersion();

    IVersionDetail GetVersion(int major);

    IVersionDetail GetVersion(int major, int minor);

    IVersionDetail GetVersion(int major, int minor, int build);

    IVersionDetail GetVersion(int major, int minor, int build, int revision);

        IEnumerable<IVersionDetail> GetVersions();

        IEnumerable<IVersionDetail> GetVersions(int major);

        IEnumerable<IVersionDetail> GetVersions(int major, int minor);

        IEnumerable<IVersionDetail> GetVersions(int major, int minor, int build);

        IEnumerable<IVersionDetail> GetVersions(int major, int minor, int build, int revision);

    IVersionDetail IncrementBuildVersion();

    IVersionDetail IncrementMajorVersion();

    IVersionDetail IncrementMinorVersion();

    IVersionDetail IncrementRevisionVersion();
    }

}
