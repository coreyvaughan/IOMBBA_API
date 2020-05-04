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
    public class MemberRepository : IMember
    {
        // Initialise the database context.
        private readonly DbContextClass _context;

        public MemberRepository(DbContextClass context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all member records held on the database.
        /// </summary>
        /// <returns>A list of member models</returns>
        public List<MemberModel> GetAllMembers()
        {
            try
            {
                return _context.Member.Where(x => x.IsDeleted == false).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the details of all members on the database
        /// </summary>
        /// <returns>A list of member details objects</returns>
        public List<MemberDetailsObject> GetAllMemberDetails()
        {
            try
            {
                // Create a new member details object.
                List<MemberDetailsObject> memberDetails = new List<MemberDetailsObject>();
                var members = _context.Member.Where(x => x.IsDeleted == false).ToList();
                foreach (MemberModel member in members)
                {
                    // Populate a MemberDetails object
                    MemberTeamModel currentMemberTeam = _context.MemberTeam.Where(x => x.MemberOfTeam == member.MemberId).Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault();
                    TeamModel team = new TeamModel();
                    // If a member has been assigned to a team.
                    if (currentMemberTeam != null)
                    {
                        // Populate the member details object with the team.
                        team = _context.Team.Where(x => x.TeamId == currentMemberTeam.TeamOfMember).FirstOrDefault();
                    }

                    MemberDetailsObject memberDetailsObject = new MemberDetailsObject
                    {
                        Member = member,
                        Team = team
                    };
                    // Add the object to te list.
                    memberDetails.Add(memberDetailsObject);
                }
                // Return the list.
                return memberDetails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the details of a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>A MemberDetailsObject</returns>
        public MemberDetailsObject GetMemberDetails(int id)
        {
            try
            {
                // Create a new member details object to hold the member info.
                MemberDetailsObject memberDetails = new MemberDetailsObject();

                // Get the member model related to the id if there is one.
                MemberModel member = _context.Member.Where(x => x.MemberId == id && x.IsDeleted == false).FirstOrDefault();

                // If a member record was returned.
                if (member != null)
                {
                    // Populate a MemberDetails object
                    MemberTeamModel currentMemberTeam = _context.MemberTeam.Where(x => x.MemberOfTeam == id).Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault();

                    TeamModel team = new TeamModel();
                    // If a member has been assigned to a team.
                    if (currentMemberTeam != null)
                    {
                        // Populate the member details object with the team.
                        team = _context.Team.Where(x => x.TeamId == currentMemberTeam.TeamOfMember).FirstOrDefault();
                    }

                    // Populate the member details object with the information from the database.
                    memberDetails.Member = member;
                    memberDetails.Team = team;
                }
                // Return the member details object.
                return memberDetails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets a member for a given id.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <returns>An action result</returns>
        public async Task<MemberModel> GetMember([FromRoute] int id)
        {
            return await _context.Member.FindAsync(id);
        }

        /// <summary>
        /// Edits an existing member record on the database.
        /// </summary>
        /// <param name="id">The id of the member</param>
        /// <param name="form">The member details, passed in from the form</param>
        /// <returns>The new values of the edited record</returns>
        public async Task<MemberModel> EditMember([FromRoute] int id, [FromBody] MemberObject form)
        {
            try
            {
                //check the current team they are assigned to
                var memberTeamRecords = _context.MemberTeam.Where(x => x.MemberOfTeam == id).ToList();
                //if there is a past record of a team transfer
                if (memberTeamRecords.Count != 0)
                {
                    MemberTeamModel currentMemberTeam = memberTeamRecords.Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault();

                    //if the member has changed teams since last transfer
                    if (form.MemberTeam != currentMemberTeam.TeamOfMember)
                    {   //update the end date of the current member team record
                        currentMemberTeam.DateLeftTeam = DateTime.Now;

                        //create a new record
                        MemberTeamModel memberTeam = new MemberTeamModel
                        {
                            MemberTeamId = Guid.NewGuid(),
                            MemberOfTeam = id,
                            TeamOfMember = form.MemberTeam,
                            DateJoinedTeam = DateTime.Now,
                            DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                        };
                        //add new MemberTeam record to database
                        _context.MemberTeam.Add(memberTeam);
                        await _context.SaveChangesAsync();
                    }
                    //if there is no current MemberTeam record but the form has a memberteam value
                }
                else if (memberTeamRecords.Count == 0 && form.MemberTeam != Guid.Empty)
                //make a new record memberteam record 
                {
                    //create a new record
                    MemberTeamModel memberTeam = new MemberTeamModel
                    {
                        MemberTeamId = Guid.NewGuid(),
                        MemberOfTeam = id,
                        TeamOfMember = form.MemberTeam,
                        DateJoinedTeam = DateTime.Now,
                        DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                    };
                    //add new MemberTeam record to database
                    _context.MemberTeam.Add(memberTeam);
                    await _context.SaveChangesAsync();
                }


                //get current member record
                var member = _context.Member.Where(x => x.MemberId == id).FirstOrDefault();

                //update current record with values from the edit form
                member.FirstName = form.FirstName;
                member.Surname = form.Surname;
                member.ShirtNumber = form.ShirtNumber;
                member.Position = form.Position;
                member.IsPlayer = form.IsPlayer;
                member.IsCoach = form.IsCoach;
                member.IsOfficial = form.IsCoach;
                member.IsTableOfficial = form.IsTableOfficial;
                member.RefQualifications = form.RefQualifications;
                member.TableQualifications = form.TableQualifications;


                // Update the member record on the database.
                _context.Member.Update(member);
                await _context.SaveChangesAsync();

                // Return the edited member record.
                return member;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Adds a new member record to the database.
        /// </summary>
        /// <param name="form">The details of the new member to be added</param>
        /// <returns>The newly added member record</returns>
        public async Task<MemberModel> AddMember(MemberObject form)
        {
            try
            {
                MemberModel member = new MemberModel
                {
                    FirstName = form.FirstName,
                    Surname = form.Surname,
                    ShirtNumber = form.ShirtNumber,
                    Position = form.Position,
                    IsPlayer = form.IsPlayer,
                    IsCoach = form.IsCoach,
                    IsOfficial = form.IsCoach,
                    IsTableOfficial = form.IsTableOfficial,
                    RefQualifications = form.RefQualifications,
                    TableQualifications = form.TableQualifications
                };


                //add the member to the database
                _context.Member.Add(member);
                await _context.SaveChangesAsync();

                //if the member is assigned to a team
                if (!(form.MemberTeam == Guid.Empty))
                {
                    //if the member is assigned to a team
                    MemberTeamModel memberTeam = new MemberTeamModel
                    {
                        MemberTeamId = Guid.NewGuid(),
                        MemberOfTeam = member.MemberId,
                        TeamOfMember = form.MemberTeam,
                        DateJoinedTeam = DateTime.Now,
                        DateLeftTeam = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue
                    };
                    _context.MemberTeam.Add(memberTeam);
                    await _context.SaveChangesAsync();
                }

                // Return the newly added member record.
                return member;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Deletes an existing member from the database.
        /// </summary>
        /// <param name="id">The id of the member to be deleted</param>
        /// <returns>An action result</returns>
        public async Task DeleteMember(int id)
        {
            try
            {
                // Get member team record.
                var memberteamRecord = _context.MemberTeam.Where(x => x.MemberOfTeam == id).FirstOrDefault();
                //set leaving date of current MemberTeam record to today's date
                memberteamRecord.DateLeftTeam = DateTime.Now;


                var memberTeamRecord = _context.MemberTeam.Where(x => x.MemberOfTeam == id).ToList();

                //for every memberteam record pertaining to member to be deleted
                foreach (var record in memberTeamRecord)
                {
                    // Set the record to deleted
                    record.IsDeleted = true;
                    //remove record from database
                    _context.MemberTeam.Update(record);
                    await _context.SaveChangesAsync();
                }

                //delete member from member table
                var member = await _context.Member.FindAsync(id);

                if (member != null)
                {
                    // Set the member record flag to deleted.
                    member.IsDeleted = true;
                    _context.Member.Update(member);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
