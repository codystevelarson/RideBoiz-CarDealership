using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Special
    {
        public int SpecialId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Special name cannot exceed 30 characters")]
        public string SpecialName { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Description cannot exceed 250 characters")]
        public string Description { get; set; }

        public string ImageFileName { get; set; }
    }
}
