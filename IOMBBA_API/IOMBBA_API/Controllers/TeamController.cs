using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;

namespace IOMBBA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]

    public class TeamController : ControllerBase
    {
        // Declare the interface.
        private readonly ITeam teamService;

        public TeamController(ITeam context)
        {
            teamService = context;
        }

        /// <summary>
        /// Returns a list of all teams on the database.
        /// </summary>
        /// <returns>A List of team models</returns>
        [HttpGet]
        [Route("GetAllTeams")]
        public IEnumerable<TeamModel> GetAllTeams()
        {
            return teamService.GetAllTeams();
        }

        /// <summary>
        /// Returns team details and a list of all members for a given team id.
        /// </summary>
        /// <param name="id">The team id</param>
        /// <returns>A Team object</returns>
        [HttpGet("{id}")]
        [Route("GetTeamMembers/{id}")]

        public TeamObject GetTeamMembers([FromRoute] Guid id)
        {
            return teamService.GetTeamMembers(id);
        }


        /// <summary>
        /// Gets a team record for a given id.
        /// </summary>
        /// <param name="id">The id of the team</param>
        /// <returns>An action result</returns>
        [HttpGet("{id}")]
        [Route("GetTeam/{id}")]

        public async Task<TeamModel> GetTeam([FromRoute] Guid id)
        {
            return await teamService.GetTeam(id);
        }

        /// <summary>
        /// Edit an existing team record from the database.
        /// </summary>
        /// <param name="id">The id of the team record</param>
        /// <param name="team">The new values to update the record with</param>
        /// <returns>The newly updated team record</returns>
        [HttpPut("{id}")]
        [Route("EditTeam/{id}")]

        public async Task<TeamModel> EditTeam([FromRoute] Guid id, [FromBody] TeamModel team)
        {
            return await teamService.EditTeam(id, team);
        }

        /// <summary>
        /// Adds a new team record to the database.
        /// </summary>
        /// <param name="team">The new team object to be added</param>
        /// <returns>The team record that was added to the databases</returns>
        [HttpPost]
        [Route("AddTeam")]

        public async Task<TeamModel> AddTeam([FromBody] TeamModel team)
        {
            return await teamService.AddTeam(team);
        }

        /// <summary>
        /// Deletes an existing team from the database.
        /// </summary>
        /// <param name="id">The id of the team to be deleted</param>
        /// <returns>The team model that was deleted.</returns>
        [HttpDelete("{id}")]
        [Route("DeleteTeam/{id}")]

        public async Task<TeamModel> DeleteTeam([FromRoute] Guid id)
        {
            return await teamService.DeleteTeam(id);
        }
    }
}