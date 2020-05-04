using IOMBBA_API.Controllers;
using Moq;
using Objects.Interfaces;
using Objects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace IOMBBA_Testing.Unit_Tests
{
    /// <summary>
    /// Unit test to test the logic of the Competition controller class.
    /// Built with reference to: https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-3.1
    /// </summary>
    public class CompetitionControllerUnitTests
    {

        // Mock CompetitionId Guids
        public static Guid mockCompetitionId1 = Guid.NewGuid();
        public static Guid mockCompetitionId2 = Guid.NewGuid();
        public static Guid mockCompetitionId3 = Guid.NewGuid();

        // Mock the ICompetition interface
        public Mock<ICompetition> mockRepo = new Mock<ICompetition>();


        #region Get All
        [Fact]
        public void GetAllMembers_ReturnsAllMembers()
        {
            // Arrange 
            mockRepo.Setup(repo => repo.GetAllCompetitions())
                .Returns(MockCompetitions());
            var controller = new CompetitionController(mockRepo.Object);

            // Act
            var result = controller.GetAllCompetitions();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<CompetitionModel>>(result);
            Assert.Equal(3, result.Count());
        }

        #endregion




        /// <summary>
        /// Mock competition data.
        /// </summary>
        /// <returns>A list of Competition models</returns>
        private List<CompetitionModel> MockCompetitions()
        {
            return new List<CompetitionModel>
            {
                new CompetitionModel
                {
                    CompetitionId = mockCompetitionId1,
                    CompetitionName = "Competition1"
                },
                new CompetitionModel
                {
                    CompetitionId = mockCompetitionId2,
                    CompetitionName = "Competition2"
                },
                new CompetitionModel
                {
                    CompetitionId = mockCompetitionId3,
                    CompetitionName = "Competition3"
                }
            };
        }
    }
}
