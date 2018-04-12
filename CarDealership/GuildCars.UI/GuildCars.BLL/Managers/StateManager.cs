using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;

namespace GuildCars.BLL.Managers
{
    public class StateManager
    {
        private IStateRepository Repo { get; set; }

        public StateManager(IStateRepository stateRepository)
        {
            Repo = stateRepository;
        }

        public StateResponse GetAll()
        {
            var response = new StateResponse();
            response.States = Repo.GetStates();

            if (response.States == null)
            {
                response.Success = false;
                response.Message = "Could not find any states in database";
                return response;
            }
            response.Success = true;
            return response;
        }

        public StateResponse Get(string id)
        {
            var response = new StateResponse();
            response.State = Repo.GetState(id);

            if (response.State == null)
            {
                response.Success = false;
                response.Message = $"Could not find state {id} in database";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
