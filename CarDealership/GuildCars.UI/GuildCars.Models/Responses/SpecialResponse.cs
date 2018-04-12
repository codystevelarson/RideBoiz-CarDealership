using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Responses
{
    public class SpecialResponse : Response
    {
        public List<Special> Specials { get; set; }
        public Special Special { get; set; }
    }
}
