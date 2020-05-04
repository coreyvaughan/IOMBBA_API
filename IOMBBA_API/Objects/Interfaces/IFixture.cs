using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Objects.Interfaces
{
    public interface IFixture
    {

        /// <summary>
        /// Saves the current time remaining from the period counter to the database.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <param name="timeRemaining">The time remaining in milliseconds.</param>
        /// <returns>An action result</returns>
        Task SaveTimeRemaining(Guid id, int timeRemaining);


        /// <summary>
        /// Gets the details of all fixtures held on the system.
        /// </summary>
        /// <returns>A List of fixture details objects.</returns>
        Task<List<FixtureDetails>> GetAllFixtureDetailsAsync();

        /// <summary>
        /// Gets the details of a fixture for a given id.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A Fixture details object related to the fixture id.</returns>
        Task<FixtureDetails> GetFixtureDetails(Guid id);

        /// <summary>
        /// Gets the latest period object related to a fixture.
        /// </summary>
        /// <param name="id">The id of the fixture</param>
        /// <returns>A Period model.</returns>
        Task<PeriodModel> GetCurrentPeriod(Guid id);

        /// <summary>
        /// Creates a new period object for a particular fixture.
        /// </summary>
        /// <param name="fixtureId">The id of the fixture object the period will be created for.</param>
        /// <returns>The new period object which has been added to the database</returns>       
        Task<PeriodModel> AddNextPeriod(Guid fixtureId);

        /// <summary>
        /// Returns the current scores for each team in a fixture.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A total score for each team in the fixture</returns>
        Task<FixtureScoresObject> GetCurrentScores(Guid id);

        /// <summary>
        /// Returns a list of the current oncourt players for each team in the fixture.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <returns>A players list object</returns>
        Task<PlayersListsObject> GetOncourtPlayers(Guid id);

        /// <summary>
        /// Adds a new fixture to the database.
        /// </summary>
        /// <param name="form">The new fixture object to be created.</param>
        /// <returns>An action result.</returns>
        Task AddFixture(FixtureObject form);

        /// <summary>
        /// Deletes a fixture from the database for a given id.
        /// </summary>
        /// <param name="id">The id of the fixture to be deleted.</param>
        /// <returns>An action result.</returns>
        Task DeleteFixture(Guid id);
    }
}