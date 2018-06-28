using System;
using versioning_manager.api.Controllers;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using Moq;
using System.Linq;
using versioning_manager.contracts.Data;
using versioning_manager.api.Services;

namespace versioning_manager.api.tests
{
    public class VersionServiceTest
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

            var version = service.GetVersion();
            version.Should().Be(new Version(8, 2, 1, 0));
        }

        [Fact]
        public void GetVersionNoVersions()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(new List<Version>());

            var service = new VersionService(repository.Object);

            Action getVersion = () => service.GetVersion();
            getVersion
                .Should()
                .Throw<Exception>()
                .WithMessage("No Versions available.");
        }

        [Fact]
        public void GetVersionMajor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersion(8);
            version.Should().Be(new Version(8, 2, 1, 0));
        }

        [Fact]
        public void GetVersionMajorMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersion(8, 1);
            version.Should().Be(new Version(8, 1, 102, 0));
        }

        [Fact]
        public void GetVersionMajorMinorBuild()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersion(8, 1, 101);
            version.Should().Be(new Version(8, 1, 101, 0));
        }

        [Fact]
        public void GetVersionMajorMinorBuildRevision()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersion(8, 1, 101, 0);
            version.Should().Be(new Version(8, 1, 101, 0));
        }

        [Fact]
        public void GetVersions()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersions();
            version.Count().Should().Be(5);
        }

        [Fact]
        public void GetVersionsMajor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(8);
            version.Count().Should().Be(5);
        }

        [Fact]
        public void GetVersionsMajorMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(8, 1);
            version.Count().Should().Be(3);
        }

        [Fact]
        public void GetVersionsMajorMinorBuild()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(8, 1, 102);
            version.Count().Should().Be(1);
        }

        [Fact]
        public void GetVersionsMajorMinorBuildRevision()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.GetVersions(8, 1, 102, 0);
            version.Count().Should().Be(1);
        }

        [Fact]
        public void IncrementMajorVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementMajorVersion();
            version.Should().Be(new Version(9, 0, 0, 0));
        }

        [Fact]
        public void IncrementMajorVersionWithMajor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementMajorVersion(18);
            version.Should().Be(new Version(18, 0, 0, 0));
        }

        [Fact]
        public void IncrementMajorVersionWithExistingMajor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            Action incrementMajorVersionAction = () => service.IncrementMajorVersion(8);

            incrementMajorVersionAction
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Major version already exists");
        }

        [Fact]
        public void IncrementMinorVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementMinorVersion();
            version.Should().Be(new Version(8, 3, 0, 0));
        }

        [Fact]
        public void IncrementMinorVersionWithMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementMinorVersion(3);
            version.Should().Be(new Version(8, 3, 0, 0));
        }

        [Fact]
        public void IncrementMinorVersionWithMajorWithMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementMinorVersion(18, 2);
            version.Should().Be(new Version(18, 2, 0, 0));
        }

        [Fact]
        public void IncrementMinorVersionWithExistingMinor()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            Action incrementMinorVersionAction = () => service.IncrementMinorVersion(2);

            incrementMinorVersionAction
                .Should()
                .Throw<ArgumentException>()
                .WithMessage("Minor version already exists");
        }

        [Fact]
        public void IncrementBuildVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementBuildVersion();
            version.Should().Be(new Version(8, 2, 2, 0));
        }

        [Fact]
        public void IncrementRevisionVersion()
        {
            var repository = new Mock<IVersionRepository>();
            repository.Setup(x => x.GetAll()).Returns(VersionNumbers);

            var service = new VersionService(repository.Object);

            var version = service.IncrementRevisionVersion();
            version.Should().Be(new Version(8, 2, 1, 1));
        }

    }
}
