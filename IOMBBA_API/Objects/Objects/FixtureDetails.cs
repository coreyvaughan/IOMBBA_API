using Objects.Models;
using System.Collections.Generic;

namespace Objects.Objects
{
    /// <summary>
    /// Object to hold information related to a fixture
    /// </summary>
    public class FixtureDetails
    {
        public FixtureModel FixtureObject { get; set; }
        public TeamModel HomeTeamObject { get; set; }
        public List<MemberModel> HomeTeamMembersList { get; set; }
        public TeamModel AwayTeamObject { get; set; }
        public List<MemberModel> AwayTeamMembersList { get; set; }
        public int PeriodDuration { get; set; }
        public string CompetitionName { get; set; }
        public FixtureScoresObject Scores { get; set; }
    }
}
