using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Managers
{
    public class CarModelManager
    {
        private ICarModelRepository Repo { get; set; }

        public CarModelManager(ICarModelRepository carModelRepository)
        {
            Repo = carModelRepository;
        }


        public CarModelResponse GetAll()
        {
            var response = new CarModelResponse();

            response.CarModels = Repo.GetModels();

            if(response.CarModels == null)
            {
                response.Success = false;
                response.Message = "Cound not find any models in database";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
