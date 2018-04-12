using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.UI.Models
{
    public class HomepageVM
    {
        public List<Vehicle> FeaturedVehicles { get; set; }
        public List<Special> Specials { get; set; }
    }
}