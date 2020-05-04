using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Objects.Models
{
    /// <summary>
    /// The object that maps onto the Shot Table.
    /// </summary>
    public class ShotModel
    {
        [Key]
        [Required]
        public Guid ShotId { get; set; }

        [Required]
        public Guid ShotStatId { get; set; }

        [Required]
        public int ShotPoints { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public string ShotType { get; set; }

        public bool FreeThrow { get; set; }
    }
}
