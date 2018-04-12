using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class CarModelManager
    {
        private ICarModelRepository Repo { get; set; }

        public CarModelManager(ICarModelRepository carModelRepository)
        {
            Repo = carModelRepository;
        }


        public CarModelResponse GetModel(int id)
        {
            var response = new CarModelResponse();

            if (id == 0)
            {
                response.Success = false;
                response.Message = "Must provide a valid model id";
                return response;
            }

            response.CarModel = Repo.GetModel(id);

            if (response.CarModel == null)
            {
                response.Success = false;
                response.Message = $"No model found with id {id}";
                return response;
            }

            response.Success = true;
            return response;
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

        public CarModelResponse Add(CarModel model)
        {
            var response = new CarModelResponse();

            if(string.IsNullOrEmpty(model.ModelName))
            {
                response.Success = false;
                response.Message = "Model must have a name";
                return response;
            }

            if (model.Make.MakeId == 0)
            {
                response.Success = false;
                response.Message = "Model must have a make selected";
                return response;

            }

            if (string.IsNullOrEmpty(model.UserName))
            {
                response.Success = false;
                response.Message = "No Username assigned to model";
                return response;

            }

            if (string.IsNullOrEmpty(model.UserId))
            {
                response.Success = false;
                response.Message = "No User ID assigned to model";
                return response;

            }


            response.CarModel = Repo.Add(model);

            if (response.CarModel.ModelId == 0)
            {
                response.Success = false;
                response.Message = "Failed to add model to database";
                return response;
            }
            response.Success = true;
            return response;
        }

        public CarModelResponse GetModelsByMakeId(int id)
        {
            var response = new CarModelResponse();

            response.CarModels = Repo.GetModelsByMakeId(id);

            if (!response.CarModels.Any())
            {
                response.Success = false;
                response.Message = $"Failed to load models with make id {id}";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
