using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class HomepageVM
    {
        public List<Vehicle> FeaturedVehicles { get; set; }
        public List<Special> Specials { get; set; }
    }
}