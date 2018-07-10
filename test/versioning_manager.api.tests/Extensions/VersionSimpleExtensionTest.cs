using System;
using versioning_manager.data.Models;
using Xunit;
using versioning_manager.api.Extensions;
using versioning_manager.api.Controllers;
using FluentAssertions;

namespace versioning_manager.api.tests.Extensions
{
    public class CalculateIncremnet
    {
        public class VersionSimpleExtensionTest
        {
            [Fact]
            public void JustProductId()
            {
                var version = new VersionSimple(8, 3, 0, 0);

                var calculatedVersion = version.CalculateIncrement(new VersionRequest
                {
                    ProductId = 1
                });

                calculatedVersion.Major.Should().Be(9);
                calculatedVersion.Minor.Should().Be(0);
                calculatedVersion.Build.Should().Be(0);
                calculatedVersion.Revision.Should().Be(0);
            }

            [Fact]
            public void WithMajor()
            {
                var version = new VersionSimple(8, 2, 0, 0);

                var calculatedVersion = version.CalculateIncrement(new VersionRequest
                {
                    ProductId = 1,
                    Major = 8
                });

                calculatedVersion.Major.Should().Be(8);
                calculatedVersion.Minor.Should().Be(3);
                calculatedVersion.Build.Should().Be(0);
                calculatedVersion.Revision.Should().Be(0);
            }

            [Fact]
            public void WithMajorMinor_VersionExists()
            {
                var version = new VersionSimple(8, 3, 0, 0);

                var calculatedVersion = version.CalculateIncrement(new VersionRequest
                {
                    ProductId = 1,
                    Major = 8,
                    Minor = 3
                });

                calculatedVersion.Major.Should().Be(8);
                calculatedVersion.Minor.Should().Be(3);
                calculatedVersion.Build.Should().Be(1);
                calculatedVersion.Revision.Should().Be(0);
            }
            [Fact]
            public void WithMajorMinor_DifferentVersion()
            {
                var version = new VersionSimple(8, 3, 0, 0);

                var calculatedVersion = version.CalculateIncrement(new VersionRequest
                {
                    ProductId = 1,
                    Major = 8,
                    Minor = 3
                });

                calculatedVersion.Major.Should().Be(8);
                calculatedVersion.Minor.Should().Be(3);
                calculatedVersion.Build.Should().Be(1);
                calculatedVersion.Revision.Should().Be(0);
            }

            [Fact]
            public void WithMinorArgumentException()
            {
                var version = new VersionSimple(8, 3, 0, 0);

                Action result = () => version.CalculateIncrement(new VersionRequest
                {
                    ProductId = 1,
                    Minor = 3
                });

                result.Should().Throw<ArgumentException>();
            }
        }
    }

    public class CreateIncrement
    {
        [Fact]
        public void WithProductId()
        {
            var version = new VersionSimple(8, 3, 0, 0);

            var calculatedVersion = version.CreateIncrement(new VersionRequest
            {
                ProductId = 1
            });

            calculatedVersion.Major.Should().Be(1);
            calculatedVersion.Minor.Should().Be(0);
            calculatedVersion.Build.Should().Be(0);
            calculatedVersion.Revision.Should().Be(0);
        }

        [Fact]
        public void WithMajor()
        {
            var version = new VersionSimple(8, 3, 0, 0);

            var calculatedVersion = version.CreateIncrement(new VersionRequest
            {
                ProductId = 1,
                Major = 8
            });

            calculatedVersion.Major.Should().Be(8);
            calculatedVersion.Minor.Should().Be(0);
            calculatedVersion.Build.Should().Be(0);
            calculatedVersion.Revision.Should().Be(0);
        }

        [Fact]
        public void WithMajorMinor()
        {
            var version = new VersionSimple(8, 3, 0, 0);

            var calculatedVersion = version.CreateIncrement(new VersionRequest
            {
                ProductId = 1,
                Major = 8,
                Minor = 1
            });

            calculatedVersion.Major.Should().Be(8);
            calculatedVersion.Minor.Should().Be(1);
            calculatedVersion.Build.Should().Be(0);
            calculatedVersion.Revision.Should().Be(0);
        }

        [Fact]
        public void WithMinorArgumentException()
        {
            var version = new VersionSimple(8, 3, 0, 0);

            Action calculatedVersion = () => version.CreateIncrement(new VersionRequest
            {
                ProductId = 1,
                Minor = 3
            });

            calculatedVersion.Should().Throw<ArgumentException>();
        }
    }
}
