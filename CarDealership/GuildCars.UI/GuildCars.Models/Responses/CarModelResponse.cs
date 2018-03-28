using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Responses
{
    public class CarModelResponse : Response
    {
        public List<CarModel> CarModels { get; set; }
        public CarModel CarModel { get; set; }
    }
}
