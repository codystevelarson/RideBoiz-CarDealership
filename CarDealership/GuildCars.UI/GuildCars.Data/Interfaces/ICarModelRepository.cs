using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface ICarModelRepository
    {
        List<CarModel> GetModels();
        CarModel GetModel(int id);
        CarModel Add(CarModel carModel);
        List<CarModel> GetModelsByMakeId(int id);
    }
}
