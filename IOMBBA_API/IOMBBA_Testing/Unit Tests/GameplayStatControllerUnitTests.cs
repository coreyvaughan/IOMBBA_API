using IOMBBA_API.Controllers;
using Moq;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace IOMBBA_Testing.Unit_Tests
{
    /// <summary>
    /// Unit test to test the logic of the GameplayStat controller class.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
    /// </summary>
    public class GameplayStatControllerUnitTests
    {
        // Mock player ids.
        private static int mockPlayerId1 = 1;
        private static int mockPlayerId2 = 2;
        private static int mockPlayerId3 = 3;
        private static int mockPlayerId4 = 4;
        private static int mockPlayerId5 = 5;
        private static int mockPlayerId6 = 6;

        // Mock period id.
        private static Guid mockPeriodId = Guid.NewGuid();

        // Mock GameplayStat ids.
        private static Guid mockStatId1 = Guid.NewGuid();
        private static Guid mockStatId2 = Guid.NewGuid();
        private static Guid mockStatId3 = Guid.NewGuid();
        private static Guid mockStatId4 = Guid.NewGuid();
        private static Guid mockStatId5 = Guid.NewGuid();
        private static Guid mockStatId6 = Guid.NewGuid();

        // Mock team id.
        private static Guid mockTeamId1 = Guid.NewGuid();

        // Mock match number.
        private static Guid mockMatchNumber1 = Guid.NewGuid();


        // Mock the IGameplayStat interface
        public Mock<IGameplayStat> mockRepo = new Mock<IGameplayStat>();


        #region Get ById

        [Fact]
        public void GetAllPlayerStats_ReturnsGameplayStatList()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllPlayerStats(mockPlayerId1))
                .ReturnsAsync(MockPeriodGameplayStatObjectList());
            var controller = new GameplayStatController(mockRepo.Object);

            // Act
            var result = controller.GetAllPlayerStats(mockPlayerId1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<GameplayStatObject>>(result);
            Assert.Equal(6, result.Count());
        }

        [Fact]
        public void GetAllGameplayStats_ReturnsGameplayStatList()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllGameplayStats(mockMatchNumber1))
                .ReturnsAsync(MockFixtureGameplayStatObjectList());
            var controller = new GameplayStatController(mockRepo.Object);

            // Act
            var result = controller.GetAllGameplayStats(mockMatchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<List<GameplayStatObject>>>(result);
            Assert.Equal(4, result.Count());
            Assert.Equal(6, result[0].Count());
            Assert.Equal(6, result[1].Count());
            Assert.Equal(6, result[2].Count());
            Assert.Equal(6, result[3].Count());
        }

        #endregion


        #region Add

        [Fact]
        public void AddGeneralStat_ReturnsCorrectStatModel()
        {
            // Arrange 
            var generalStatModel = MockGeneralGameplayStatModel();
            mockRepo.Setup(repo => repo.AddGeneralStat(generalStatModel))
                .ReturnsAsync(generalStatModel);

            var controller = new GameplayStatController(mockRepo.Object);

            // Act
            var result = controller.AddGeneralStat(generalStatModel).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GameplayStatModel>(result);
            Assert.True(result.IsPlaying);
            Assert.Equal(generalStatModel.TimeOfStat, result.TimeOfStat);
            Assert.Equal(generalStatModel.StatCategory, result.StatCategory);
            Assert.Equal(mockPeriodId, result.PeriodId);
        }


        [Fact]
        public void AddSubstitution_ReturnsListOfStatIds()
        {
            // Arrange 
            GameplayStatDetails statDetailsObject = MockGameplayStatDetails();
            List<Guid> statIds = MockStatIdsList();
            mockRepo.Setup(repo => repo.AddSubstitution(statDetailsObject))
                .ReturnsAsync(statIds);

            var controller = new GameplayStatController(mockRepo.Object);

            // Act
            var result = controller.AddSubstitution(statDetailsObject).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Guid>>(result);
        }


        [Fact]
        public void AddFoul_ReturnsGameplayStatDetails()
        {
            // Arrange 
            var mockStatDetails = MockGameplayStatDetails();
            mockRepo.Setup(repo => repo.AddFoul(mockStatDetails))
                .ReturnsAsync(mockStatDetails);
            var controller = new GameplayStatController(mockRepo.Object);

            // Act
            var result = controller.AddFoul(mockStatDetails).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GameplayStatDetails>(result);
        }

        #endregion


        /// <summary>
        /// Mock gameplay stats list.
        /// </summary>
        /// <returns>A list of gameplay stat models</returns>
        private GameplayStatObject MockGameplayStatObject()
        {
            return new GameplayStatObject
            {
                Stat = MockGameplayStatModel(),
                Shot = MockShotModel(),
                Foul = MockFoulModel(),
                Member = MockMemberModel1(),
                Team = MockTeamModel()
            };
        }




        /// <summary>
        /// Mock list of gameplay stats lists for a fixture.
        /// </summary>
        /// <returns>A list of gameplay stat object lists for a fixture</returns>
        private List<List<GameplayStatObject>> MockFixtureGameplayStatObjectList()
        {
            return new List<List<GameplayStatObject>>
            {
                new List<GameplayStatObject>
                {
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject()
                },
                new List<GameplayStatObject>
                {
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject()
                },
                new List<GameplayStatObject>
                {
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject()
                },
                new List<GameplayStatObject>
                {
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject(),
                    MockGameplayStatObject()
                },

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
        /// Mock stat Ids list
        /// </summary>
        /// <returns>A list of guids</returns>
        private List<Guid> MockStatIdsList()
        {
            return new List<Guid>
            {
                mockStatId1,
                mockStatId2,
                mockStatId3,
                mockStatId4,
                mockStatId5,
                mockStatId6,
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
        /// Mock gameplay stats list.
        /// </summary>
        /// <returns>A list of gameplay stat models</returns>
        private List<GameplayStatObject> MockPeriodGameplayStatObjectList()
        {
            return new List<GameplayStatObject>
            {
                MockGameplayStatObject(),
                MockGameplayStatObject(),
                MockGameplayStatObject(),
                MockGameplayStatObject(),
                MockGameplayStatObject(),
                MockGameplayStatObject()
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
                Order = 1,
                PeriodId = mockPeriodId,
                StatCategory = "shot",
                StatMemberId = mockPlayerId1,
                TimeOfStat = 5025
            };
        }

        /// <summary>
        /// Mock general gameplay stat model.
        /// </summary>
        /// <returns>A gameplay stat model</returns>
        private GameplayStatModel MockGeneralGameplayStatModel()
        {
            return new GameplayStatModel
            {
                StatId = mockStatId2,
                IsPlaying = true,
                Order = 2,
                PeriodId = mockPeriodId,
                StatCategory = "turnover",
                StatMemberId = mockPlayerId1,
                TimeOfStat = 5000
            };
        }


        /// <summary>
        /// Mock member model
        /// </summary>
        /// <returns>A mock member model</returns>
        private MemberModel MockMemberModel1()
        {
            return new MemberModel
            {
                MemberId = mockPlayerId1,
                FirstName = "Name1",
                Surname = "Surname1",
                ShirtNumber = "10",
                IsCoach = false,
                IsOfficial = false,
                IsPlayer = true,
                IsTableOfficial = false,
                Position = "Guard",
                RefQualifications = "",
                TableQualifications = ""
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
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockTeamModel()
        {
            return new TeamModel
            {
                TeamId = mockTeamId1,
                TeamName = "Team1",
                ShortTeamCode = "TM1",
                DominantKitColour = "ffffff"
            };
        }
    }
}
