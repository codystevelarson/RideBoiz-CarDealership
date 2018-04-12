using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface IStateRepository
    {
        State GetState(string stateId);
        List<State> GetStates();
    }
}
