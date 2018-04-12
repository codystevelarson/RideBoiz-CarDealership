using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SaleItemVM
    {
        public SaleItem SaleItem { get; set; }
        public Vehicle Vehicle { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PurchaseTypes { get; set; }

    }
}