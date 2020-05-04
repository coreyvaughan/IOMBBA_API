using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Fixture Table.
    /// </summary>
    public class FixtureModel
    {
        [Key]
        [Required]
        public Guid MatchNumber { get; set; }

        [Required]
        public Guid CompetitionId { get; set; }

        [Required]
        public DateTime FixtureStartTime { get; set; }

        public string CourtVenue { get; set; }

        public int NumberOfPeriods { get; set; }

        public Guid HomeTeamId { get; set; }

        public Guid AwayTeamId { get; set; }
    }
}
