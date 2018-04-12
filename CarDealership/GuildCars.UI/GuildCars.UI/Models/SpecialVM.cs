using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialVM
    {
        public List<Special> Specials { get; set; }
        public Special Special { get; set; }

        [Required]
        //[RegularExpression("([^\\s]+(\\.(?i)(jpg|png|jpeg))$)", ErrorMessage ="File must be .jpg, .jpeg, or .png")]
        public HttpPostedFileBase SpecialImage { get; set; }
    }
}