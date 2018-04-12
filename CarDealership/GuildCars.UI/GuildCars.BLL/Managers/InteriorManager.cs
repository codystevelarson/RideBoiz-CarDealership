using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class InteriorManager
    {
        private IInteriorRepository Repo { get; set; }

        public InteriorManager(IInteriorRepository interiorRepository)
        {
            Repo = interiorRepository;
        }

        public InteriorResponse GetAll()
        {
            var response = new InteriorResponse();

            response.Interiors = Repo.GetAll();
            if (!response.Interiors.Any())
            {
                response.Success = false;
                response.Message = "Failed to load interiors from database";
                return response;
            }
            response.Success = true;
            return response;
        }

        public InteriorResponse Get(int id)
        {
            var response = new InteriorResponse();

            response.Interior = Repo.Get(id);
            if (response.Interior == null)
            {
                response.Success = false;
                response.Message = $"Failed to load interior from database with id: {id}";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
