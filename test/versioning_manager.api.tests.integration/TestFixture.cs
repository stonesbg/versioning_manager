using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http;
using Xunit;
using Flurl.Http;
using Flurl.Http.Configuration;

namespace versioning_manager.api.tests.integration
{
    //public class TestServerFixture // : IDisposable
    //{
    //    //public TestServer TestServer { get; }
    //    //public IFlurlClient Client { get; }

    //    //public TestServerFixture()
    //    //{
    //    //    TestServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
    //    //    //Client = TestServer.CreateClient();
    //    //    Client = TestServer.CreateFlurlClient();
    //    //}

    //    //public void Dispose()
    //    //{
    //    //    TestServer.Dispose();
    //    //    Client.Dispose();
    //    //}



    //}

    public class TestServerFixture
    {
        public TestServer TestServer { get; }
        public TestServerFixture()
        {
            TestServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            FlurlHttp.Configure(settings => settings.HttpClientFactory = new TestingClientFactory(TestServer));
        }
    }

    public class TestingClientFactory : DefaultHttpClientFactory
    {
        TestServer _server;
        public TestingClientFactory(TestServer server)
        {
            _server = server;
        }

        public override HttpClient CreateHttpClient(HttpMessageHandler handler)
        {
            HttpClient client = _server.CreateClient();

            return client;
        }
    }

    public static class TestServerExtensions
    {
        public static IFlurlClient CreateFlurlClient(this TestServer server) =>
            new FlurlClient(server.CreateClient());
    }
}
