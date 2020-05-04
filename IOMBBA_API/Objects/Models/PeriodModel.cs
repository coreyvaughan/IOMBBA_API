using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Period Table.
    /// </summary>
    public class PeriodModel
    {
        [Key]
        public Guid PeriodId { get; set; }

        [Required]
        public Guid GameNumberOfPeriod { get; set; }

        [Required]
        public int PeriodNumber { get; set; }

        [Required]
        public int PeriodDuration { get; set; }

        public int TimeRemaining { get; set; }
    }
}
