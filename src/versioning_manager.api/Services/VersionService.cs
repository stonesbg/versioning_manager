using System;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Controllers;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.Services
{
    public class VersionService : IVersionService
    {
        IVersionDetailRepository _repository;
        public VersionService(IVersionDetailRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VersionDetail> GetVersions(IVersionRequest request)
        {
            var listOfVersions = _repository.GetByProductId(request.ProductId);
            return listOfVersions
                 .WithMajorVersion(request.Major)
                 .WithMinorVersion(request.Minor);
        }

        public VersionDetail IncrementVersion(IVersionRequest request)
        {
            var versions = GetVersions(request);

            var versionList = versions.OrderBy(x => x).Reverse();

            Version version = null;
            if (versionList.Count() == 0)
            {
                if (!request.Major.HasValue && request.Minor.HasValue)
                    throw new ArgumentException("Cannot pass a Minor version without Major version");

                if (request.Major.HasValue && !request.Minor.HasValue)
                {
                    version = new Version(request.Major.Value, 0, 0, 0);
                }
                else if (request.Major.HasValue && request.Minor.HasValue)
                {
                    version = new Version(request.Major.Value, request.Minor.Value, 0, 0);
                }
                else
                {
                    version = new Version(1, 0, 0, 0);
                }
            }
            else
            {
                version = versionList.First().Version;

                if (!request.Major.HasValue && !request.Minor.HasValue)
                {
                    version = version.IncrementBuild();
                }
                else if (!request.Major.HasValue && request.Minor.HasValue)
                {
                    version = version.IncrementMinor();
                }
                else
                {
                    version = version.IncrementMajor();
                }
            }

            var versionDetail = new VersionDetail
            {
                Version = version,
                CreatedDate = DateTime.Now,
                Product = new Product
                {
                    Id = request.ProductId
                }
            };

            var created = _repository.Add(versionDetail);

            return created;
        }
    }
}
