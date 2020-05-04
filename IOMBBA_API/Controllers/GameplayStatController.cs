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

    public class GameplayStatController : ControllerBase
    {
        // Declare the interface.
        private readonly IGameplayStat gameplayStatService;

        public GameplayStatController(IGameplayStat context)
        {
            gameplayStatService = context;
        }


        /// <summary>
        /// Creates a new shot record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>
        [HttpPost]
        [Route("AddShot")]

        public async Task<GameplayStatDetails> AddShot(GameplayStatDetails statObject)
        {
            return await gameplayStatService.AddShot(statObject);
        }

        /// <summary>
        /// Creates a new foul record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>A StatDetails object including the new foul information that has been added to the database.</returns>
        [HttpPost]
        [Route("AddFoul")]

        public async Task<GameplayStatDetails> AddFoul(GameplayStatDetails statObject)
        {
            return await gameplayStatService.AddFoul(statObject);
        }

        /// <summary>
        /// Creates new substitution records on the database.
        /// </summary>
        /// <param name="statObject">The statistic details to be added to the database</param>
        /// <returns>A list of the stat IDs of the new substitution stats that have been added.</returns>
        [HttpPost]
        [Route("AddSubstitutions")]

        public async Task<List<Guid>> AddSubstitution(GameplayStatDetails statObject)
        {
            var result = await gameplayStatService.AddSubstitution(statObject);
            return result;
        }

        /// <summary>
        /// Remove corresponding GameplayStat records from database related to stat ids list.
        /// </summary>
        /// <param name="statIds">The StatIds of the substitution statistics to be removed</param>

        [HttpDelete("{statIds}")]
        [Route("DeleteSubstitutions/{statIds}")]

        public async Task DeleteSubstitutions(List<Guid> statIds)
        {
            await gameplayStatService.DeleteSubstitutions(statIds);
        }

        /// <summary>
        /// Remove Shot and corresponding GameplayStat records from database.
        /// </summary>
        /// <param name="statId">The StatId of the statistics to be removed</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>

        [HttpDelete("{statId}")]
        [Route("DeleteShot/{statId}")]

        public async Task DeleteShot(Guid statId)
        {
            await gameplayStatService.DeleteShot(statId);
        }

        /// <summary>
        /// Creates a new general stat record on the database. General stats include rebounds, turnovers, steals, blocks etc.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStat object with details of the new records that have been added</returns>
        [HttpPost]
        [Route("AddGeneralStat")]

        public async Task<GameplayStatModel> AddGeneralStat(GameplayStatModel statObject)
        {
            return await gameplayStatService.AddGeneralStat(statObject);
        }


        /// <summary>
        /// Returns a list of all gameplay stats related to a given player
        /// </summary>
        /// <param name="id">the id of the player</param>
        /// <returns>List of gameplay stat objects.</returns>
        [HttpGet]
        [Route("GetAllPlayerStats/{id}")]

        public async Task<List<GameplayStatObject>> GetAllPlayerStats([FromRoute] int id)
        {
            return await gameplayStatService.GetAllPlayerStats(id);
        }


        /// <summary>
        /// Returns a list of all gameplay stats related to a given fixture
        /// </summary>
        /// <param name="id">the id of the fixture</param>
        /// <returns>List of gameplay stat objects.</returns>
        [HttpGet]
        [Route("GetAllGameplayStats/{id}")]

        public async Task<List<List<GameplayStatObject>>> GetAllGameplayStats([FromRoute] Guid id)
        {
            return await gameplayStatService.GetAllGameplayStats(id);
        }
    }
}