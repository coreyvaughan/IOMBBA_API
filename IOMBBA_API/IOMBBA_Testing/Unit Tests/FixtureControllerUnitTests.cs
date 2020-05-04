using IOMBBA_API.Controllers;
using Moq;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;


namespace IOMBBA_Testing.Unit_Tests
{
    /// <summary>
    /// Unit test to test the logic of the Fxiture controller class.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
    /// </summary>
    public class FixtureControllerUnitTests
    {
        // Mock match numbers.
        private static Guid matchNumber1 = Guid.NewGuid();
        private static Guid competitionId1 = Guid.NewGuid();

        // Mock team ids.
        private static Guid teamId1 = Guid.NewGuid();
        private static Guid teamId2 = Guid.NewGuid();

        // Mock member ids.
        private static int memberId1 = 1;
        private static int memberId2 = 1;
        private static int memberId3 = 3;
        private static int memberId4 = 4;
        private static int memberId5 = 5;

        // Mock the IFixture interface
        public Mock<IFixture> mockRepo = new Mock<IFixture>();


        #region Get
        [Fact]
        public void GetAllFixtureDetails_ReturnsAllFixtureDetails()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllFixtureDetailsAsync())
                .ReturnsAsync(MockFixtureDetailsList());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.GetAllFixtureDetailsAsync().Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<FixtureDetails>>(result);
            Assert.Equal(3, result.Count());
        }

        #endregion

        #region Get ById
        [Fact]
        public void GetFixtureDetails_ReturnsCorrectFixtureDetailsObject()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetFixtureDetails(matchNumber1))
                .ReturnsAsync(MockFixtureDetails());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.GetFixtureDetails(matchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FixtureDetails>(result);
            Assert.Equal(matchNumber1, result.FixtureObject.MatchNumber);
            // Compare each item in the list
            Assert.Equal(MockPlayersList()[0].MemberId, result.HomeTeamMembersList[0].MemberId);
            Assert.Equal(MockPlayersList()[0].FirstName, result.HomeTeamMembersList[0].FirstName);
            Assert.Equal(MockPlayersList()[0].Surname, result.HomeTeamMembersList[0].Surname);
            Assert.Equal(MockPlayersList()[0].ShirtNumber, result.HomeTeamMembersList[0].ShirtNumber);
            Assert.Equal(MockPlayersList()[0].Position, result.HomeTeamMembersList[0].Position);
            Assert.Equal(MockPlayersList()[0].IsPlayer, result.HomeTeamMembersList[0].IsPlayer);
            Assert.Equal(MockPlayersList()[0].IsCoach, result.HomeTeamMembersList[0].IsCoach);
            Assert.Equal(MockPlayersList()[0].IsOfficial, result.HomeTeamMembersList[0].IsOfficial);
            Assert.Equal(MockPlayersList()[0].IsTableOfficial, result.HomeTeamMembersList[0].IsTableOfficial);

            Assert.Equal(MockPlayersList()[1].MemberId, result.HomeTeamMembersList[1].MemberId);
            Assert.Equal(MockPlayersList()[1].FirstName, result.HomeTeamMembersList[1].FirstName);
            Assert.Equal(MockPlayersList()[1].Surname, result.HomeTeamMembersList[1].Surname);
            Assert.Equal(MockPlayersList()[1].ShirtNumber, result.HomeTeamMembersList[1].ShirtNumber);
            Assert.Equal(MockPlayersList()[1].Position, result.HomeTeamMembersList[1].Position);
            Assert.Equal(MockPlayersList()[1].IsPlayer, result.HomeTeamMembersList[1].IsPlayer);
            Assert.Equal(MockPlayersList()[1].IsCoach, result.HomeTeamMembersList[1].IsCoach);
            Assert.Equal(MockPlayersList()[1].IsOfficial, result.HomeTeamMembersList[1].IsOfficial);
            Assert.Equal(MockPlayersList()[1].IsTableOfficial, result.HomeTeamMembersList[1].IsTableOfficial);

            Assert.Equal(MockPlayersList()[2].MemberId, result.HomeTeamMembersList[2].MemberId);
            Assert.Equal(MockPlayersList()[2].FirstName, result.HomeTeamMembersList[2].FirstName);
            Assert.Equal(MockPlayersList()[2].Surname, result.HomeTeamMembersList[2].Surname);
            Assert.Equal(MockPlayersList()[2].ShirtNumber, result.HomeTeamMembersList[2].ShirtNumber);
            Assert.Equal(MockPlayersList()[2].Position, result.HomeTeamMembersList[2].Position);
            Assert.Equal(MockPlayersList()[2].IsPlayer, result.HomeTeamMembersList[2].IsPlayer);
            Assert.Equal(MockPlayersList()[2].IsCoach, result.HomeTeamMembersList[2].IsCoach);
            Assert.Equal(MockPlayersList()[2].IsOfficial, result.HomeTeamMembersList[2].IsOfficial);
            Assert.Equal(MockPlayersList()[2].IsTableOfficial, result.HomeTeamMembersList[2].IsTableOfficial);

            // Check the id values of the team objects.
            Assert.Equal(MockHomeTeamModel().TeamId, result.HomeTeamObject.TeamId);
            Assert.Equal(MockAwayTeamModel().TeamId, result.AwayTeamObject.TeamId);
        }


        [Fact]
        public void GetCurrentPeriod_ReturnsCorrectPeriodObject()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetCurrentPeriod(matchNumber1))
                .ReturnsAsync(MockPeriodModel());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.GetCurrentPeriod(matchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PeriodModel>(result);
            Assert.Equal(matchNumber1, result.GameNumberOfPeriod);
            Assert.Equal(10, result.PeriodDuration);
            Assert.Equal(4, result.PeriodNumber);
            Assert.Equal(6000, result.TimeRemaining);
        }


        [Fact]
        public void GetCurrentScores_ReturnsScoresObject()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetCurrentScores(matchNumber1))
                .ReturnsAsync(MockScoresObject());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.GetCurrentScores(matchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FixtureScoresObject>(result);
            Assert.Equal(100, result.HomeScore);
            Assert.Equal(69, result.AwayScore);
        }


        [Fact]
        public void GetOncourtPlayers_ReturnsPlayersLists()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetOncourtPlayers(matchNumber1))
                .ReturnsAsync(MockPlayersListsObject());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.GetOncourtPlayers(matchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PlayersListsObject>(result);
            Assert.Equal(MockPlayersList()[0].MemberId, result.HomeOncourtMembersList[0].MemberId);
            Assert.Equal(MockPlayersList()[1].MemberId, result.HomeOncourtMembersList[1].MemberId);
            Assert.Equal(MockPlayersList()[2].MemberId, result.HomeOncourtMembersList[2].MemberId);
            Assert.Equal(MockPlayersList()[3].MemberId, result.HomeOncourtMembersList[3].MemberId);

            Assert.Equal(MockPlayersList()[0].MemberId, result.HomeOffcourtMembersList[0].MemberId);
            Assert.Equal(MockPlayersList()[1].MemberId, result.HomeOffcourtMembersList[1].MemberId);
            Assert.Equal(MockPlayersList()[2].MemberId, result.HomeOffcourtMembersList[2].MemberId);
            Assert.Equal(MockPlayersList()[3].MemberId, result.HomeOffcourtMembersList[3].MemberId);

            Assert.Equal(MockPlayersList()[0].MemberId, result.AwayOncourtMembersList[0].MemberId);
            Assert.Equal(MockPlayersList()[1].MemberId, result.AwayOncourtMembersList[1].MemberId);
            Assert.Equal(MockPlayersList()[2].MemberId, result.AwayOncourtMembersList[2].MemberId);
            Assert.Equal(MockPlayersList()[3].MemberId, result.AwayOncourtMembersList[3].MemberId);

            Assert.Equal(MockPlayersList()[0].MemberId, result.AwayOffcourtMembersList[0].MemberId);
            Assert.Equal(MockPlayersList()[1].MemberId, result.AwayOffcourtMembersList[1].MemberId);
            Assert.Equal(MockPlayersList()[2].MemberId, result.AwayOffcourtMembersList[2].MemberId);
            Assert.Equal(MockPlayersList()[3].MemberId, result.AwayOffcourtMembersList[3].MemberId);
        }

        #endregion



        #region Add
        [Fact]
        public void AddNextPeriod_ReturnsPeriodModel()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.AddNextPeriod(matchNumber1))
                .ReturnsAsync(MockPeriodModel());
            var controller = new FixtureController(mockRepo.Object);

            // Act
            var result = controller.AddNextPeriod(matchNumber1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PeriodModel>(result);
            Assert.Equal(matchNumber1, result.GameNumberOfPeriod);
            Assert.Equal(10, result.PeriodDuration);
            Assert.Equal(4, result.PeriodNumber);
            Assert.Equal(6000, result.TimeRemaining);
        }
        #endregion





        /// <summary>
        /// Mock fixture scores object.
        /// </summary>
        /// <returns>A fixture scores object</returns>
        private FixtureScoresObject MockScoresObject()
        {
            return new FixtureScoresObject
            {
                HomeScore = 100,
                AwayScore = 69
            };
        }

        /// <summary>
        /// Mock fixture scores object.
        /// </summary>
        /// <returns>A fixture scores object</returns>
        private PlayersListsObject MockPlayersListsObject()
        {
            return new PlayersListsObject
            {
                HomeOncourtMembersList = MockPlayersList(),
                HomeOffcourtMembersList = MockPlayersList(),
                AwayOncourtMembersList = MockPlayersList(),
                AwayOffcourtMembersList = MockPlayersList()
            };
        }


        /// <summary>
        /// Mock period model.
        /// </summary>
        /// <returns>A period model</returns>
        private PeriodModel MockPeriodModel()
        {
            return new PeriodModel
            {
                PeriodId = Guid.NewGuid(),
                GameNumberOfPeriod = matchNumber1,
                PeriodDuration = 10,
                PeriodNumber = 4,
                TimeRemaining = 6000
            };
        }

        /// <summary>
        /// Mock list of fixture details objects.
        /// </summary>
        /// <returns>A list of fixture details objects</returns>
        private List<FixtureDetails> MockFixtureDetailsList()
        {
            return new List<FixtureDetails>
            {
                MockFixtureDetails(),
                MockFixtureDetails(),
                MockFixtureDetails()
            };
        }


        /// <summary>
        /// Mock fixture details object.
        /// </summary>
        /// <returns>A fixture details object</returns>
        private FixtureDetails MockFixtureDetails()
        {
            return new FixtureDetails
            {
                FixtureObject = MockFixtureModel(),
                HomeTeamMembersList = MockPlayersList(),
                AwayTeamMembersList = MockPlayersList(),
                HomeTeamObject = MockHomeTeamModel(),
                AwayTeamObject = MockAwayTeamModel(),
                CompetitionName = "Competition1",
                PeriodDuration = 10
            };
        }

        /// <summary>
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockHomeTeamModel()
        {
            return new TeamModel
            {
                TeamId = teamId1,
                TeamName = "Home",
                ShortTeamCode = "HOM",
                DominantKitColour = "ffffff"
            };
        }

        /// <summary>
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockAwayTeamModel()
        {
            return new TeamModel
            {
                TeamId = teamId2,
                TeamName = "Away",
                ShortTeamCode = "AWA",
                DominantKitColour = "000000"
            };
        }

        /// <summary>
        /// Mock list of member models.
        /// </summary>
        /// <returns>Member models list</returns>
        private List<MemberModel> MockPlayersList()
        {
            return new List<MemberModel>
            {
               new MemberModel
               {
                   MemberId = memberId1,
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
               },
               new MemberModel
               {
                   MemberId = memberId2,
                   FirstName = "Name2",
                   Surname = "Surname2",
                   ShirtNumber = "20",
                   IsCoach = false,
                   IsOfficial = false,
                   IsPlayer = true,
                   IsTableOfficial = false,
                   Position = "Guard",
                   RefQualifications = "",
                   TableQualifications = ""
               },
               new MemberModel
               {
                   MemberId = memberId3,
                   FirstName = "Name3",
                   Surname = "Surname3",
                   ShirtNumber = "30",
                   IsCoach = false,
                   IsOfficial = false,
                   IsPlayer = true,
                   IsTableOfficial = false,
                   Position = "Guard",
                   RefQualifications = "",
                   TableQualifications = ""
               },
               new MemberModel
               {
                   MemberId = memberId4,
                   FirstName = "Name4",
                   Surname = "Surname4",
                   ShirtNumber = "40",
                   IsCoach = false,
                   IsOfficial = false,
                   IsPlayer = true,
                   IsTableOfficial = false,
                   Position = "Guard",
                   RefQualifications = "",
                   TableQualifications = ""
               },
               new MemberModel
               {
                   MemberId = memberId5,
                   FirstName = "Name5",
                   Surname = "Surname5",
                   ShirtNumber = "50",
                   IsCoach = false,
                   IsOfficial = false,
                   IsPlayer = true,
                   IsTableOfficial = false,
                   Position = "Guard",
                   RefQualifications = "",
                   TableQualifications = ""
               },
            };
        }


        /// <summary>
        /// Mock fixture model.
        /// </summary>
        /// <returns>A fixture model</returns>
        private FixtureModel MockFixtureModel()
        {
            return new FixtureModel
            {
                MatchNumber = matchNumber1,
                CompetitionId = competitionId1,
                CourtVenue = "Venue1",
                NumberOfPeriods = 4,
                HomeTeamId = teamId1,
                AwayTeamId = teamId2,
                FixtureStartTime = new DateTime()
            };
        }
    }
}
