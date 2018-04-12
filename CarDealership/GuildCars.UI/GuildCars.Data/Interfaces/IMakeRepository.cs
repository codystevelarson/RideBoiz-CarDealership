using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface IMakeRepository
    {
        List<Make> GetMakes();
        Make GetMake(int makeId);
        Make Add(Make make);
        Make GetMakeByModelId(int id);
    }
}
