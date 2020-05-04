using System;
using System.Collections.Generic;

namespace Objects.Objects
{
    /// <summary>
    /// Object to hold information related to a fixture.
    /// </summary>
    public class FixtureObject
    {
        public Guid MatchNumber { get; set; }
        public Guid CompetitionId { get; set; }
        public DateTime FixtureStartTime { get; set; }
        public string CourtVenue { get; set; }
        public int NumberOfPeriods { get; set; }
        public int PeriodDuration { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public List<int> HomeStartingFive { get; set; }
        public List<int> AwayStartingFive { get; set; }
    }
}