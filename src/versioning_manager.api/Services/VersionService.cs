using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<IVersionDetail> GetVersions(IVersionRequest request)
        {
            return _repository.GetByProductId(request.ProductId)
                 .WithMajorVersion(request.Major)
                 .WithMinorVersion(request.Minor);
        }

        public IVersionDetail IncrementVersion(IVersionRequest request)
        {
            var versions = GetVersions(request);

            var versionList = versions.OrderBy(x => x).Reverse();

            // TODO: Change this to return null instead of exception
            if (versionList.Count() == 0)
                throw new Exception("No Versions available.");

            return versionList.First();
        }
    }
}
