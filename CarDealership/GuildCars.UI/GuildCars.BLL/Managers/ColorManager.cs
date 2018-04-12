using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class ColorManager
    {
        private IColorRepository Repo { get; set; }

        public ColorManager(IColorRepository colorRepository)
        {
            Repo = colorRepository;
        }

        public ColorResponse GetAll()
        {
            var response = new ColorResponse();

            response.Colors = Repo.GetAll();
            if(!response.Colors.Any())
            {
                response.Success = false;
                response.Message = "Failed to load colors from database";
                return response;
            }
            response.Success = true;
            return response;
        }

        public ColorResponse Get(int id)
        {
            var response = new ColorResponse();

            response.Color = Repo.Get(id);
            if (response.Color == null)
            {
                response.Success = false;
                response.Message = $"Failed to load color from database with id: {id}";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
