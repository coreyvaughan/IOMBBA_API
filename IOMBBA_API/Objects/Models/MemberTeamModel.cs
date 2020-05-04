using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the MemberTeam Table.
    /// </summary>
    public class MemberTeamModel
    {
        [Key]
        [Required]
        public Guid MemberTeamId { get; set; }

        [Required]
        public Guid TeamOfMember { get; set; }

        [Required]
        public int MemberOfTeam { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime DateJoinedTeam { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateLeftTeam { get; set; }

        public bool IsDeleted { get; set; }
    }
}
