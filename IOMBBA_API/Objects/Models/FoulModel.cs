using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Foul Table.
    /// </summary>
    public class FoulModel
    {
        [Key]
        [Required]
        public Guid FoulId { get; set; }

        [Required]
        public Guid FoulStatId { get; set; }

        public string FoulType { get; set; }

        [Required]
        public int FoulMinute { get; set; }

        [Required]
        public int FreeThrowsAwarded { get; set; }
    }
}
