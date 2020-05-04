using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Member Table.
    /// </summary>
    public class MemberModel
    {
        [Key]
        [Column(TypeName = "int")]
        public int MemberId { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Surname { get; set; }


        [Column(TypeName = "varchar(2)")]
        public string ShirtNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Position { get; set; }

        [Required]
        public bool IsPlayer { get; set; }

        [Required]
        public bool IsCoach { get; set; }

        [Required]
        public bool IsOfficial { get; set; }

        [Required]
        public bool IsTableOfficial { get; set; }

        public string RefQualifications { get; set; }

        public string TableQualifications { get; set; }

        public bool IsDeleted { get; set; }
    }
}
