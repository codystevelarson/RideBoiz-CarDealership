using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class SpecialsVM
    {
        public List<Special> Specials { get; set; }
        public Special newSpecial { get; set; }
    }
}