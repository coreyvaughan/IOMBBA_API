using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IOMBBA_Testing.Integration_Tests
{
    /// <summary>
    /// Integration test to test interaction of Competition API with the database.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class CompetitionAPI_IntegrationTests
    {
        /// <summary>
        /// Testing api/Competition/GetAllCompetitions endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Competitions()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Competition/GetCompetitions");

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
