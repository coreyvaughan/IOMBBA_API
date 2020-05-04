using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the GameplayStat Table.
    /// </summary>
    public class GameplayStatModel
    {
        [Key]
        [Required]
        public Guid StatId { get; set; }

        [Required]
        public int StatMemberId { get; set; }

        public string StatCategory { get; set; }

        [Required]
        public Guid PeriodId { get; set; }

        [Required]
        public int TimeOfStat { get; set; }

        [Required]
        public bool IsPlaying { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order { get; set; }
    }
}
