using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Responses
{
    public class InteriorResponse : Response
    {
        public List<Interior> Interiors { get; set; }
        public Interior Interior { get; set; }
    }
}
