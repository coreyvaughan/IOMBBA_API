using Newtonsoft.Json;
using Objects.Models;
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
    /// Integration test to test interaction of GameplayStat API with the database.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1
    /// </summary>
    public class GameplayStatAPI_IntegrationTests
    {
        private static Guid existingFixtureId = new Guid("5771DF03-9EC5-4BA9-B04E-E23C32D2BBF0");
        private static Guid existingPeriodId = new Guid("4f8922e8-e5d0-4cfc-b539-24c87c02596b");
        private static Guid existingSubstitutionId1 = new Guid("EA71E883-0F07-4379-945F-369CA08F1695");
        private static Guid existingSubstitutionId2 = new Guid("D533AD25-95FA-4C90-B381-64A569929F45");
        private static Guid existingSubstitutionId3= new Guid("856092D6-1370-4371-83A1-9002779EFA06");
        private static Guid existingSubstitutionId4 = new Guid("D161A017-D0A5-4C1A-9224-9EE1A3EB1CC3");
        private static Guid existingSubstitutionId5 = new Guid("019B8F40-6DFC-44EC-87EC-AE2B12F8BD05");
        private static Guid existingSubstitutionId6 = new Guid("9875389A-87E7-4738-9262-AF54B96AA04A");
        private static Guid existingSubstitutionId7 = new Guid("65B77A1C-F6EE-4416-982D-BE7959484CBB");

        private static Guid existingShotStatId = new Guid("2409C2D1-6583-46E2-8D25-58D3BA7838C8");

        private static Guid mockStatId1 = Guid.NewGuid();
        private static Guid mockStatId2 = Guid.NewGuid();


        private static int mockPlayerId1 = 1;
        private static int mockPlayerId2 = 2;
        private static int mockPlayerId3 = 3;
        private static int mockPlayerId4 = 4;
        private static int mockPlayerId5 = 5;
        private static int mockPlayerId6 = 6;

        /// <summary>
        /// Testing api/GameplayStat/AddShot endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Shot()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/GameplayStat/AddShot", new StringContent(
                    JsonConvert.SerializeObject(MockGameplayStatDetails()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/AddFoul endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Foul()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/GameplayStat/AddFoul", new StringContent(
                    JsonConvert.SerializeObject(MockGameplayStatDetails()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }



        /// <summary>
        /// Testing api/GameplayStat/AddSubstitutions endpoint.
        /// </summary>
        [Fact]
        public async Task Add_Substitutions()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/GameplayStat/AddSubstitutions", new StringContent(
                    JsonConvert.SerializeObject(MockGameplayStatDetails()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/DeleteSubstitutions endpoint.
        /// </summary>
        [Fact]
        public async Task Delete_Substitutions()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.DeleteAsync("api/GameplayStat/DeleteSubstitutions/" + MockStatIdsList());

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/DeleteShot endpoint.
        /// </summary>
        [Fact]
        public async Task Delete_Shot()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.DeleteAsync("api/GameplayStat/DeleteShot/" + existingShotStatId);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/AddGeneralStat endpoint.
        /// </summary>
        [Fact]
        public async Task Add_General_Stat()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.PostAsync("api/GameplayStat/AddGeneralStat/", new StringContent(
                    JsonConvert.SerializeObject(MockGeneralStat()), Encoding.UTF8, "application/json"));

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/GetAllPlayerStats/{id} endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Player_Stats()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/GameplayStat/GetAllPlayerStats/" + mockPlayerId2);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }


        /// <summary>
        /// Testing api/GameplayStat/GetAllGameplayStats endpoint.
        /// </summary>
        [Fact]
        public async Task Get_All_Gameplay_Stats()
        {
            using (var client = new MockTestServer().Client)
            {
                // Act
                var response = await client.GetAsync("api/GameplayStat/GetAllGameplayStats/" + existingFixtureId);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }




        /// <summary>
        /// Mock gameplay stat details object for a substitution.
        /// </summary>
        /// <returns>A gameplaystat details object</returns>
        private GameplayStatDetails MockSubstitutionGameplayStatDetails()
        {
            return new GameplayStatDetails
            {
                Stat = MockSubstitutionGameplayStatModel(),
                Shot = MockShotModel(),
                GroupSubstitution = MockGroupSubstitution(),
                Foul = MockFoulModel()
            };
        }

        /// <summary>
        /// Mock gameplay stat details object.
        /// </summary>
        /// <returns>A gameplaystat details object</returns>
        private GameplayStatDetails MockGameplayStatDetails()
        {
            return new GameplayStatDetails
            {
                Stat = MockGameplayStatModel(),
                Shot = MockShotModel(),
                GroupSubstitution = MockGroupSubstitution(),
                Foul = MockFoulModel()
            };
        }


        /// <summary>
        /// Mock gameplay stat model.
        /// </summary>
        /// <returns>A gameplay stat model</returns>
        private GameplayStatModel MockGameplayStatModel()
        {
            return new GameplayStatModel
            {
                StatId = mockStatId1,
                IsPlaying = true,
                PeriodId = existingPeriodId,
                StatCategory = "shot",
                StatMemberId = mockPlayerId1,
                TimeOfStat = 5025
            };
        }

        /// <summary>
        /// Mock gameplay stat model.
        /// </summary>
        /// <returns>A gameplay stat model</returns>
        private GameplayStatModel MockSubstitutionGameplayStatModel()
        {
            return new GameplayStatModel
            {
                StatId = mockStatId2,
                IsPlaying = true,
                PeriodId = existingPeriodId,
                StatCategory = "substitution",
                StatMemberId = mockPlayerId1,
                TimeOfStat = 5025
            };
        }


        /// <summary>
        /// Mock general gameplay stat model.
        /// </summary>
        /// <returns>A general gameplay stat model</returns>
        private GameplayStatModel MockGeneralStat()
        {
            return new GameplayStatModel
            {
                IsPlaying = true,
                PeriodId = existingPeriodId,
                StatCategory = "turnover",
                StatMemberId = mockPlayerId1,
                TimeOfStat = 5025
            };
        }

        /// <summary>
        /// Mock substitution object.
        /// </summary>
        /// <returns>A gameplaystat details object</returns>
        private GroupSubstitution MockGroupSubstitution()
        {
            return new GroupSubstitution
            {
                HomePlayersOn = new int[]
                {
                    mockPlayerId1,
                    mockPlayerId2
                },
                HomePlayersOff = new int[]
                {
                    mockPlayerId3,
                    mockPlayerId4
                },
                AwayPlayersOn = new int[]
                {
                    mockPlayerId5
                },
                AwayPlayersOff = new int[]
                {
                    mockPlayerId6
                }
            };
        }

        /// <summary>
        /// Mock shot model.
        /// </summary>
        /// <returns>A Shot model</returns>
        private ShotModel MockShotModel()
        {
            return new ShotModel
            {
                ShotId = Guid.NewGuid(),
                FreeThrow = false,
                ShotPoints = 2,
                ShotStatId = mockStatId1,
                XPosition = 0,
                YPosition = 0,
                ShotType = ""
            };
        }

        /// <summary>
        /// Mock foul model.
        /// </summary>
        /// <returns>A Foul model</returns>
        private FoulModel MockFoulModel()
        {
            return new FoulModel
            {
                FoulId = Guid.NewGuid(),
                FoulStatId = mockStatId1,
                FoulMinute = 8,
                FoulType = "shooting",
                FreeThrowsAwarded = 0
            };
        }



        /// <summary>
        /// Mock stat Ids list
        /// </summary>
        /// <returns>A list of guids</returns>
        private List<Guid> MockStatIdsList()
        {
            return new List<Guid>
            {
                existingSubstitutionId1,
                existingSubstitutionId2,
                existingSubstitutionId3,
                existingSubstitutionId4,
                existingSubstitutionId5,
                existingSubstitutionId6,
                existingSubstitutionId7
            };
        }
    }
}
