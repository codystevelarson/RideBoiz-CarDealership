using GuildCars.Models.Enums;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SaleItemVM
    {
        public SaleItem SaleItem { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
    }
}