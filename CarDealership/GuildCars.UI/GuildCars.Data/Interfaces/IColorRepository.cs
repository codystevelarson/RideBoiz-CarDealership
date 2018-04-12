using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface IColorRepository
    {
        List<Color> GetAll();
        Color Get(int id);
    }
}
