using System;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Controllers;
using versioning_manager.api.Extensions;
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

            var versionList = versions.OrderBy(x => new Version(x.Version.Major, x.Version.Minor)).Reverse();

            VersionSimple version = null;
            if (versionList.Count() == 0)
            {
                version.CreateIncrement(request);
            }
            else
            {
                version = versionList.First().Version;
                version.CalculateIncrement(request);
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
