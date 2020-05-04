using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IOMBBA_System.Models;
using Objects.Interfaces;
using Objects.Objects;
using Objects.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntityFramework
{
    public class FixtureRepository : IFixture
    {

        // Initialise the database context.
        private readonly DbContextClass _context;

        public FixtureRepository(DbContextClass context)
        {
            _context = context;
        }

        /// <summary>
        /// Saves the current time remaining from the period counter to the database.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <param name="timeRemaining">The time remaining in milliseconds.</param>
        public async Task SaveTimeRemaining([FromRoute] Guid id, [FromBody] int timeRemaining)
        {
            try
            {
                // Get the period model matching the id that has been passed in.
                var period = _context.Period.Where(x => x.PeriodId == id).FirstOrDefault();

                if (period != null)
                {
                    // Set the time remaining field to the time remaining on the period clock.
                    period.TimeRemaining = timeRemaining;

                    // Update the period record on the database.
                    _context.Period.Update(period);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets the details of all fixtures held on the system.
        /// </summary>
        /// <returns>A List of fixture details objects.</returns>

        public async Task<List<FixtureDetails>> GetAllFixtureDetailsAsync()
        {
            try
            {
                var fixtureDetailsList = new List<FixtureDetails>();

                // Get list of all fixtures in database.
                var allFixtures = _context.Fixture.ToList();

                // Create a FixtureDetails object for each fixture in the list.
                foreach (FixtureModel fixture in allFixtures)
                {
                    // Create new FixtureDetails object.
                    FixtureDetails fixtureDetails = new FixtureDetails
                    {
                        FixtureObject = fixture,
                        // Get competition name for fixture.
                        CompetitionName = _context.Competition.Where(x => x.CompetitionId == fixture.CompetitionId).FirstOrDefault().CompetitionName,
                        // Create data for HOME team.
                        HomeTeamObject = _context.Team.Where(x => x.TeamId == fixture.HomeTeamId).FirstOrDefault(),
                        HomeTeamMembersList = new List<MemberModel>()
                    };
                    var homeTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixture.HomeTeamId).ToList();
                    // Populate FixtureDetails object with HOME team members.
                    foreach (MemberTeamModel member in homeTeamMembers)
                    {
                        //if the member is still part of the team
                        if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        {
                            // Create member object from MemberIds.
                            var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                            fixtureDetails.HomeTeamMembersList.Add(memberDetails);
                        }
                    }

                    // Create data for AWAY team.
                    fixtureDetails.AwayTeamObject = _context.Team.Where(x => x.TeamId == fixture.AwayTeamId).FirstOrDefault();
                    fixtureDetails.AwayTeamMembersList = new List<MemberModel>();
                    var awayTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixture.AwayTeamId).ToList();
                    // Populate FixtureDetails object with away AWAY members.
                    foreach (MemberTeamModel member in awayTeamMembers)
                    {
                        // If the member is still part of the team.
                        if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                        {
                            // Create member object from MemberIds.
                            var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                            fixtureDetails.AwayTeamMembersList.Add(memberDetails);
                        }
                    }

                    // Get the period duration from the period table.
                    var periodObject = _context.Period.Where(x => x.GameNumberOfPeriod == fixture.MatchNumber).FirstOrDefault();
                    fixtureDetails.PeriodDuration = periodObject.PeriodDuration;

                    // Get current scores for each team in the fixture.
                    fixtureDetails.Scores = await GetCurrentScores(fixtureDetails.FixtureObject.MatchNumber);

                    // Add FixtureDetails object to list.
                    fixtureDetailsList.Add(fixtureDetails);
                }

                return fixtureDetailsList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Gets the details of a fixture for a given id.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A Fixture details object related to the fixture id.</returns>
        public async Task<FixtureDetails> GetFixtureDetails([FromRoute] Guid id)
        {
            var fixtureDetails = new FixtureDetails
            {
                // Get fixture object of relevant ID.
                FixtureObject = _context.Fixture.Where(x => x.MatchNumber == id).FirstOrDefault()
            };

            // Get competition name for fixture.
            fixtureDetails.CompetitionName = _context.Competition.Where(x => x.CompetitionId == fixtureDetails.FixtureObject.CompetitionId).FirstOrDefault().CompetitionName;

            // Create data for HOME team.
            fixtureDetails.HomeTeamObject = _context.Team.Where(x => x.TeamId == fixtureDetails.FixtureObject.HomeTeamId).FirstOrDefault();
            fixtureDetails.HomeTeamMembersList = new List<MemberModel>();
            var homeTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixtureDetails.FixtureObject.HomeTeamId).ToList();
            // Populate FixtureDetails object with HOME team members.
            foreach (MemberTeamModel member in homeTeamMembers)
            {
                // If the member is still part of the team.
                if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                {
                    var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                    fixtureDetails.HomeTeamMembersList.Add(memberDetails);
                }
            }

            // Create data for AWAY team.
            fixtureDetails.AwayTeamObject = _context.Team.Where(x => x.TeamId == fixtureDetails.FixtureObject.AwayTeamId).FirstOrDefault();
            fixtureDetails.AwayTeamMembersList = new List<MemberModel>();
            var awayTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixtureDetails.FixtureObject.AwayTeamId).ToList();
            // Populate FixtureDetails object with away AWAY members.
            foreach (MemberTeamModel member in awayTeamMembers)
            {
                // If the member is still part of the team.
                if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                {
                    var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                    fixtureDetails.AwayTeamMembersList.Add(memberDetails);
                }
            }

            // Get the period duration from the period table.
            var periodObject = _context.Period.Where(x => x.GameNumberOfPeriod == fixtureDetails.FixtureObject.MatchNumber).FirstOrDefault();
            fixtureDetails.PeriodDuration = periodObject.PeriodDuration;

            // Get current scores for each team in the fixture.
            fixtureDetails.Scores = await GetCurrentScores(fixtureDetails.FixtureObject.MatchNumber);

            // Return the fixture details object.
            return fixtureDetails;
        }

        /// <summary>
        /// Retrieves the latest period related to the fixture.
        /// </summary>
        /// <param name="id">The id of the fixture object the period is under</param>
        /// <returns>The current period model.</returns>        
        public async Task<PeriodModel> GetCurrentPeriod([FromRoute] Guid id)
        {
            // Return the latest period of the fixture.
            return await _context.Period.Where(x => x.GameNumberOfPeriod == id).OrderByDescending(x => x.PeriodNumber).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Creates a new period object for a particular fixture.
        /// </summary>
        /// <param name="fixtureId">The id of the fixture object the period will be created for.</param>
        /// <returns>The new period object which has been added to the database</returns>       

        public async Task<PeriodModel> AddNextPeriod(Guid fixtureId)
        {
            try
            {
                // Get the latest period number from the fixture.
                PeriodModel latestPeriod = _context.Period.Where(x => x.GameNumberOfPeriod == fixtureId).OrderByDescending(x => x.PeriodNumber).FirstOrDefault();
                int periodNumber = latestPeriod.PeriodNumber;

                int maxNumberOfPeriods = _context.Fixture.Where(x => x.MatchNumber == fixtureId).FirstOrDefault().NumberOfPeriods;

                // If the period number == the total number of periods allowed in the fixture.
                if (periodNumber >= maxNumberOfPeriods)
                {
                    // Then exit out of the API method.
                    throw new Exception("This was the final period of the game so a new one cannot be created.");
                }
                // The creation of a new period is valid.
                else
                {
                    //Create the next period for the fixture.
                    PeriodModel nextPeriod = new PeriodModel
                    {
                        PeriodId = Guid.NewGuid(),
                        GameNumberOfPeriod = fixtureId,
                        PeriodNumber = periodNumber + 1,
                        PeriodDuration = latestPeriod.PeriodDuration,
                        TimeRemaining = latestPeriod.TimeRemaining
                    };
                    nextPeriod.TimeRemaining = latestPeriod.TimeRemaining;

                    // Add the new period record to the database.
                    _context.Period.Add(nextPeriod);
                    await _context.SaveChangesAsync();

                    // Return this newly created period to the frontend.
                    return nextPeriod;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns the current scores for each team in a fixture.
        /// </summary>
        /// <param name="id">The fixture id.</param>
        /// <returns>A total score for each team in the fixture</returns>
        public async Task<FixtureScoresObject> GetCurrentScores([FromRoute] Guid id)
        {
            try
            {
                FixtureScoresObject scores = new FixtureScoresObject();
                // Get the fixture object.
                FixtureModel fixtureObject = _context.Fixture.Where(x => x.MatchNumber == id).FirstOrDefault();
                if (fixtureObject != null)
                {
                    // Get all periods related to the fixture.
                    var periodIds = await _context.Period.Where(x => x.GameNumberOfPeriod == id).Select(x => x.PeriodId).ToListAsync();


                    foreach (Guid periodId in periodIds)
                    {
                        // Get all gameplay stats from the game.
                        var periodStats = _context.GameplayStat.Where(x => x.PeriodId == periodId).ToList();
                        foreach (GameplayStatModel stat in periodStats)
                        {
                            List<ShotModel> shotStat = await _context.Shot.Where(x => x.ShotStatId == stat.StatId).ToListAsync();
                            // If the stat is a shot
                            if (shotStat.Any())
                            {
                                ShotModel shot = shotStat.FirstOrDefault();
                                // Check what team it is for.
                                Guid team = _context.MemberTeam.Where(x => x.MemberOfTeam == stat.StatMemberId).Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue).FirstOrDefault().TeamOfMember;

                                // If the stat belongs to the home team.
                                if (team == fixtureObject.HomeTeamId)
                                {
                                    // Add the points from the shot to the home team score
                                    scores.HomeScore += shot.ShotPoints;
                                }
                                // If the stat belongs to the away team.
                                else if (team == fixtureObject.AwayTeamId)
                                {
                                    // Add the points from the shot to the away team score
                                    scores.AwayScore += shot.ShotPoints;
                                }
                                else
                                {
                                    throw new Exception("This stat is not attached to either team from this fixture.");
                                }
                            }
                        }
                    }
                }
                // Return the scores.
                return scores;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Returns a list of the current oncourt players for each team in the fixture.
        /// </summary>
        /// <param name="id">The id of the fixture.</param>
        /// <returns>A players list object</returns>
        public async Task<PlayersListsObject> GetOncourtPlayers([FromRoute] Guid id)
        {
            try
            {
                // Create PlayersList object.
                var playersLists = new PlayersListsObject();

                // Create FixtureDetails object to extract oncourt players.
                var fixtureDetails = new FixtureDetails();

                FixtureModel fixtureObject = _context.Fixture.Where(x => x.MatchNumber == id).FirstOrDefault();

                // List of periods in descending order.
                var periods = _context.Period.Where(x => x.GameNumberOfPeriod == id).OrderByDescending(x => x.PeriodNumber).ToList();

                List<GameplayStatModel> mostRecentStats = new List<GameplayStatModel>();

                foreach (PeriodModel period in periods)
                {
                    // Get a list of all most recent stats.
                    var latestPeriodStats = _context.GameplayStat
                        .Where(x => x.PeriodId == period.PeriodId)
                        .OrderByDescending(x => x.Order)
                        .ToList();

                    //Foreach stat in the period
                    foreach (GameplayStatModel stat in latestPeriodStats)
                    {
                        // Add the stat to the list.
                        mostRecentStats.Add(stat);
                    }
                }
                // Get the stats of all oncourt players, from the game where the MemberId's are distinct.
                //mostRecentStats = mostRecentStats
                //    .GroupBy(x => x.StatMemberId)
                //        .Select(x => x.First())
                //        .Where(x => x.IsPlaying)
                //        .ToList();

                mostRecentStats = mostRecentStats.GroupBy(x => x.StatMemberId).ToList().Select(x => x.First()).ToList();
                mostRecentStats = mostRecentStats.Where(x => x.IsPlaying).ToList();


                var onCourtHomePlayers = new List<MemberModel>();
                var onCourtAwayPlayers = new List<MemberModel>();

                // Counter to only allow 5 players in list
                int homeCount = 0;
                int awayCount = 0;
                foreach (GameplayStatModel stat in mostRecentStats)
                {
                    if (homeCount <= 5 && awayCount <= 5)
                    {
                        MemberModel oncourtPlayer = _context.Member.Where(x => x.MemberId == stat.StatMemberId).FirstOrDefault();
                        MemberTeamModel oncourtMemberTeam = _context.MemberTeam.Where(x => x.MemberOfTeam == stat.StatMemberId)//Get the MemberTeam record of the player
                            .Where(x => x.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) //Where the member is still part of the team
                            .OrderByDescending(x => x.DateJoinedTeam).FirstOrDefault();//the latest one

                        if (oncourtMemberTeam.TeamOfMember == fixtureObject.HomeTeamId && homeCount < 5)
                        {
                            // Add player to oncourt list and increment counter by 1.
                            onCourtHomePlayers.Add(oncourtPlayer);
                            homeCount += 1;
                        }
                        else if (oncourtMemberTeam.TeamOfMember == fixtureObject.AwayTeamId && awayCount < 5)
                        {
                            // Add player to oncourt list and increment counter by 1.
                            onCourtAwayPlayers.Add(oncourtPlayer);
                            awayCount += 1;
                        }
                    }
                }

                // If the number of oncourt players on each team is uneven, throw an exception.
                if (onCourtAwayPlayers.Count != onCourtHomePlayers.Count)
                {
                    throw new Exception("The oncourt players on each team do not match");
                }

                var offCourtHomePlayers = new List<MemberModel>();
                var offCourtAwayPlayers = new List<MemberModel>();

                // Get the memberteam records for the home team.
                var homeTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixtureObject.HomeTeamId).ToList();
                // Populate FixtureDetails object with HOME team members.
                foreach (MemberTeamModel member in homeTeamMembers)
                {
                    //if the member is still part of the team
                    if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    {
                        // Create member object from MemberIds.
                        var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                        offCourtHomePlayers.Add(memberDetails);
                    }
                }

                // Get the memberteam records for the away team.
                var awayTeamMembers = _context.MemberTeam.Where(x => x.TeamOfMember == fixtureObject.AwayTeamId).ToList();
                // Populate FixtureDetails object with AWAY team members.
                foreach (MemberTeamModel member in awayTeamMembers)
                {
                    //if the member is still part of the team
                    if (member.DateLeftTeam == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue)
                    {
                        // Create member object from MemberIds.
                        var memberDetails = _context.Member.Where(x => x.MemberId == member.MemberOfTeam).FirstOrDefault();
                        offCourtAwayPlayers.Add(memberDetails);
                    }
                }
                // Remove oncourt players from lists.
                offCourtHomePlayers = offCourtHomePlayers.Except(onCourtHomePlayers).ToList();
                offCourtAwayPlayers = offCourtAwayPlayers.Except(onCourtAwayPlayers).ToList();


                // Populate the players lists.
                playersLists.HomeOncourtMembersList = onCourtHomePlayers;
                playersLists.HomeOffcourtMembersList = offCourtHomePlayers;
                playersLists.AwayOncourtMembersList = onCourtAwayPlayers;
                playersLists.AwayOffcourtMembersList = offCourtAwayPlayers;

                var fixture = await _context.Fixture.FindAsync(id);

                if (fixture == null)
                {
                    return playersLists;
                }

                return playersLists;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Adds a new fixture to the database.
        /// </summary>
        /// <param name="form">The new fixture object to be created.</param>
        /// <returns>A Task.</returns>
        public async Task AddFixture([FromBody] FixtureObject form)
        {
            try
            {
                // Create new fixture object using values from the form.
                FixtureModel fixture = new FixtureModel
                {
                    MatchNumber = Guid.NewGuid(),
                    CompetitionId = form.CompetitionId,
                    FixtureStartTime = form.FixtureStartTime,
                    CourtVenue = form.CourtVenue,
                    HomeTeamId = form.HomeTeamId,
                    AwayTeamId = form.AwayTeamId,
                    NumberOfPeriods = form.NumberOfPeriods
                };

                _context.Fixture.Add(fixture);
                await _context.SaveChangesAsync();

                // Create first period object for game - remaining periods will be generated programatically using API request during the game.
                PeriodModel period = new PeriodModel
                {
                    PeriodId = Guid.NewGuid(),
                    GameNumberOfPeriod = fixture.MatchNumber,
                    PeriodNumber = 1,
                    PeriodDuration = form.PeriodDuration,
                    TimeRemaining = form.PeriodDuration * 60
                };

                _context.Period.Add(period);
                await _context.SaveChangesAsync();

                // Create substitution records for starting five for home team.
                foreach (int memberId in form.HomeStartingFive)
                {
                    Guid statId = Guid.NewGuid();
                    DateTime today = DateTime.Now;
                    GameplayStatModel stat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = period.PeriodId,
                        // Time of stat is first minute of period == period duration.
                        TimeOfStat = form.PeriodDuration * 60000,
                        IsPlaying = true
                    };

                    // Save changes to database.
                    _context.GameplayStat.Add(stat);
                    await _context.SaveChangesAsync();
                }

                // Create substitution records for starting five for away team.
                foreach (int memberId in form.AwayStartingFive)
                {
                    Guid statId = Guid.NewGuid();
                    DateTime today = DateTime.Now;
                    GameplayStatModel stat = new GameplayStatModel
                    {
                        StatId = statId,
                        StatMemberId = memberId,
                        StatCategory = "substitution",
                        PeriodId = period.PeriodId,
                        // Time of stat is first minute of period == period duration.
                        TimeOfStat = form.PeriodDuration * 60000,
                        IsPlaying = true
                    };

                    // Save changes to database.
                    _context.GameplayStat.Add(stat);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /// <summary>
        /// Deletes a fixture from the database for a given id.
        /// </summary>
        /// <param name="id">The id of the fixture to be deleted.</param>
        /// <returns>A Task.</returns>
        public async Task DeleteFixture([FromRoute] Guid id)
        {
            try
            {
                //get fixture object
                var fixtureObject = _context.Fixture.Where(x => x.MatchNumber == id).FirstOrDefault();

                if (fixtureObject != null)
                {

                    //get all periods associated with fixture
                    var fixturePeriods = _context.Period.Where(x => x.GameNumberOfPeriod == id).ToList();

                    //get all statistics associated with periods
                    List<GameplayStatModel> statistics = new List<GameplayStatModel>();

                    //for each period in the fixture - loop through and create a list of all gameplay stats
                    foreach (PeriodModel period in fixturePeriods)
                    {
                        //create list of all stats in each period
                        var gameplayStats = _context.GameplayStat.Where(x => x.PeriodId == period.PeriodId).ToList();

                        // Add each stat to the list of fixture stats
                        statistics.AddRange(gameplayStats);
                    }

                    List<ShotModel> shots = new List<ShotModel>();
                    List<FoulModel> fouls = new List<FoulModel>();

                    // Foreach stat, check if there are any other related stat tables related to the stat model.
                    foreach (GameplayStatModel stat in statistics)
                    {
                        // See if there are any shot records related to the stat.
                        var shot = _context.Shot.Where(x => x.ShotStatId == stat.StatId).FirstOrDefault();
                        // See if there are any foul records related to the stat.
                        var foul = _context.Foul.Where(x => x.FoulStatId == stat.StatId).FirstOrDefault();

                        // If there is a related shot stat.
                        if (shot != null)
                        {
                            // Add it to the shots list.
                            shots.Add(shot);
                        }
                        else if (foul != null)
                        {
                            // Add it to the fouls list.
                            fouls.Add(foul);
                        }
                    }

                    if (shots != null)
                    {
                        // Remove the list of shot records from the database.
                        _context.Shot.RemoveRange(shots);
                        await _context.SaveChangesAsync();
                    }

                    if (fouls != null)
                    {
                        // Remove the list of foul records from the database.
                        _context.Foul.RemoveRange(fouls);
                        await _context.SaveChangesAsync();
                    }

                    // Remove list of stats.
                    _context.GameplayStat.RemoveRange(statistics);
                    await _context.SaveChangesAsync();

                    // Remove periods from database.
                    _context.Period.RemoveRange(fixturePeriods);
                    await _context.SaveChangesAsync();

                    // Remove fixture from database
                    _context.Fixture.Remove(fixtureObject);
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
