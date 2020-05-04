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
    /// Unit test to test the logic of the Team controller class.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
    /// </summary>
    public class TeamControllerUnitTests
    {
        // Mock TeamId Guids
        public static Guid mockTeamId1 = Guid.NewGuid();
        public static Guid mockTeamId2 = Guid.NewGuid();
        public static Guid mockTeamId3 = Guid.NewGuid();

        // Mock the ITeam interface
        public Mock<ITeam> mockRepo = new Mock<ITeam>();



        #region Get All
        [Fact]
        public void GetAllTeams_ReturnsAllTeams()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllTeams())
                .Returns(MockTeams());
            var controller = new TeamController(mockRepo.Object);

            // Act
            var result = controller.GetAllTeams();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<TeamModel>>(result);
            Assert.Equal(3, result.Count());
        }
        #endregion

        #region Get ById

        // Could add a check to see if the members themselves are the correct members from the list.
        [Fact]
        public void GetTeamMembers_ReturnsAllCorrectTeamMembers()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetTeamMembers(mockTeamId1))
                .Returns(MockTeamObject());
            var controller = new TeamController(mockRepo.Object);

            // Act
            var result = controller.GetTeamMembers(mockTeamId1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TeamObject>(result);
            Assert.Equal(3, result.MembersList.Count());
        }

        [Fact]
        public void GetTeamById_ReturnsCorrectTeam()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetTeam(mockTeamId1))
                .ReturnsAsync(MockTeamModel1());
            var controller = new TeamController(mockRepo.Object);

            // Act
            var result = controller.GetTeam(mockTeamId1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TeamModel>(result);
            Assert.Equal("Team1", result.TeamName);
            Assert.Equal("TM1", result.ShortTeamCode);
            Assert.Equal("ffffff", result.DominantKitColour);
        }

        #endregion


        #region Edit

        // DO THIS PROPERLY AT THE END.
        #endregion

        #region Add

        [Fact]
        public void AddTeam_ValidData_ReturnsUpdatedRecord()
        {
            // Arrange
            var newTeam = MockTeamModel1();
            mockRepo.Setup(repo => repo.AddTeam(newTeam))
                .ReturnsAsync(newTeam);
            var controller = new TeamController(mockRepo.Object);

            //Act
            var result = controller.AddTeam(newTeam);

            //Assert
            Assert.NotNull(result.Result);
            Assert.IsType<TeamModel>(result.Result);
            Assert.Equal(newTeam.TeamName, (result.Result as TeamModel).TeamName);
            Assert.Equal(newTeam.ShortTeamCode, (result.Result as TeamModel).ShortTeamCode);
            Assert.Equal(newTeam.DominantKitColour, (result.Result as TeamModel).DominantKitColour);
        }
        #endregion


        // TEst tge delete method here ----------------------


        /// <summary>
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockTeamModel1()
        {
            return new TeamModel
            {
                TeamId = mockTeamId1,
                TeamName = "Team1",
                ShortTeamCode = "TM1",
                DominantKitColour = "ffffff"
            };
        }

        /// <summary>
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockTeamModel2()
        {
            return new TeamModel
            {
                TeamId = mockTeamId1,
                TeamName = "Team2",
                ShortTeamCode = "TM2",
                DominantKitColour = "000000"
            };
        }

        /// <summary>
        /// Mock team model
        /// </summary>
        /// <returns>A Team Model</returns>
        private TeamModel MockTeamModel3()
        {
            return new TeamModel
            {
                TeamId = mockTeamId1,
                TeamName = "Team3",
                ShortTeamCode = "TM3",
                DominantKitColour = "000fff"
            };
        }

        /// <summary>
        /// Mock team data.
        /// </summary>
        /// <returns>A list of Team models</returns>
        private List<TeamModel> MockTeams()
        {
            return new List<TeamModel>
            {
               MockTeamModel1(),
               MockTeamModel2(),
               MockTeamModel3()
            };
        }

        /// <summary>
        /// Mock member model
        /// </summary>
        /// <returns>A Member Model</returns>
        private MemberModel MockMemberModel1()
        {
            return new MemberModel
            {
                MemberId = 1,
                FirstName = "Name1",
                Surname = "Surname1",
                ShirtNumber = "20",
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
        /// Mock member model
        /// </summary>
        /// <returns>A Member Model</returns>
        private MemberModel MockMemberModel2()
        {
            return new MemberModel
            {
                MemberId = 2,
                FirstName = "Name2",
                Surname = "Surname2",
                ShirtNumber = "",
                IsCoach = true,
                IsOfficial = true,
                IsPlayer = false,
                IsTableOfficial = false,
                Position = "",
                RefQualifications = "Level 1",
                TableQualifications = ""
            };
        }

        /// <summary>
        /// Mock member model
        /// </summary>
        /// <returns>A Member Model</returns>
        private MemberModel MockMemberModel3()
        {
            return new MemberModel
            {
                MemberId = 3,
                FirstName = "Name3",
                Surname = "Surname3",
                ShirtNumber = "10",
                IsCoach = false,
                IsOfficial = false,
                IsPlayer = true,
                IsTableOfficial = false,
                Position = "Guard",
                RefQualifications = "",
                TableQualifications = "Table qual 1"
            };
        }


        /// <summary>
        /// Mock member data.
        /// </summary>
        /// <returns>A list of Member models</returns>
        private List<MemberModel> MockMembers()
        {
            return new List<MemberModel>
            {
                MockMemberModel1(),
                MockMemberModel2(),
                MockMemberModel3(),            
            };
        }


        /// <summary>
        /// A mock team object
        /// </summary>
        /// <returns>A TeamObject</returns>
        private TeamObject MockTeamObject()
        {
            return new TeamObject
            {
                Team = MockTeamModel1(),
                MembersList = MockMembers()
            };
        }


        /// <summary>
        /// Mock MemberTeam records.
        /// </summary>
        /// <returns>A list of MemberTeam models</returns>
        private List<MemberTeamModel> MockMemberTeams()
        {
            return new List<MemberTeamModel>
            {
                new MemberTeamModel
                {
                        MemberTeamId = Guid.NewGuid(),
                        MemberOfTeam = 1,
                        TeamOfMember = mockTeamId1,
                        DateJoinedTeam = DateTime.UtcNow,
                        DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                },
                new MemberTeamModel
                {
                        MemberTeamId = Guid.NewGuid(),
                        MemberOfTeam = 2,
                        TeamOfMember = mockTeamId1,
                        DateJoinedTeam = DateTime.UtcNow,
                        DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                },
                new MemberTeamModel
                {
                        MemberTeamId = Guid.NewGuid(),
                        MemberOfTeam = 2,
                        TeamOfMember = mockTeamId1,
                        DateJoinedTeam = DateTime.UtcNow,
                        DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                }
            };
        }
    }
}
