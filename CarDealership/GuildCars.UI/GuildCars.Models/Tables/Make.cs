using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Tables
{
    public class Make
    {
        public int MakeId { get; set; }

        [StringLength(30, ErrorMessage ="Make name cannot exceed 30 characters")]
        public string MakeName { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
