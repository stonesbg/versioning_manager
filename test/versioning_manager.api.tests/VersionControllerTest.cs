using System;
using versioning_manager.api.Controllers;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using Microsoft.AspNetCore.Mvc;
using versioning_manager.contracts.Data;
using versioning_manager.api.Services;

namespace versioning_manager.api.tests
{
    public class VersionControllerTest
    {
        IEnumerable<Version> VersionNumbers = new List<Version>
            {
                new Version(8, 1, 100, 0),
                new Version(8, 1, 101, 0),
                new Version(8, 1, 102, 0),
                new Version(8, 2, 0, 0),
                new Version(8, 2, 1, 0)
            };

        [Fact]
        public void GetVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.GetVersion();
            version.Value.Should().Be(new Version(8, 2, 1, 0));
        }

        [Fact]
        public void GetVersionMajor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.GetVersion(8);
            version.Should().Be(new Version(8, 2, 1, 0));
        }

        [Fact]
        public void GetVersionMajorMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.GetVersion(8, 1);
            version.Should().Be(new Version(8, 1, 102, 0));
        }

        [Fact]
        public void GetVersionMajorMinorBuild()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.GetVersion(8, 1, 101);
            version.Should().Be(new Version(8, 1, 101, 0));
        }

        [Fact]
        public void GetVersionMajorMinorBuildRevision()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.GetVersion(8, 1, 101, 0);
            version.Should().Be(new Version(8, 1, 101, 0));
        }

        [Fact]
        public void IncrementMajorVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.IncrementMajorVersion();
            version.Should().Be(new Version(9, 0, 0, 0));
        }

        [Fact]
        public void IncrementMinorVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.IncrementMinorVersion();
            version.Should().Be(new Version(8, 3, 0, 0));
        }

        [Fact]
        public void IncrementBuildVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.IncrementBuildVersion();
            version.Should().Be(new Version(8, 2, 2, 0));
        }

        [Fact]
        public void IncrementRevisionVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var controller = new VersionController(service);
            var version = controller.IncrementRevisionVersion();
            version.Should().Be(new Version(8, 2, 1, 1));
        }
    }
}
