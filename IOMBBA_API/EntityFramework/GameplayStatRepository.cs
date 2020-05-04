using IOMBBA_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Objects.Interfaces;
using Objects.Models;
using Objects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework
{
    public class GameplayStatRepository : IGameplayStat
    {
        // Initialise the database context.
        private readonly DbContextClass _context;

        public GameplayStatRepository(DbContextClass context)
        {
            _context = context;
        }


        /// <summary>
        /// Creates a new shot record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>
        public async Task<GameplayStatDetails> AddShot(GameplayStatDetails statObject)
        {
            try
            {
                // Create a new stat object to hold the data passed in from the form.
                GameplayStatModel newStat = new GameplayStatModel
                {
                    StatId = Guid.NewGuid(),
                    StatMemberId = statObject.Stat.StatMemberId,
                    StatCategory = "shot",
                    PeriodId = statObject.Stat.PeriodId,
                    TimeOfStat = statObject.Stat.TimeOfStat,
                    IsPlaying = true
                };


                // Add the new stat record to the database.
                _context.GameplayStat.Add(newStat);
                await _context.SaveChangesAsync();

                // Populate a new shot model object with the values passed into the API.
                ShotModel newShot = new ShotModel
                {
                    ShotStatId = newStat.StatId,
                    ShotPoints = statObject.Shot.ShotPoints,
                    XPosition = statObject.Shot.XPosition,
                    YPosition = statObject.Shot.YPosition,
                    ShotType = statObject.Shot.ShotType,
                    FreeThrow = statObject.Shot.FreeThrow
                };

                // Add the new shot record to the database.
                _context.Shot.Add(newShot);
                await _context.SaveChangesAsync();

                // Create a new GameplayStatDetails to return to the frontend.
                GameplayStatDetails statDetails = new GameplayStatDetails
                {
                    Stat = newStat,
                    Shot = newShot
                };

                return statDetails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Creates a new foul record on the database.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>A StatDetails object including the new foul information that has been added to the database.</returns>
        public async Task<GameplayStatDetails> AddFoul(GameplayStatDetails statObject)
        {
            try
            {
                // Create a new stat object to hold the data passed in from the form.
                GameplayStatModel newStat = new GameplayStatModel
                {
                    StatId = Guid.NewGuid(),
                    StatMemberId = statObject.Stat.StatMemberId,
                    StatCategory = "foul",
                    PeriodId = statObject.Stat.PeriodId,
                    TimeOfStat = statObject.Stat.TimeOfStat,
                    IsPlaying = statObject.Stat.IsPlaying
                };


                // Add the new stat record to the database.
                _context.GameplayStat.Add(newStat);
                await _context.SaveChangesAsync();

                FoulModel newFoul = new FoulModel
                {
                    FoulStatId = newStat.StatId,
                    FoulType = statObject.Foul.FoulType,
                    FoulMinute = statObject.Foul.FoulMinute,
                    FreeThrowsAwarded = statObject.Foul.FreeThrowsAwarded
                };

                // Add the new foul record to the database.
                _context.Foul.Add(newFoul);
                await _context.SaveChangesAsync();

                // Create a new GameplayStatDetails to return to the frontend.
                GameplayStatDetails statDetails = new GameplayStatDetails
                {
                    Stat = newStat,
                    Foul = newFoul
                };

                return statDetails;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Creates new substitution records on the database.
        /// </summary>
        /// <param name="statObject">The statistic details to be added to the database</param>
        /// <returns>A list of the stat IDs of the new substitution stats that have been added.</returns>
        public async Task<List<Guid>> AddSubstitution(GameplayStatDetails statObject)
        {
            try
            {
                // Create list of stat Ids for substitutions so they can be undone.
                var statIds = new List<Guid>();

                foreach (var memberId in statObject.GroupSubstitution.HomePlayersOff)
                {
                    // Create a new Id for the stat.
                    Guid statId = Guid.NewGuid();
                    // Add the Id to the Stat Ids list.
                    statIds.Add(statId);

                    // Create a new stat object to hold the data passed in from the form.
                    GameplayStatModel newStat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = statObject.Stat.PeriodId,
                        TimeOfStat = statObject.Stat.TimeOfStat,
                        IsPlaying = false
                    };
                    // Add the new stat record to the database.
                    _context.GameplayStat.Add(newStat);
                    await _context.SaveChangesAsync();
                }

                foreach (var memberId in statObject.GroupSubstitution.HomePlayersOn)
                {
                    // Create a new Id for the stat.
                    Guid statId = Guid.NewGuid();
                    // Add the Id to the Stat Ids list.
                    statIds.Add(statId);

                    // Create a new stat object to hold the data passed in from the form.
                    GameplayStatModel newStat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = statObject.Stat.PeriodId,
                        TimeOfStat = statObject.Stat.TimeOfStat,
                        IsPlaying = true
                    };
                    // Add the new stat record to the database.
                    _context.GameplayStat.Add(newStat);
                    await _context.SaveChangesAsync();
                }

                foreach (var memberId in statObject.GroupSubstitution.AwayPlayersOff)
                {
                    // Create a new Id for the stat.
                    Guid statId = Guid.NewGuid();
                    // Add the Id to the Stat Ids list.
                    statIds.Add(statId);

                    // Create a new stat object to hold the data passed in from the form.
                    GameplayStatModel newStat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = statObject.Stat.PeriodId,
                        TimeOfStat = statObject.Stat.TimeOfStat,
                        IsPlaying = false
                    };
                    // Add the new stat record to the database.
                    _context.GameplayStat.Add(newStat);
                    await _context.SaveChangesAsync();
                }

                foreach (var memberId in statObject.GroupSubstitution.AwayPlayersOn)
                {
                    // Create a new Id for the stat.
                    Guid statId = Guid.NewGuid();
                    // Add the Id to the Stat Ids list.
                    statIds.Add(statId);

                    // Create a new stat object to hold the data passed in from the form.
                    GameplayStatModel newStat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = statObject.Stat.PeriodId,
                        TimeOfStat = statObject.Stat.TimeOfStat,
                        IsPlaying = true
                    };
                    // Add the new stat record to the database.
                    _context.GameplayStat.Add(newStat);
                    await _context.SaveChangesAsync();
                }

                return statIds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove corresponding GameplayStat records from database related to stat ids list.
        /// </summary>
        /// <param name="statIds">The StatIds of the substitution statistics to be removed</param>
        public async Task DeleteSubstitutions(List<Guid> statIds)
        {
            try
            {
                foreach (Guid statId in statIds)
                {
                    // Retrieve the GameplayStat record with the associated statId that has been passed in.
                    var statObject = await _context.GameplayStat.Where(x => x.StatId == statId).FirstOrDefaultAsync();

                    // If there isn't an object related to the Id.

                    if (statObject != null)
                    {
                        // Remove the shot record from the database.
                        _context.GameplayStat.Remove(statObject);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Remove Shot and corresponding GameplayStat records from database.
        /// </summary>
        /// <param name="statId">The StatId of the statistics to be removed</param>
        /// <returns>GameplayStatDetails object with details of the new records that have been added</returns>
        public async Task DeleteShot(Guid statId)
        {
            try
            {
                // Retrieve the Shot record with the associated statId that has been passed in.
                var shotObject = await _context.Shot.Where(x => x.ShotStatId == statId).FirstOrDefaultAsync();

                if (shotObject != null)
                {
                    // Remove the shot record from the database.
                    _context.Shot.Remove(shotObject);
                    await _context.SaveChangesAsync();

                    // Retrieve the gameplay stat record from the database context.
                    var gameplayStat = await _context.GameplayStat.FindAsync(statId);
                    if (gameplayStat != null)
                    {
                        // Remove the statistic record from the database.
                        _context.GameplayStat.Remove(gameplayStat);
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Creates a new general stat record on the database. General stats include rebounds, turnovers, steals, blocks etc.
        /// </summary>
        /// <param name="statObject">The statistic to be added to the database</param>
        /// <returns>GameplayStat object with details of the new records that have been added</returns>
        public async Task<GameplayStatModel> AddGeneralStat(GameplayStatModel statObject)
        {
            // Create a new stat object and populate it with data from the frontend.
            GameplayStatModel newStat = new GameplayStatModel
            {
                StatId = Guid.NewGuid(),
                StatMemberId = statObject.StatMemberId,
                PeriodId = statObject.PeriodId,
                TimeOfStat = statObject.TimeOfStat,
                IsPlaying = true
            };

            if (statObject.StatCategory == "offensive-rebound")
            {
                newStat.StatCategory = "offensive rebound";
            }
            else if (statObject.StatCategory == "defensive-rebound")
            {
                newStat.StatCategory = "defensive rebound";
            }
            else
            {
                newStat.StatCategory = statObject.StatCategory;
            }

            // Add the new stat record to the database.
            _context.GameplayStat.Add(statObject);
            await _context.SaveChangesAsync();

            // Return the newly created stat object.
            return newStat;
        }


        /// <summary>
        /// Returns a list of all gameplay stats related to a given player
        /// </summary>
        /// <param name="id">the id of the player</param>
        /// <returns>List of gameplay stat objects.</returns>
        public async Task<List<GameplayStatObject>> GetAllPlayerStats([FromRoute] int id)
        {
            try
            {
                // Create a list of gameplay stat objects.
                List<GameplayStatObject> gameplayStats = new List<GameplayStatObject>();

                // Get the member model for the given member id.
                MemberModel member = _context.Member.Where(x => x.MemberId == id).FirstOrDefault();

                // Check the member team records to find the team the member is currently in.
                var teamId = _context.MemberTeam.Where(x => x.MemberOfTeam == id).Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault().TeamOfMember;
                TeamModel team = _context.Team.Where(x => x.TeamId == teamId).FirstOrDefault();

                // Get the stat models related to the player
                List<GameplayStatModel> playerStatModels = await _context.GameplayStat.Where(x => x.StatMemberId == id).OrderBy(x => x.Order).ToListAsync();

                // Populate gameplay stat details object for each stat model.
                foreach (GameplayStatModel stat in playerStatModels)
                {
                    ShotModel shot = new ShotModel();
                    FoulModel foul = new FoulModel();

                    // If the stat is a shot.
                    if (stat.StatCategory == "shot")
                    {
                        // Get a shot object
                        shot = _context.Shot.Where(x => x.ShotStatId == stat.StatId).FirstOrDefault();
                    }
                    else if (stat.StatCategory == "foul")
                    {
                        // Get a foul object
                        foul = _context.Foul.Where(x => x.FoulStatId == stat.StatId).FirstOrDefault();
                    }

                    // Populate the stat details 
                    GameplayStatObject statDetails = new GameplayStatObject
                    {
                        Stat = stat,
                        Shot = shot,
                        Member = member,
                        Team = team,
                        Foul = foul
                    };

                    // Add the stat object to the lsit
                    gameplayStats.Add(statDetails);
                }

                // Return the stats list.
                return gameplayStats;
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        /// <summary>
        /// Returns a list of all gameplay stats related to a given fixture
        /// </summary>
        /// <param name="id">the id of the fixture</param>
        /// <returns>List of gameplay stat objects.</returns
        public async Task<List<List<GameplayStatObject>>> GetAllGameplayStats([FromRoute] Guid id)
        {
            try
            {
                // Get a list of all periods belonging to the particular match number.
                List<PeriodModel> matchPeriods = await _context.Period.Where(x => x.GameNumberOfPeriod == id).OrderBy(x => x.PeriodNumber).ToListAsync();
                List<GameplayStatObject> gameplayStats = new List<GameplayStatObject>();
                // Create a new list to hold the stats lists for each period.
                List<List<GameplayStatObject>> periodStatObjectsList = new List<List<GameplayStatObject>>();

                foreach (PeriodModel period in matchPeriods)
                {
                    // Get the stats for each period in time order.
                    List<GameplayStatModel> periodStats = await _context.GameplayStat.Where(x => x.PeriodId == period.PeriodId).OrderBy(x => x.Order).ToListAsync();

                    // Populate gameplay stat details object for each stat model.
                    foreach (GameplayStatModel stat in periodStats)
                    {
                        ShotModel shot = new ShotModel();
                        FoulModel foul = new FoulModel();
                        MemberModel member = _context.Member.Where(x => x.MemberId == stat.StatMemberId).FirstOrDefault();

                        // Check the member team records to find the team the member is currently in.
                        MemberTeamModel record = _context.MemberTeam.Where(x => x.MemberOfTeam == stat.StatMemberId).Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault();
                        if (record != null)
                        {
                            var teamId = record.TeamOfMember;
                            TeamModel team = _context.Team.Where(x => x.TeamId == teamId).FirstOrDefault();

                            // If the stat is a shot.
                            if (stat.StatCategory == "shot")
                            {
                                // Get a shot object
                                shot = _context.Shot.Where(x => x.ShotStatId == stat.StatId).FirstOrDefault();
                            }
                            else if (stat.StatCategory == "foul")
                            {
                                // Get a foul object
                                foul = _context.Foul.Where(x => x.FoulStatId == stat.StatId).FirstOrDefault();
                            }

                            // Populate the stat details 
                            GameplayStatObject statDetails = new GameplayStatObject
                            {
                                Stat = stat,
                                Shot = shot,
                                Member = member,
                                Team = team,
                                Foul = foul
                            };

                            // Add the stat object to the list
                            gameplayStats.Add(statDetails);
                        }
                    }
                    // Add the period stats list to the period stat objects list.
                    periodStatObjectsList.Add(gameplayStats);
                }

                // Return the stats list.
                return periodStatObjectsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
