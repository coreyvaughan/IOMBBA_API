using Newtonsoft.Json;
using Objects.Objects;
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
    /// Integration test to test interaction of Fixture API with the database.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class FixtureAPI_IntegrationTests
    {
        private static Guid existingFixtureId1 = new Guid("5771DF03-9EC5-4BA9-B04E-E23C32D2BBF0");
        private static Guid existingFixtureId2 = new Guid("725da0e1-6dec-499a-9ff1-4f03a659cd0e");
        private static Guid existingFixtureId3 = new Guid("1ecb7b77-0eed-4d16-ba0b-ab08f6be37c5");

        private static Guid existingCompetitionId = new Guid("45677a49-e49f-4401-b957-ce6c4323929e");
        private static Guid existingPeriodId = new Guid("4f8922e8-e5d0-4cfc-b539-24c87c02596b");


        private static Guid existingTeamId1 = new Guid("a69bb43d-c8ea-44b4-b546-44e63147be40");
        private static Guid existingTeamId2 = new Guid("3e7173fc-c12c-4d04-b24d-b3edeadd727f");

        private static int memberId1 = 1;
        private static int memberId2 = 1;
        private static int memberId3 = 3;
        private static int memberId4 = 4;
        private static int memberId5 = 5;
        private static int memberId6 = 6;
        private static int memberId7 = 7;
        private static int memberId8 = 8;
        private static int memberId9 = 9;
        private static int memberId10 = 10;

        private static int timeRemaining = 5650;


        /// <summary>
        /// Testing api/Fixture/SaveTimeRemaining endpoint.
        /// </summary>
        [Fact]
        public async Task Save_Time_Remaining()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PutAsync("api/Fixture/SaveTimeRemaining/" + existingPeriodId, new StringContent(
                    JsonConvert.SerializeObject(timeRemaining), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Fixture/GetFixtureDetails endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Fixture_Details()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/GetFixtureDetails");

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Fixture/GetFixtureDetails/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Fixture_Details_By_Id()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/GetFixtureDetails/" + existingFixtureId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Fixture/GetCurrentPeriod/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Current_Period()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/GetCurrentPeriod/" + existingFixtureId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Fixture/AddNextPeriod/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Next_Period()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/AddNextPeriod/" + existingFixtureId3);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Fixture/GetCurrentScores/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Current_Scores()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/GetCurrentScores/" + existingFixtureId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/Fixture/GetCurrentOncourtPlayers/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_Current_OncourtPlayers()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/Fixture/GetOncourtPlayers/" + existingFixtureId1);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Fixture/AddFixture/ endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Fixture()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/Fixture/AddFixture/", new StringContent(
                    JsonConvert.SerializeObject(MockFixtureObject()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        /// <summary>
        /// Testing api/Fixture/AddFixture/ endpoint.
        /// </summary>
        [Fact]
        public async Task Delete_Fixture()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.DeleteAsync("api/Fixture/DeleteFixture/" + existingFixtureId2);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }




        /// <summary>
        /// Mock fixture object.
        /// </summary>
        /// <returns>A fixture  object</returns>
        private FixtureObject MockFixtureObject()
        {
            return new FixtureObject
            {
                //MatchNumber = existingFixtureId,
                CompetitionId = existingCompetitionId,
                CourtVenue = "Venue1",
                NumberOfPeriods = 4,
                PeriodDuration = 10,
                HomeTeamId = existingTeamId1,
                AwayTeamId = existingTeamId2,
                HomeStartingFive = new List<int> { memberId1, memberId2, memberId3, memberId4, memberId5 },
                AwayStartingFive = new List<int> { memberId6, memberId7, memberId8, memberId9, memberId10 },
                FixtureStartTime = DateTime.Now
            };
        }
    }
}
