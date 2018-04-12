using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface IInteriorRepository
    {
        List<Interior> GetAll();
        Interior Get(int id);
    }
}
