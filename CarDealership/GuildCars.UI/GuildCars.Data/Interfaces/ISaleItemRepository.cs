using GuildCars.Models.Tables;

namespace GuildCars.Data.Interfaces
{
    public interface ISaleItemRepository
    {
        SaleItem Add(SaleItem saleItem);
    }
}
