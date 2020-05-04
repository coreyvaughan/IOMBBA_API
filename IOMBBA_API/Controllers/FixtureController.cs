using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Objects.Interfaces;
using Objects.Objects;
using Objects.Models;

namespace IOMBBA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]

    public class FixtureController : ControllerBase
    {
        // Declare the interface.
        private readonly IFixture fixtureService;

        public FixtureController(IFixture context)
        {
            fixtureService = context;
        }


        /// <summary>
        /// Saves the current time remaining from the period counter to the database.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <param name="timeRemaining">The time remaining in milliseconds.</param>
        /// <returns>An action result</returns>
        [HttpPut("{id}")]
        [Route("SaveTimeRemaining/{id}")]

        public async Task SaveTimeRemaining([FromRoute] Guid id, [FromBody] int timeRemaining)
        {
            await fixtureService.SaveTimeRemaining(id, timeRemaining);
        }


        /// <summary>
        /// Gets the details of all fixtures held on the system.
        /// </summary>
        /// <returns>A List of fixture details objects.</returns>
        [HttpGet]
        [Route("GetFixtureDetails")]

        public async Task<IEnumerable<FixtureDetails>> GetAllFixtureDetailsAsync()
        {
            return await fixtureService.GetAllFixtureDetailsAsync();
        }


        /// <summary>
        /// Gets the details of a fixture for a given id.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A Fixture details object related to the fixture id.</returns>
        [HttpGet("{id}")]
        [Route("GetFixtureDetails/{id}")]
        public async Task<FixtureDetails> GetFixtureDetails([FromRoute] Guid id)
        {
            return await fixtureService.GetFixtureDetails(id);
        }

        /// <summary>
        /// Retrieves the latest period related to the fixture.
        /// </summary>
        /// <param name="id">The id of the fixture object the period is under</param>
        /// <returns>The current period model.</returns>        

        [HttpGet("{id}")]
        [Route("GetCurrentPeriod/{id}")]

        public async Task<PeriodModel> GetCurrentPeriod([FromRoute] Guid id)
        {
            return await fixtureService.GetCurrentPeriod(id);
        }

        /// <summary>
        /// Creates a new period object for a particular fixture.
        /// </summary>
        /// <param name="fixtureId">The id of the fixture object the period will be created for.</param>
        /// <returns>The new period object which has been added to the database</returns>    
        [HttpGet]
        [Route("AddNextPeriod/{fixtureId}")]

        public async Task<PeriodModel> AddNextPeriod(Guid fixtureId)
        {
            return await fixtureService.AddNextPeriod(fixtureId);
        }

        /// <summary>
        /// Returns the current scores for each team in a fixture.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A total score for each team in the fixture</returns>
        [HttpGet("{id}")]
        [Route("GetCurrentScores/{id}")]

        public async Task<FixtureScoresObject> GetCurrentScores([FromRoute] Guid id)
        {
            return await fixtureService.GetCurrentScores(id);
        }

        /// <summary>
        /// Returns a list of the current oncourt players for each team in the fixture.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <returns>A players list object</returns>
        [HttpGet("{id}")]
        [Route("GetOncourtPlayers/{id}")]

        public async Task<PlayersListsObject> GetOncourtPlayers([FromRoute] Guid id)
        {
            return await fixtureService.GetOncourtPlayers(id);
        }

        /// <summary>
        /// Adds a new fixture to the database.
        /// </summary>
        /// <param name="form">The new fixture object to be created.</param>
        /// <returns>An action result.</returns>
        [HttpPost]
        [Route("AddFixture")]

        public async Task AddFixture([FromBody] FixtureObject form)
        {
            await fixtureService.AddFixture(form);
        }

        /// <summary>
        /// Deletes a fixture from the database for a given id.
        /// </summary>
        /// <param name="id">The id of the fixture to be deleted.</param>
        /// <returns>An action result.</returns>
        [HttpDelete("{id}")]
        [Route("DeleteFixture/{id}")]

        public async Task DeleteFixture([FromRoute] Guid id)
        {
            await fixtureService.DeleteFixture(id);
        }
    }
}