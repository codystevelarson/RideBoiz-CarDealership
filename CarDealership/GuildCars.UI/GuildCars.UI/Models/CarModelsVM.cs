using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class CarModelsVM
    {
        public List<CarModel> CarModels { get; set; }
        public CarModel CarModel { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

    }
}