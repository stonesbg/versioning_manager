using System.Collections.Generic;
using System.Linq;
using versioning_manager.data.Models;

namespace versioning_manager.api.Services
{
    public static class VersionDetailExtensions
    {
        public static IEnumerable<VersionDetail> WithMajorVersion(this IEnumerable<VersionDetail> versionDetails, int? major)
        {
            var result = versionDetails;

            if (major.HasValue)
            {
                result = versionDetails.Where(x => x.Version.Major == major);
            }

            return result;
        }

        public static IEnumerable<VersionDetail> WithMinorVersion(this IEnumerable<VersionDetail> versionDetails, int? minor)
        {
            var result = versionDetails;

            if (minor.HasValue)
            {
                result = versionDetails.Where(x => x.Version.Minor == minor);
            }
            return result;
        }
    }
}
