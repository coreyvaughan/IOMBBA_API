using Newtonsoft.Json;
using Objects.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IOMBBA_Testing.Integration_Tests
{
    /// <summary>
    /// Integration test to test interaction of Team API with the database.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class TeamAPI_IntegrationTests
    {
        private static Guid existingTeamId = new Guid("a69bb43d-c8ea-44b4-b546-44e63147be40");

        /// <summary>
        /// Testing api/Team/GetAllTeams endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Teams()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Team/GetAllTeams");

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Team/GetTeamMembers/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Team_Members()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Team/GetTeamMembers/" + existingTeamId);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Team/GetTeam/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Team_By_Id()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Team/GetTeam/" + existingTeamId);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Team/EditTeam/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Edit_Team()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PutAsync("api/Team/EditTeam/" + existingTeamId, new StringContent(
                    JsonConvert.SerializeObject(MockUpdatedTeamModel()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Team/AddTeam endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Team()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/Team/AddTeam/", new StringContent(
                    JsonConvert.SerializeObject(MockTeamModel()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Team/DeleteTeam/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Delete_Team()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.DeleteAsync("api/Team/DeleteTeam/" + existingTeamId);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// New team model object
        /// </summary>
        /// <returns>A team model</returns>
        private TeamModel MockTeamModel()
        {
            return new TeamModel
            {
                TeamName = "New Team",
                ShortTeamCode = "NEW",
                DominantKitColour = "ffffff"
            };
        }


        /// <summary>
        /// Existing Team model with updated values
        /// </summary>
        /// <returns>A team model</returns>
        private TeamModel MockUpdatedTeamModel()
        {
            return new TeamModel
            {
                TeamId = existingTeamId,
                TeamName = "Updated Team Name",
                ShortTeamCode = "AAA",
                DominantKitColour = "ff00ff"
            };
        }

    }
}
