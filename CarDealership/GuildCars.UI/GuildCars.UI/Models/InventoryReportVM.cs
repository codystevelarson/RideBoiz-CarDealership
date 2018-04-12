using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.UI.Models
{
    public class InventoryReportVM
    {
        public List<Vehicle> Vehicle { get; set; }
        public decimal Total { get; set; }
    }
}