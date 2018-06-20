using System;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Controllers;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Services;

namespace versioning_manager.api.Services
{
    public class VersionService : IVersionService
    {
        IVersionRepository _repository;
        public VersionService(IVersionRepository repository)
        {
            _repository = repository;
        }

        public Version GetVersion()
        {
            var versionList = GetVersions().OrderBy(x => x).Reverse();

            // TODO: Change this to return null instead of exception
            if (versionList.Count() == 0)
                throw new Exception("No Versions available.");

            return versionList.First();
        }

        public Version GetVersion(int major)
        {
            return GetVersions(major)
                .OrderBy(x => x)
                .Reverse()
                .First();
        }

        public Version GetVersion(int major, int minor)
        {
            return GetVersions(major, minor)
                .OrderBy(x => x)
                .Reverse()
                .First();
        }

        public Version GetVersion(int major, int minor, int build)
        {
            return GetVersions(major, minor, build)
                .OrderBy(x => x)
                .Reverse()
                .First();
        }

        public Version GetVersion(int major, int minor, int build, int revision)
        {
            return GetVersions(major, minor, build, revision)
                .OrderBy(x => x)
                .Reverse()
                .First();
        }

        public IEnumerable<Version> GetVersions()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Version> GetVersions(int major)
        {
            return GetVersions().Where(x => x.Major == major);
        }

        public IEnumerable<Version> GetVersions(int major, int minor)
        {
            return GetVersions(major).Where(x => x.Minor == minor);
        }

        public IEnumerable<Version> GetVersions(int major, int minor, int build)
        {
            return GetVersions(major, minor).Where(x => x.Build == build);
        }

        public IEnumerable<Version> GetVersions(int major, int minor, int build, int revision)
        {
            return GetVersions(major, minor, build).Where(x => x.Revision == revision);
        }

        public Version IncrementMajorVersion()
        {
            return GetVersion().IncrementMajor();
        }

        public Version IncrementMajorVersion(int major)
        {
            if (GetVersions(major).Count() > 0)
            {
                throw new ArgumentException("Major version already exists");
            }

            return new Version(major, 0, 0, 0);
        }

        public Version IncrementMinorVersion()
        {
            return GetVersion().IncrementMinor();
        }

        public Version IncrementMinorVersion(int major, int minor)
        {
            var getCurrentVersion = IncrementMajorVersion(major);

            if (getCurrentVersion.Minor == minor)
            {
                throw new ArgumentException("Minor version already exists");
            }

            return new Version(getCurrentVersion.Major, minor, 0, 0);
        }

        public Version IncrementMinorVersion(int minor)
        {
            var getCurrentVersion = GetVersion();

            if (getCurrentVersion.Minor == minor)
            {
                throw new ArgumentException("Minor version already exists");
            }

            return new Version(getCurrentVersion.Major, minor, 0, 0);
        }

        public Version IncrementBuildVersion()
        {
            return GetVersion().IncrementBuild();
        }

        public Version IncrementRevisionVersion()
        {
            return GetVersion().IncrementRevision();
        }
    }

}
