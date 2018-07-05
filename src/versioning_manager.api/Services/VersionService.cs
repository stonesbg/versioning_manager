using System;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Controllers;
using versioning_manager.api.Models;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;
using versioning_manager.contracts.Services;

namespace versioning_manager.api.Services
{
  public class VersionService : IVersionService
  {
    IVersionDetailRepository _repository;
    public VersionService(IVersionDetailRepository repository)
    {
      _repository = repository;
    }

    public IVersionDetail GetVersion()
    {
      var versionList = GetVersions().OrderBy(x => x).Reverse();

      // TODO: Change this to return null instead of exception
      if (versionList.Count() == 0)
        throw new Exception("No Versions available.");

      return versionList.First();
    }

    public IVersionDetail GetVersion(int major)
    {
      return GetVersions(major)
          .OrderBy(x => x)
          .Reverse()
          .First();
    }

    public IVersionDetail GetVersion(int major, int minor)
    {
      return GetVersions(major, minor)
          .OrderBy(x => x)
          .Reverse()
          .First();
    }

    public IVersionDetail GetVersion(int major, int minor, int build)
    {
      return GetVersions(major, minor, build)
          .OrderBy(x => x)
          .Reverse()
          .First();
    }

    public IVersionDetail GetVersion(int major, int minor, int build, int revision)
    {
      return GetVersions(major, minor, build, revision)
          .OrderBy(x => x)
          .Reverse()
          .First();
    }

    public IEnumerable<IVersionDetail> GetVersions()
    {
      return _repository.GetAll();
    }

    public IEnumerable<IVersionDetail> GetVersions(int major)
    {
      return GetVersions().Where(x => x.Version.Major == major);
    }

    public IEnumerable<IVersionDetail> GetVersions(int major, int minor)
    {
      return GetVersions(major).Where(x => x.Version.Minor == minor);
    }

    public IEnumerable<IVersionDetail> GetVersions(int major, int minor, int build)
    {
      return GetVersions(major, minor).Where(x => x.Version.Build == build);
    }

    public IEnumerable<IVersionDetail> GetVersions(int major, int minor, int build, int revision)
    {
      return GetVersions(major, minor, build).Where(x => x.Version.Revision == revision);
    }

    public IVersionDetail IncrementMajorVersion()
    {
      var versionDetail = GetVersion();

      return new VersionDetail
      {
        Version = versionDetail.Version.IncrementMajor(),
        CreatedDate = DateTime.UtcNow
      };
    }

    public IVersionDetail IncrementMajorVersion(int major)
    {
      if (GetVersions(major).Count() > 0)
      {
        throw new ArgumentException("Major version already exists");
      }

      return new VersionDetail
      {
        Version = new Version(major, 0, 0, 0),
        CreatedDate = DateTime.UtcNow
      };
    }

    public IVersionDetail IncrementMinorVersion()
    {
      var versionDetail = GetVersion();

      return new VersionDetail
      {
        Version = versionDetail.Version.IncrementMinor(),
        CreatedDate = DateTime.UtcNow
      };
    }

    public IVersionDetail IncrementMinorVersion(int major, int minor)
    {
      var getCurrentVersion = IncrementMajorVersion(major);

      if (getCurrentVersion.Version.Minor == minor)
      {
        throw new ArgumentException("Minor version already exists");
      }

      return new VersionDetail { Version = new Version(getCurrentVersion.Version.Major, minor, 0, 0), CreatedDate = DateTime.UtcNow };
    }

    public IVersionDetail IncrementMinorVersion(int minor)
    {
      var getCurrentVersion = GetVersion();

      if (getCurrentVersion.Version.Minor == minor)
      {
        throw new ArgumentException("Minor version already exists");
      }

      return new VersionDetail{
        Version = new Version(getCurrentVersion.Version.Major, minor, 0, 0),
        CreatedDate = DateTime.UtcNow
      };
    }

    public IVersionDetail IncrementBuildVersion()
    {
      var versionDetail = GetVersion();

      return new VersionDetail
      {
        Version = versionDetail.Version.IncrementBuild(),
        CreatedDate = DateTime.UtcNow
      };
    }

    public IVersionDetail IncrementRevisionVersion()
    {
      var versionDetail = GetVersion();

      return new VersionDetail
      {
        Version = versionDetail.Version.IncrementRevision(),
        CreatedDate = DateTime.UtcNow
      };
    }
  }

}
