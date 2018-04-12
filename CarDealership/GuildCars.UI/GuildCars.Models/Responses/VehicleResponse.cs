using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Responses
{
    public class VehicleResponse : Response
    {
        public List<Vehicle> Vehicles { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
