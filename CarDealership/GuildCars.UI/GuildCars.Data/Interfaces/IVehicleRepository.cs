using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface IVehicleRepository
    {
        Vehicle GetByVin(string VIN);
        List<Vehicle> GetAll();
        List<Vehicle> GetAllUsed();
        List<Vehicle> GetAllNew();
        List<Vehicle> GetAllFeatured();
    }
}
