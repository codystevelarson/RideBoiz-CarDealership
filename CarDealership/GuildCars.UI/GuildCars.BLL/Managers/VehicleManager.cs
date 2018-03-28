using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.BLL.Managers
{
    public class VehicleManager
    {
        private IVehicleRepository Repo { get; set; }

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            Repo = vehicleRepository;
        }

        public VehicleListResponse GetAll()
        {
            var response = new VehicleListResponse();

            response.Vehicles = Repo.GetAll();
            
            if (response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any vehicles in database";
                return response;
            }
            response.Success = true;
            return response;
        }

        public VehicleListResponse GetAllNew()
        {
            var response = new VehicleListResponse();

            response.Vehicles = Repo.GetAllNew();

            if(response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any new vehicles in database";
            }
            if (response.Vehicles.Any(v => v.New == false))
            {
                response.Success = false;
                response.Message = "A used vehicle was returned from the database";
            }
            response.Success = true;
            return response;
        }

        public VehicleListResponse GetAllUsed()
        {
            var response = new VehicleListResponse();

            response.Vehicles = Repo.GetAllUsed();

            if(response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any used vehicles in database";
            }
            if(response.Vehicles.Any(v => v.New == true))
            {
                response.Success = false;
                response.Message = $"A veichle was returned from the database";
            }
            response.Success = true;
            return response;
        }

        public VehicleListResponse GetAllFeatured()
        {
            var response = new VehicleListResponse();

            response.Vehicles = Repo.GetAllFeatured();

            if (response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any featured vehicles in database";
            }
            if(response.Vehicles.Any(v => v.Featured == false))
            {
                response.Success = false;
                response.Message = "A non-featured vehicle was returned from the database";
            }
            response.Success = true;
            return response;
        }

        public VehicleResponse GetVehicle(string vin)
        {
            var response = new VehicleResponse();

            response.Vehicle = Repo.GetByVin(vin);

            if (response.Vehicle == null)
            {
                response.Success = false;
                response.Message = $"Could not find vehicle with vin: {vin} in database";
            }
            if (response.Vehicle.VIN != vin)
            {
                response.Success = true;
                response.Message = $"Vehicle vin {vin} was requested, but vehicle was returned with vin {response.Vehicle.VIN}";
            }
            response.Success = true;
            return response;
        }
    }
}
