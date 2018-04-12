using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class SaleItemRepositoryTEST : ISaleItemRepository
    {
        private static List<SaleItem> _saleItems;

        public SaleItemRepositoryTEST()
        {
            _saleItems = new List<SaleItem>();
        }

        public SaleItem Add(SaleItem saleItem)
        {
            if (_saleItems.Any())
            {
                saleItem.SaleId = _saleItems.Max(s => s.SaleId) + 1;
            }
            else
            {
                saleItem.SaleId = 1;
            }
            _saleItems.Add(saleItem);
            return saleItem;
        }
    }
}
