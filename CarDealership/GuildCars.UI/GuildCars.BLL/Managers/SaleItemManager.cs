using GuildCars.BLL.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Responses;
using GuildCars.Models.Tables;
using System.Linq;

namespace GuildCars.BLL.Managers
{
    public class SaleItemManager
    {
        private ISaleItemRepository Repo { get; set; }

        public SaleItemManager(ISaleItemRepository saleItemRepository)
        {
            Repo = saleItemRepository;
        }

        public SaleItemResponse Add(SaleItem saleItem)
        {
            var response = new SaleItemResponse();

            if (string.IsNullOrEmpty(saleItem.Email) && string.IsNullOrEmpty(saleItem.Phone))
            {
                response.Success = false;
                response.Message = "Email or Phone must be provided";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.FirstName))
            {
                response.Success = false;
                response.Message = "First name must be provided";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.LastName))
            {
                response.Success = false;
                response.Message = "Last name must be provided";
                return response;
            }

            var stateManager = StateManagerFactory.Create();
            var stateResponse = stateManager.Get(saleItem.StateId);

            if (!stateResponse.Success)
            {
                response.Success = false;
                response.Message = $"Could not find state in database matching state id {saleItem.StateId}";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.StateId))
            {
                response.Success = false;
                response.Message = "Must Provide State";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.Street1))
            {
                response.Success = false;
                response.Message = "Must Provide Address";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.City))
            {
                response.Success = false;
                response.Message = "Must Provide City";
                return response;
            }

            if (saleItem.Zipcode < 9999 || saleItem.Zipcode > 100000)
            {
                response.Success = false;
                response.Message = "Zipcode must be 5 digits";
                return response;
            }

            if (string.IsNullOrEmpty(saleItem.UserId))
            {
                response.Success = false;
                response.Message = "No User ID assigned to sale item";
                return response;
            }

            if (saleItem.VIN.Count() != 17)
            {
                response.Success = false;
                response.Message = "VIN must be 17 characters";
                return response;
            }

            var vehicleManager = VehicleManagerFactory.Create();

            var vehicleResponse = vehicleManager.GetVehicle(saleItem.VIN);

            if (!vehicleResponse.Success)
            {
                response.Success = false;
                response.Message = "Invalid VIN submitted";
                return response;
            }
            else
            {
                if (vehicleResponse.Vehicle.SalePrice * 0.95m > saleItem.PurchasePrice)
                {
                    response.Success = false;
                    response.Message = $"Purchase price cannot be less than {vehicleResponse.Vehicle.SalePrice * 0.95m}";
                    return response;
                }

                if (saleItem.PurchasePrice > vehicleResponse.Vehicle.MSRP)
                {
                    response.Success = false;
                    response.Message = $"Purchase price cannot be greater than MSRP: {vehicleResponse.Vehicle.MSRP}";
                    return response;
                }
            }




            response.SaleItem = Repo.Add(saleItem);

            if (response.SaleItem.SaleId == 0)
            {
                response.Success = false;
                response.Message = "Failed to add special to database";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
