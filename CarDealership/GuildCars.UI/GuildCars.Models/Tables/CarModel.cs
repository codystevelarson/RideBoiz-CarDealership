using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class CarModel
    {
        public int ModelId { get; set; }

        public Make Make { get; set; }

        [StringLength(30, ErrorMessage = "Model name cannot exceed 30 characters")]
        public string ModelName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}

