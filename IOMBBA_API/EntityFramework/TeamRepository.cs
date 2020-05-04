using IOMBBA_System.Models;
using Microsoft.AspNetCore.Mvc;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class TeamRepository : ITeam
    {
        // Initialise the database context.
        private readonly DbContextClass _context;

        public TeamRepository(DbContextClass context)
        {
            _context = context;
        }


        /// <summary>
        /// Returns a list of all teams on the database.
        /// </summary>
        /// <returns>A List of team models</returns>
        public IEnumerable<TeamModel> GetAllTeams()
        {
            try
            {
                return _context.Team;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns team details and a list of all members for a given team id.
        /// </summary>
        /// <param name="id">The team id</param>
        /// <returns>A Team object</returns>
        public TeamObject GetTeamMembers([FromRoute] Guid id)
        {
            try
            {
                // Create a new team details object
                var teamDetails = new TeamObject
                {
                    MembersList = new List<MemberModel>(),
                    Team = _context.Team.Where(x => x.TeamId == id).FirstOrDefault()
                };
                var teamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == id).ToList();

                // For each current team member
                foreach (MemberTeamModel member in teamMembers)
                {
                    // If the player is still registered to the team.
                    if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    {
                        var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                        // Add the member to the members list.
                        teamDetails.MembersList.Add(memberDetails);
                    }
                }

                // Return the team details.
                return teamDetails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Gets a team record for a given id.
        /// </summary>
        /// <param name="id">The id of the team</param>
        /// <returns>An action result</returns>
        public async Task<TeamModel> GetTeam([FromRoute] Guid id)
        {
            try
            {
                return await _context.Team.FindAsync(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Edit an existing team record from the database.
        /// </summary>
        /// <param name="id">The id of the team record</param>
        /// <param name="team">The new values to update the record with</param>
        /// <returns>The newly updated team record</returns>
        public async Task<TeamModel> EditTeam([FromRoute] Guid id, [FromBody] TeamModel team)
        {
            try
            {
                var teamModel = _context.Team.Where(x => x.TeamId == id).FirstOrDefault();
                if (team != null)
                {
                    // Update the team model.
                    teamModel.TeamName = team.TeamName;
                    teamModel.ShortTeamCode = team.ShortTeamCode;
                    teamModel.DominantKitColour = team.DominantKitColour;

                    // Update the team record on the database with the new values.
                    _context.Team.Update(team);
                    await _context.SaveChangesAsync();
                }
                // Return the newly updated record.
                return team;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds a new team record to the database.
        /// </summary>
        /// <param name="team">The new team object to be added</param>
        /// <returns>The team record that was added to the database</returns>
        public async Task<TeamModel> AddTeam([FromBody] TeamModel team)
        {
            try
            {
                // Create a new id for the team.
                Guid newId = Guid.NewGuid();
                team.TeamId = newId;

                // Add the team to the database.
                _context.Team.Add(team);
                await _context.SaveChangesAsync();

                return team;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes an existing team from the database.
        /// </summary>
        /// <param name="id">The id of the team to be deleted</param>
        /// <returns>The team record that was deleted</returns>
        public async Task<TeamModel> DeleteTeam([FromRoute] Guid id)
        {
            try
            {
                var team = await _context.Team.FindAsync(id);

                // Remove the team record from the database.
                _context.Team.Remove(team);
                await _context.SaveChangesAsync();

                return team;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
