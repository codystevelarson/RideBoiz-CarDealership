using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class StateRepositoryTEST : IStateRepository
    {
        private List<State> _states;

        public StateRepositoryTEST()
        {
            _states = new List<State>
            {
                new State { StateId = "MN", StateName = "Minnesota" },
                new State { StateId = "WI", StateName = "Wisconsin" },
                new State { StateId = "SD", StateName = "South Dakota" },
                new State { StateId = "FL", StateName = "Florida" },
                new State { StateId = "CA", StateName = "California" }
            };
        }

        public State GetState(string stateId)
        {
            return _states.SingleOrDefault(s => s.StateId == stateId);
        }

        public List<State> GetStates()
        {
            return _states;
        }
    }
}
