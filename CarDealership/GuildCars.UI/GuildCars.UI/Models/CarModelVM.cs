using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class CarModelVM
    {
        public List<CarModel> CarModels { get; set; }
        public CarModel CarModel { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }
    }
}