using System;
using versioning_manager.api.Controllers;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.Extensions
{
    public static class VersionSimpleExtension
    {
        public static VersionSimple CalculateIncrement(this VersionSimple version, IVersionRequest request)
        {
            VersionSimple incrementedVersion = version;

            if (!request.Major.HasValue && request.Minor.HasValue)
                throw new ArgumentException("Cannot pass a Minor version without Major version");

            if (request.Major.HasValue && request.Minor.HasValue)
            {
                incrementedVersion = incrementedVersion.IncrementBuild();
            }
            else if (request.Major.HasValue && !request.Minor.HasValue)
            {
                incrementedVersion = incrementedVersion.IncrementMinor();
            }
            else
            {
                incrementedVersion = incrementedVersion.IncrementMajor();
            }

            return incrementedVersion;
        }

        public static VersionSimple CreateIncrement(this VersionSimple version, IVersionRequest request)
        {
            VersionSimple incrementedVersion = version;

            if (!request.Major.HasValue && request.Minor.HasValue)
                throw new ArgumentException("Cannot pass a Minor version without Major version");

            if (request.Major.HasValue && !request.Minor.HasValue)
            {
                incrementedVersion = new VersionSimple(request.Major.Value, 0, 0, 0);
            }
            else if (request.Major.HasValue && request.Minor.HasValue)
            {
                incrementedVersion = new VersionSimple(request.Major.Value, request.Minor.Value, 0, 0);
            }
            else
            {
                incrementedVersion = new VersionSimple(1, 0, 0, 0);
            }

            return incrementedVersion;
        }
    }
}
