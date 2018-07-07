using System.Net.Http;
using versioning_manager.api.Models;
using Flurl;
using Xunit;
using Flurl.Http;
using System;
using FluentAssertions;

namespace versioning_manager.api.tests.integration
{
    [Trait("Category", "Integration")]
    public class OrganizationControllerIntegrationTests : IClassFixture<TestServerFixture>
    {
        //private readonly HttpClient _client;
        private readonly Uri _baseUrl;

        public OrganizationControllerIntegrationTests(TestServerFixture fixture)
        {
            //_client = fixture.Client.HttpClient;
            _baseUrl = fixture.TestServer.BaseAddress;
        }

        [Fact]
        public async void post_then_get()
        {
            // Arrange
            var org = new Organization
            {
                Name = "Organization 1",
                Description = "Org 1 Description"
            };

            // Act
            //var postResponse = await _client.PostJsonAsync("/api/organization", org);
            var created = await $"{_baseUrl}api/organization".PostJsonAsync(org).ReceiveJson<Organization>();
            var fetched = await $"{_baseUrl}api/organization/{created.Id}".GetJsonAsync<Organization>();

            // Assert
            created.Name.Should().Be(org.Name);
            created.Id.Should().NotBe(null);
            fetched.Name.Should().Be(org.Name);
            fetched.Id.Should().Be(created.Id);
        }
    }
}