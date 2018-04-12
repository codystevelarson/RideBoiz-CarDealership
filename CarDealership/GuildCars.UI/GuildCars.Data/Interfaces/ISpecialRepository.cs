using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetSpecials();
        Special GetSpecial(int id);
        Special Add(Special special);
        void Delete(int id);
    }
}
