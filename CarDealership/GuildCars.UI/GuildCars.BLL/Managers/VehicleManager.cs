using GuildCars.BLL.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class VehicleManager
    {
        private IVehicleRepository Repo { get; set; }

        public VehicleManager(IVehicleRepository vehicleRepository)
        {
            Repo = vehicleRepository;
        }

        public VehicleResponse GetAll()
        {
            var response = new VehicleResponse();

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

        public VehicleResponse GetAllNew()
        {
            var response = new VehicleResponse();

            response.Vehicles = Repo.GetAllNew();

            if (response.Vehicles == null)
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

        public VehicleResponse GetAllUsed()
        {
            var response = new VehicleResponse();

            response.Vehicles = Repo.GetAllUsed();

            if (response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any used vehicles in database";
            }
            if (response.Vehicles.Any(v => v.New == true))
            {
                response.Success = false;
                response.Message = $"A veichle was returned from the database";
            }
            response.Success = true;
            return response;
        }

        public VehicleResponse GetAllFeatured()
        {
            var response = new VehicleResponse();

            response.Vehicles = Repo.GetAllFeatured();

            if (response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Could not find any featured vehicles in database";
            }
            if (response.Vehicles.Any(v => v.Featured == false))
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

            if(vin.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            response.Vehicle = Repo.GetByVin(vin);
            if(response.Vehicle == null)
            {
                response.Success = false;
                response.Message = "Error loading vehicle from database";
                return response;
            }

            if (response.Vehicle.VIN == null)
            {
                response.Success = false;
                response.Message = $"Could not find vehicle with vin: {vin} in database";
                return response;
            }
            if (response.Vehicle.VIN != vin)
            {
                response.Success = true;
                response.Message = $"Vehicle vin {vin} was requested, but vehicle was returned with vin {response.Vehicle.VIN}";
                return response;
            }
            response.Success = true;
            return response;
        }

        public VehicleResponse Add(Vehicle vehicle)
        {
            var response = new VehicleResponse();

            //Validate
            if (vehicle.VIN.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            var checkVin = GetVehicle(vehicle.VIN);
            

            if (checkVin.Success)
            {
                response.Success = false;
                response.Message = "VIN already exists";
                return response;
            }


            if (vehicle.Year < 2000 || vehicle.Year > DateTime.Now.Year + 1)
            {
                response.Success = false;
                response.Message = "Year must be between 2000 and 1 year from now";
                return response;
            }


            if (vehicle.Model.ModelId == 0 || vehicle.Model == null)
            {
                response.Success = false;
                response.Message = "Must provide a model";
                return response;
            }

            var modelManager = CarModelManagerFactory.Create();
            var modelResponse = modelManager.GetModel(vehicle.Model.ModelId);

            if (!modelResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find model in database";
                return response;
            }


            if (vehicle.Model.Make.MakeId == 0 || vehicle.Model.Make == null)
            {
                response.Success = false;
                response.Message = "Must provide a make";
                return response;
            }

            var makeManager = MakeManagerFactory.Create();
            var makeResponse = makeManager.GetMake(vehicle.Model.Make.MakeId);

            if (!makeResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find make in database";
                return response;
            }


            var makeModelResponse = modelManager.GetModelsByMakeId(vehicle.Model.Make.MakeId);

            if (makeModelResponse.Success)
            {
                if (!makeModelResponse.CarModels.Any(m => m.ModelId == vehicle.Model.ModelId))
                {
                    response.Success = false;
                    response.Message = $"Model id {vehicle.Model.ModelId} does not match with make id {vehicle.Model.Make.MakeId} ";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"Could not find models with make id {vehicle.Model.Make.MakeId}";
                return response;
            }
            

            if (vehicle.BodyStyle == 0)
            {
                response.Success = false;
                response.Message = "Must provide a body type";
                return response;
            }
            
            if (vehicle.Transmission == 0)
            {
                response.Success = false;
                response.Message = "Must provide a transmission type";
                return response;
            }

            if (vehicle.Color.ColorId == 0)
            {
                response.Success = false;
                response.Message = "Must provide a color";
                return response;
            }

            var colorManager = ColorManagerFactory.Create();
            var colorResponse = colorManager.Get(vehicle.Color.ColorId);

            if (!colorResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find color in database";
                return response;
            }


            if (vehicle.Interior.InteriorId == 0)
            {
                response.Success = false;
                response.Message = "Must provide an interior";
                return response;
            }

            var interiorManager = InteriorManagerFactory.Create();
            var interiorResponse = interiorManager.Get(vehicle.Interior.InteriorId);

            if (!interiorResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find interior in database";
                return response;
            }

            if (vehicle.Mileage > 1000 && vehicle.New)
            {
                response.Success = false;
                response.Message = "New vehicles' mileage cannot exceed 1000";
                return response;
            }

            if (vehicle.Mileage < 1000 && !vehicle.New)
            {
                response.Success = false;
                response.Message = "Used vehicles' mileage cannot be less than 1000";
                return response;
            }

            if (vehicle.SalePrice > vehicle.MSRP)
            {
                response.Success = false;
                response.Message = "Sale price cannot be greater than MSRP";
                return response;
            }

            if (string.IsNullOrEmpty(vehicle.Description))
            {
                response.Success = false;
                response.Message = "Must provide a description";
                return response;
            }

            if (string.IsNullOrEmpty(vehicle.ImageFileName))
            {
                response.Success = false;
                response.Message = "Must provide an image file name";
                return response;
            }

            response.Vehicle = Repo.Add(vehicle);

            if (response.Vehicle.VIN == null)
            {
                response.Success = false;
                response.Message = "Failed to add vehicle to database";
                return response;
            }
            response.Success = true;
            return response;
        }




        public VehicleResponse Edit(Vehicle vehicle)
        {
            var response = new VehicleResponse();

            //Validate
            if (vehicle.VIN.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            var checkVin = GetVehicle(vehicle.VIN);

            if (!checkVin.Success)
            {
                response.Success = false;
                response.Message = "VIN already exists";
                return response;
            }


            if (vehicle.Year < 2000 || vehicle.Year > DateTime.Now.Year + 1)
            {
                response.Success = false;
                response.Message = "Year must be between 2000 and 1 year from now";
                return response;
            }


            if (vehicle.Model.ModelId == 0 || vehicle.Model == null)
            {
                response.Success = false;
                response.Message = "Must provide a model";
                return response;
            }

            var modelManager = CarModelManagerFactory.Create();
            var modelResponse = modelManager.GetModel(vehicle.Model.ModelId);

            if (!modelResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find model in database";
                return response;
            }


            if (vehicle.Model.Make.MakeId == 0 || vehicle.Model.Make == null)
            {
                response.Success = false;
                response.Message = "Must provide a make";
                return response;
            }

            var makeManager = MakeManagerFactory.Create();
            var makeResponse = makeManager.GetMake(vehicle.Model.Make.MakeId);

            if (!makeResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find make in database";
                return response;
            }


            var makeModelResponse = modelManager.GetModelsByMakeId(vehicle.Model.Make.MakeId);

            if (makeModelResponse.Success)
            {
                if (!makeModelResponse.CarModels.Any(m => m.ModelId == vehicle.Model.ModelId))
                {
                    response.Success = false;
                    response.Message = $"Model id {vehicle.Model.ModelId} does not match with make id {vehicle.Model.Make.MakeId} ";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = $"Could not find models with make id {vehicle.Model.Make.MakeId}";
                return response;
            }

            if (vehicle.BodyStyle == 0)
            {
                response.Success = false;
                response.Message = "Must provide a body type";
                return response;
            }

            if (vehicle.Transmission == 0)
            {
                response.Success = false;
                response.Message = "Must provide a transmission type";
                return response;
            }

            if (vehicle.Color.ColorId == 0)
            {
                response.Success = false;
                response.Message = "Must provide a color";
                return response;
            }

            var colorManager = ColorManagerFactory.Create();
            var colorResponse = colorManager.Get(vehicle.Color.ColorId);

            if (!colorResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find color in database";
                return response;
            }

            if (vehicle.Interior.InteriorId == 0)
            {
                response.Success = false;
                response.Message = "Must provide an interior";
                return response;
            }

            var interiorManager = InteriorManagerFactory.Create();
            var interiorResponse = interiorManager.Get(vehicle.Interior.InteriorId);

            if (!interiorResponse.Success)
            {
                response.Success = false;
                response.Message = "Could not find interior in database";
                return response;
            }

            if (vehicle.Mileage > 1000 && vehicle.New)
            {
                response.Success = false;
                response.Message = "New vehicles' mileage cannot exceed 1000";
                return response;
            }

            if (vehicle.Mileage < 1000 && !vehicle.New)
            {
                response.Success = false;
                response.Message = "Used vehicles' mileage cannot be less than 1000";
                return response;
            }

            if (vehicle.SalePrice > vehicle.MSRP)
            {
                response.Success = false;
                response.Message = "Sale price cannot be greater than MSRP";
                return response;
            }

            if (string.IsNullOrEmpty(vehicle.Description))
            {
                response.Success = false;
                response.Message = "Must provide a description";
                return response;
            }

            response.Vehicle = Repo.Edit(vehicle);

            if (response.Vehicle == null)
            {
                response.Success = false;
                response.Message = "Failed to edit vehicle to database";
                return response;
            }
            response.Success = true;
            return response;
        }




        public VehicleResponse Delete(string vin)
        {
            var response = new VehicleResponse();

            if (vin.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            var checkVin = GetVehicle(vin);

            if (!checkVin.Success)
            {
                response.Success = false;
                response.Message = "VIN already exists";
                return response;
            }

            Repo.Delete(vin);

            response.Vehicle = Repo.GetByVin(vin);

            if (response.Vehicle != null)
            {
                if (response.Vehicle.VIN != null)
                {
                    response.Success = false;
                    response.Message = "Failed to delete vehicle from database";
                    return response;
                }

                response.Success = false;
                response.Message = "Failed to delete vehicle from database";
                return response;
            }

            
            response.Success = true;
            return response;
        }

        public VehicleResponse Search(VehicleSearchParameters parameters)
        {
            var response = new VehicleResponse();

            response.Vehicles = Repo.Search(parameters);

            if (response.Vehicles == null)
            {
                response.Success = false;
                response.Message = "Found no matching vehicles";
                return response;
            }
            response.Success = true;
            return response;
        }


        public InventoryResponse InventoryReport(bool newInventory)
        {
            var response = new InventoryResponse();

            if(newInventory)
            {
                response.Report = Repo.InventoryNew();
            }
            else
            {
                response.Report = Repo.InventoryUsed();
            }

            if(!response.Report.Any())
            {
                response.Success = false;
                response.Message = "Failed returning data from database";
                return response;
            }

            response.Success = true;
            return response;

        }

    }
}
