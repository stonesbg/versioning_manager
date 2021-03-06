using System;
using versioning_manager.api.Controllers;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using System.Linq;
using versioning_manager.contracts.Data;
using versioning_manager.api.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.tests
{
    [Trait("Category", "Unit")]
    public class VersionServiceTest
    {
        IEnumerable<VersionDetail> VersionDetails = new List<VersionDetail>
            {
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 1, 100, 0),
                  CreatedDate = DateTime.UtcNow,
                  Product = new Product
                  {
                      Id = 1
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 1, 101, 0),
                  CreatedDate = DateTime.UtcNow,
                    Product = new Product
                  {
                      Id = 1
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 1, 102, 0),
                  CreatedDate = DateTime.UtcNow,
                    Product = new Product
                  {
                      Id = 1
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 2, 100, 0),
                  CreatedDate = DateTime.UtcNow,
                  Product = new Product
                  {
                      Id = 1
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 3, 100, 0),
                  CreatedDate = DateTime.UtcNow,
                  Product = new Product
                  {
                      Id = 2
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 4, 1, 0),
                  CreatedDate = DateTime.UtcNow,
                  Product = new Product
                  {
                      Id = 2
                  }
                },
                new VersionDetail {
                  Id = 1,
                  Version = new VersionSimple(8, 4, 102, 0),
                  CreatedDate = DateTime.UtcNow,
                  Product = new Product
                  {
                      Id = 3
                  }
                }
            };

        [Fact]
        public void GetVersion()
        {
            var versionDetail = new VersionRequest()
            {
                ProductId = 1
            };

            var repository = new Mock<IVersionDetailRepository>();
            repository.Setup(x => x.GetByProductId(versionDetail.ProductId))
                .Returns(VersionDetails.Where(x => x.Product.Id == versionDetail.ProductId));

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(versionDetail);
            version.Count().Should().Be(4);
        }

        [Fact]
        public void GetVersionMajor()
        {
            var versionDetail = new VersionRequest()
            {
                ProductId = 1,
                Major = 8
            };

            var repository = new Mock<IVersionDetailRepository>();
            repository.Setup(x => x.GetByProductId(versionDetail.ProductId))
                .Returns(VersionDetails
                    .Where(x => x.Product.Id == versionDetail.ProductId &&
                        x.Version.Major == versionDetail.Major));

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(versionDetail);
            version.Count().Should().Be(4);
        }

        [Fact]
        public void GetVersionMajorMinor()
        {
            var versionDetail = new VersionRequest()
            {
                ProductId = 1,
                Major = 8,
                Minor = 2
            };

            var repository = new Mock<IVersionDetailRepository>();
            repository.Setup(x => x.GetByProductId(versionDetail.ProductId))
                .Returns(VersionDetails
                    .Where(x => x.Product.Id == versionDetail.ProductId &&
                        x.Version.Major == versionDetail.Major));

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(versionDetail);
            version.Count().Should().Be(1);
            var expectedVersion = new VersionSimple(8, 2, 100, 0);
            version.First().Version.Major.Should().Be(expectedVersion.Major);
            version.First().Version.Minor.Should().Be(expectedVersion.Minor);
            version.First().Version.Build.Should().Be(expectedVersion.Build);
            version.First().Version.Revision.Should().Be(expectedVersion.Revision);
        }

        [Fact]
        public void AddItemToVersion()
        {
            var versionDetail = new VersionRequest()
            {
                ProductId = 1,
                Major = 8,
                Minor = 2
            };

            var addResult = new VersionDetail
            {
                Id = 1,
                Version = new VersionSimple
                {
                    Major = 8,
                    Minor = 2,
                    Build = 101,
                    Revision = 0
                },
                CreatedDate = DateTime.Now
            };

            var repository = new Mock<IVersionDetailRepository>();
            repository.Setup(x => x.GetByProductId(versionDetail.ProductId))
                .Returns(VersionDetails
                    .Where(x => x.Product.Id == versionDetail.ProductId &&
                        x.Version.Major == versionDetail.Major));

            repository.Setup(x => x.Add(It.IsAny<VersionDetail>()))
                .Returns(addResult);

            var service = new VersionService(repository.Object);

            var version = service.IncrementVersion(versionDetail);

            var expectedVersion = new VersionSimple(8, 2, 101, 0);
            version.Version.Major.Should().Be(expectedVersion.Major);
            version.Version.Minor.Should().Be(expectedVersion.Minor);
            version.Version.Build.Should().Be(expectedVersion.Build);
            version.Version.Revision.Should().Be(expectedVersion.Revision);
        }
    }
}
