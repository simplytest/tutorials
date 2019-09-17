using CalcServer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace IntegrationTests
{
    public class WebSerberHostHelper
    {
        public WebSerberHostHelper()
        { }

        public HttpClient GetClient()
        {
            TestServer testServer = StartupServer();
            HttpClient client = testServer.CreateClient();
            return client;
        }

        private TestServer StartupServer()
        {
            IWebHostBuilder webHostBuilder = WebHost.CreateDefaultBuilder(new string[] { })
                                .UseStartup<Startup>().UseEnvironment("Development")
                                .UseKestrel();

            TestServer testServer = new TestServer(webHostBuilder);
            return testServer;
        }
    }
}
