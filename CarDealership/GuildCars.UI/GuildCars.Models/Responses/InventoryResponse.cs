using GuildCars.Models.Queries;
using System.Collections.Generic;

namespace GuildCars.Models.Responses
{
    public class InventoryResponse : Response
    {
        public List<InventoryReport> Report { get; set; }
    }
}
