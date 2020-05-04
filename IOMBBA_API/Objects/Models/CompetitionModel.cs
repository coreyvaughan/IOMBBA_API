using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Competition Table.
    /// </summary>
    public class CompetitionModel
    {
        [Key]
        [Required]
        public Guid CompetitionId { get; set; }

        [Required]
        public string CompetitionName { get; set; }
    }
}
