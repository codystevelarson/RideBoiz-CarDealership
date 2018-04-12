using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class CarModelRepositoryTEST : ICarModelRepository
    {
        private static List<CarModel> _models;

        public CarModelRepositoryTEST()
        {
            Make ford = new Make { MakeId = 1, MakeName = "Ford", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make chevy = new Make { MakeId = 2, MakeName = "Chevy", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make dodge = new Make { MakeId = 3, MakeName = "Dodge", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make saturn = new Make { MakeId = 4, MakeName = "Saturn", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };
            Make kia = new Make { MakeId = 5, MakeName = "Kia", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1" };

            _models = new List<CarModel>
            {
                new CarModel { ModelId = 1, ModelName = "Focus", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = ford},
                new CarModel { ModelId = 2, ModelName = "F150", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = ford},
                new CarModel { ModelId = 3, ModelName = "Challenger", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = dodge},
                new CarModel { ModelId = 4, ModelName = "Charger", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = dodge},
                new CarModel { ModelId = 5, ModelName = "Cruze", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = chevy},
                new CarModel { ModelId = 6, ModelName = "Silverado", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = chevy},
                new CarModel { ModelId = 7, ModelName = "VUE", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = saturn},
                new CarModel { ModelId = 8, ModelName = "ION", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = saturn},
                new CarModel { ModelId = 9, ModelName = "Sorento", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = kia},
                new CarModel { ModelId = 10, ModelName = "Optima", DateAdded = DateTime.Now, UserId = "A001", UserName = "Admin1", Make = kia}
            };
        }

        public CarModel Add(CarModel carModel)
        {
            if (_models.Any())
            {
                carModel.ModelId = _models.Max(m => m.ModelId) + 1;
            }
            else
            {
                carModel.ModelId = 1;
            }
            _models.Add(carModel);
            return carModel;
        }

        public CarModel GetModel(int id)
        {
            return _models.SingleOrDefault(m => m.ModelId == id);
        }

        public List<CarModel> GetModels()
        {
            return _models;
        }

        public List<CarModel> GetModelsByMakeId(int id)
        {
            return _models.Where(m => m.Make.MakeId == id).ToList();
        }
    }
}
