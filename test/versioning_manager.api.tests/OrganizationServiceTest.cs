using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Models;
using versioning_manager.api.Services;
using versioning_manager.contracts.Data;
using Xunit;

namespace versioning_manager.api.tests
{
    public class OrganizationServiceTest
    {
        IEnumerable<Organization> VersionNumbers = new List<Organization>
            {
                new Organization() {Id = 1, Name = "Org 1" },
                new Organization() {Id = 2, Name = "Org 2" },
                new Organization() {Id = 3, Name = "Org 3" },
            };

        [Fact]
        public void GetOrganizations()
        {
            var repository = new Mock<IOrganizationRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new OrganizationService(repository.Object);

            var organizationsList = service.GetAll();
            organizationsList.Count().Should().Be(3);
        }

        //[Fact]
        //public void AddOrg()
        //{
        //    var orgToCreate = new Organization() { Name = "New Org 1", Description = "New Description" };

        //    var repository = new Mock<IOrganizationRepository>();
        //    repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

        //    var service = new OrganizationService(repository.Object);

        //    var organizationsList = service.GetAll();
        //    organizationsList.Count().Should().Be(3);

        //}
    }
}
