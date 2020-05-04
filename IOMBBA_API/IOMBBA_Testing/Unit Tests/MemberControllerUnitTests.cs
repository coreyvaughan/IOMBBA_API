using IOMBBA_API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IOMBBA_Testing.Unit_Tests
{
    /// <summary>
    /// Unit test to test the logic of the Member controller class.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
    /// </summary>
    public class MemberControllerUnitTests
    {
        // Mock TeamId Guids
        public static Guid mockTeamId1 = new Guid("a69bb43d-c8ea-44b4-b546-44e63147be40");
        public static Guid mockTeamId2 = new Guid("3e7173fc-c12c-4d04-b24d-b3edeadd727f");
        public static Guid mockTeamId3 = new Guid("44746c76-7411-4968-9cef-aeb96bfcd463");

        // Mock MemberId
        public static int mockMemberId = 1;

        // Mock the IMember interface
        public Mock<IMember> mockRepo = new Mock<IMember>();

        #region Get All
        [Fact]
        public void GetAllMembers_ReturnsAllMembers()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllMembers())
                .Returns(MockMembers());
            var controller = new MemberController(mockRepo.Object);

            // Act
            var result = controller.GetAllMembers();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MemberModel>>(result);
            Assert.Equal(3, result.Count());
        }


        [Fact]
        public void GetAllMemberDetails_ReturnsAListOfAllMemberDetails()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllMemberDetails())
                .Returns(MockMemberDetails());
            var controller = new MemberController(mockRepo.Object);

            // Act
            var result = controller.GetAllMemberDetails();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MemberDetailsObject>>(result);
            Assert.Equal(3, result.Count());
        }
        #endregion

        #region Get ById
        [Fact]
        public void GetMemberDetailsById_ValidId_ReturnsCorrectMemberDetailsObject()
        {
            // Arrange
            var memberId = 1;
            MemberDetailsObject memberDetailsObject = MockMemberDetails().FirstOrDefault(m => m.Member.MemberId == memberId);
            mockRepo.Setup(repo => repo.GetMemberDetails(1))
                .Returns(memberDetailsObject);
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.GetMemberDetails(memberId);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<MemberDetailsObject>(result);
            Assert.Equal(memberId, (result as MemberDetailsObject).Member.MemberId);
            Assert.Equal(memberDetailsObject.Member.FirstName, (result as MemberDetailsObject).Member.FirstName);
            Assert.Equal(memberDetailsObject.Member.Surname, (result as MemberDetailsObject).Member.Surname);
            Assert.Equal(memberDetailsObject.Member.ShirtNumber, (result as MemberDetailsObject).Member.ShirtNumber);
            Assert.Equal(memberDetailsObject.Member.Position, (result as MemberDetailsObject).Member.Position);
            Assert.Equal(memberDetailsObject.Member.IsPlayer, (result as MemberDetailsObject).Member.IsPlayer);
            Assert.Equal(memberDetailsObject.Member.IsCoach, (result as MemberDetailsObject).Member.IsCoach);
            Assert.Equal(memberDetailsObject.Member.IsOfficial, (result as MemberDetailsObject).Member.IsOfficial);
            Assert.Equal(memberDetailsObject.Member.IsTableOfficial, (result as MemberDetailsObject).Member.IsTableOfficial);
            Assert.Equal(memberDetailsObject.Member.RefQualifications, (result as MemberDetailsObject).Member.RefQualifications);
            Assert.Equal(memberDetailsObject.Member.TableQualifications, (result as MemberDetailsObject).Member.TableQualifications);
            Assert.Equal(memberDetailsObject.Member.IsDeleted, (result as MemberDetailsObject).Member.IsDeleted);

            Assert.Equal(memberDetailsObject.Team.TeamId, (result as MemberDetailsObject).Team.TeamId);
            Assert.Equal(memberDetailsObject.Team.TeamName, (result as MemberDetailsObject).Team.TeamName);
            Assert.Equal(memberDetailsObject.Team.ShortTeamCode, (result as MemberDetailsObject).Team.ShortTeamCode);
            Assert.Equal(memberDetailsObject.Team.DominantKitColour, (result as MemberDetailsObject).Team.DominantKitColour);
        }

        [Fact]
        public void GetMemberDetailsById_InvalidId_ReturnsNull()
        {
            // Arrange
            var nonMemberId = 100;
            mockRepo.Setup(repo => repo.GetMemberDetails(1))
                .Returns(MockMemberDetails().FirstOrDefault(m => m.Member.MemberId == nonMemberId));
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.GetMemberDetails(nonMemberId);

            //Assert
            Assert.Null(result);
        }


        [Fact]
        public void GetMemberById_ValidId_ReturnsCorrectMemberRecord()
        {
            // Arrange
            var memberId = 1;
            var memberModel = MockMembers().FirstOrDefault(m => m.MemberId == memberId);
            mockRepo.Setup(repo => repo.GetMember(1))
                .ReturnsAsync(memberModel);
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.GetMember(memberId).Result;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<MemberModel>(result);
            Assert.Equal(memberModel.FirstName, (result as MemberModel).FirstName);
            Assert.Equal(memberModel.Surname, (result as MemberModel).Surname);
            Assert.Equal(memberModel.ShirtNumber, (result as MemberModel).ShirtNumber);
            Assert.Equal(memberModel.Position, (result as MemberModel).Position);
            Assert.Equal(memberModel.IsPlayer, (result as MemberModel).IsPlayer);
            Assert.Equal(memberModel.IsCoach, (result as MemberModel).IsCoach);
            Assert.Equal(memberModel.IsOfficial, (result as MemberModel).IsOfficial);
            Assert.Equal(memberModel.IsTableOfficial, (result as MemberModel).IsTableOfficial);
            Assert.Equal(memberModel.RefQualifications, (result as MemberModel).RefQualifications);
            Assert.Equal(memberModel.TableQualifications, (result as MemberModel).TableQualifications);
            Assert.Equal(memberModel.IsDeleted, (result as MemberModel).IsDeleted);
        }


        [Fact]
        public void GetMemberById_InvalidId_ReturnsNull()
        {
            // Arrange
            var nonMemberId = 100;
            mockRepo.Setup(repo => repo.GetMember(1))
                .ReturnsAsync(MockMembers().FirstOrDefault(m => m.MemberId == nonMemberId));
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.GetMember(nonMemberId).Result;

            //Assert
            Assert.Null(result);
        }
        #endregion

        #region Edit
        [Fact]
        public void EditMember_ChangesMemberDetails()
        {
            // Arrange
            var memberModel = MockMemberModel();
            var updatedMemberObject = MockUpdatedMemberObject();

            mockRepo.Setup(repo => repo.EditMember(mockMemberId, updatedMemberObject))
                .ReturnsAsync(memberModel);
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.EditMember(mockMemberId, updatedMemberObject).Result;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<MemberModel>(result);
            Assert.Equal(memberModel.FirstName, (result as MemberModel).FirstName);
            Assert.Equal(memberModel.Surname, (result as MemberModel).Surname);
            Assert.Equal(memberModel.ShirtNumber, (result as MemberModel).ShirtNumber);
            Assert.Equal(memberModel.Position, (result as MemberModel).Position);
            Assert.Equal(memberModel.IsPlayer, (result as MemberModel).IsPlayer);
            Assert.Equal(memberModel.IsCoach, (result as MemberModel).IsCoach);
            Assert.Equal(memberModel.IsOfficial, (result as MemberModel).IsOfficial);
            Assert.Equal(memberModel.IsTableOfficial, (result as MemberModel).IsTableOfficial);
            Assert.Equal(memberModel.RefQualifications, (result as MemberModel).RefQualifications);
            Assert.Equal(memberModel.TableQualifications, (result as MemberModel).TableQualifications);
            Assert.Equal(memberModel.IsDeleted, (result as MemberModel).IsDeleted);
        }

        #endregion



        // COME BACK TO THIS LATER

        #region Add

        [Fact]
        public void AddMember_ValidData_ReturnsUpdatedRecord()
        {
            // Arrange
            MemberObject validMemberObject = MockMemberObject();
            MemberModel memberModel = MockMemberModel();

            mockRepo.Setup(repo => repo.AddMember(validMemberObject))
                .ReturnsAsync(memberModel);
            var controller = new MemberController(mockRepo.Object);

            //Act
            var result = controller.AddMember(validMemberObject).Result;

            //Assert
            Assert.NotNull(result);
            Assert.IsType<MemberModel>(result);
            Assert.Equal(memberModel.FirstName, (result as MemberModel).FirstName);
            Assert.Equal(memberModel.Surname, (result as MemberModel).Surname);
            Assert.Equal(memberModel.ShirtNumber, (result as MemberModel).ShirtNumber);
            Assert.Equal(memberModel.Position, (result as MemberModel).Position);
            Assert.Equal(memberModel.IsPlayer, (result as MemberModel).IsPlayer);
            Assert.Equal(memberModel.IsCoach, (result as MemberModel).IsCoach);
            Assert.Equal(memberModel.IsOfficial, (result as MemberModel).IsOfficial);
            Assert.Equal(memberModel.IsTableOfficial, (result as MemberModel).IsTableOfficial);
            Assert.Equal(memberModel.RefQualifications, (result as MemberModel).RefQualifications);
            Assert.Equal(memberModel.TableQualifications, (result as MemberModel).TableQualifications);
            Assert.Equal(memberModel.IsDeleted, (result as MemberModel).IsDeleted);
        }

        #endregion







        /// <summary>
        /// Mock member object data
        /// </summary>
        /// <returns>A mock member object</returns>
        private MemberObject MockMemberObject()
        {
            return new MemberObject
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
                TableQualifications = "",
                MemberTeam = mockTeamId1
            };
        }

        /// <summary>
        /// Mock member model
        /// </summary>
        /// <returns>A mock member model</returns>
        private MemberModel MockMemberModel()
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
        /// Mock existing member object with updated values
        /// </summary>
        /// <returns>A mock member model</returns>
        private MemberObject MockUpdatedMemberObject()
        {
            return new MemberObject
            {
                MemberId = 1,
                FirstName = "Corey",
                Surname = "Vaughan",
                ShirtNumber = "69",
                IsCoach = false,
                IsOfficial = false,
                IsPlayer = true,
                IsTableOfficial = false,
                Position = "Guard",
                RefQualifications = "",
                TableQualifications = "",
                MemberTeam = mockTeamId1
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
                new MemberModel
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
                },
                new MemberModel
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
                },
                new MemberModel
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
                }
            };
        }

        /// <summary>
        /// Mock member details data.
        /// </summary>
        /// <returns>A list of Member Detials objects</returns>
        private List<MemberDetailsObject> MockMemberDetails()
        {
            return new List<MemberDetailsObject>
            {
                new MemberDetailsObject
                {
                    Member = new MemberModel
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
                    },
                    Team = new TeamModel
                    {
                        TeamId = mockTeamId1,
                        TeamName = "Team 1",
                        ShortTeamCode = "ABC",
                        DominantKitColour = "ffffff"
                    }
                },
                new MemberDetailsObject
                {
                    Member = new MemberModel
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
                    },
                    Team = new TeamModel
                    {
                        TeamId = mockTeamId2,
                        TeamName = "Team 2",
                        ShortTeamCode = "DEF",
                        DominantKitColour = "000000"
                    }
                },
                new MemberDetailsObject
                {
                    Member = new MemberModel
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
                    },
                    Team = new TeamModel
                    {
                        TeamId = mockTeamId3,
                        TeamName = "Team 3",
                        ShortTeamCode = "GHI",
                        DominantKitColour = "000fff"
                    }
                }
            };
        }
    }
}
