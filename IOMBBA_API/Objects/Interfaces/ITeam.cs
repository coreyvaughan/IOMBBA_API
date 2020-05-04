using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Objects.Interfaces
{
    public interface ITeam
    {
        /// <summary>
        /// Returns a list of all teams on the database.
        /// </summary>
        /// <returns>A List of team models</returns>
        IEnumerable<TeamModel> GetAllTeams();

        /// <summary>
        /// Returns team details and a list of all members for a given team id.
        /// </summary>
        /// <param name="id">The team id</param>
        /// <returns>A Team object</returns>
        TeamObject GetTeamMembers(Guid id);

        /// <summary>
        /// Gets a team record for a given id.
        /// </summary>
        /// <param name="id">The id of the team</param>
        /// <returns>A task</returns>
        Task<TeamModel> GetTeam(Guid id);

        /// <summary>
        /// Edit an existing team record from the database.
        /// </summary>
        /// <param name="id">The id of the team record</param>
        /// <param name="team">The new values to update the record with</param>
        /// <returns>The newly updated team record</returns>
        Task<TeamModel> EditTeam(Guid id, TeamModel team);

        /// <summary>
        /// Adds a new team record to the database.
        /// </summary>
        /// <param name="team">The new team object to be added</param>
        /// <returns>The team record that was added to the database</returns>
        Task<TeamModel> AddTeam(TeamModel team);

        /// <summary>
        /// Deletes an existing team from the database.
        /// </summary>
        /// <param name="id">The id of the team to be deleted</param>
        /// <returns>The team record that was deleted</returns>
        Task<TeamModel> DeleteTeam(Guid id);
    }
}

