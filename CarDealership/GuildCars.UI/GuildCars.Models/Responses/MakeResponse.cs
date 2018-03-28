using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Responses
{
    public class MakeResponse : Response
    {
        public List<Make> Makes { get; set; }
    }
}
