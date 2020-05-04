using IOMBBA_API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace IOMBBA_Testing.Integration_Tests
{
    /// <summary>
    /// Mock test server client to submit API requests to the application.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class MockTestServer : IDisposable
    {
        private TestServer server;
        public HttpClient Client { get; private set; }
        public MockTestServer()
        {
            // Arrange
            server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                .UseSetting("ConnectionStrings:DevConnection", 
                "Server=(LocalDb)\\Local;Database=IOMBBA_Db;Integrated Security=true;MultipleActiveResultSets=True;"));

            Client = server.CreateClient();
        }


        /// <summary>
        /// Dispose of the client and server if they are not null.
        /// </summary>
        public void Dispose()
        {
            server?.Dispose();
            Client?.Dispose();
        }
    }
}
