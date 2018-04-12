using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System.Collections.Generic;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle GetByVin(string vin);
        List<Vehicle> GetAll();
        List<Vehicle> GetAllUsed();
        List<Vehicle> GetAllNew();
        List<Vehicle> GetAllFeatured();
        Vehicle Add(Vehicle vehicle);
        Vehicle Edit(Vehicle vehicle);
        void Delete(string vin);
        List<Vehicle> Search(VehicleSearchParameters parameters);
        List<InventoryReport> InventoryNew();
        List<InventoryReport> InventoryUsed();

    }
}
