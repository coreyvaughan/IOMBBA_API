using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Team Table.
    /// </summary>
    public class TeamModel
    {
        [Key]
        [Required]
        public Guid TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public string ShortTeamCode { get; set; }

        [Required]
        public string DominantKitColour { get; set; }

        public bool IsDeleted { get; set; }
    }
}
