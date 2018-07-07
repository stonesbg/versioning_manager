using System.Collections.Generic;
using versioning_manager.data.Models;

namespace versioning_manager.contracts.Services
{
    public interface IVersionService
    {
        IEnumerable<VersionDetail> GetVersions(IVersionRequest request);

        VersionDetail IncrementVersion(IVersionRequest request);
    }

}
