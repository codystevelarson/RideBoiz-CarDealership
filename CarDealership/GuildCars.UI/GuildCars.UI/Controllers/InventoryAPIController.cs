using GuildCars.BLL.Factories;
using GuildCars.Models.Queries;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GuildCars.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/inventory/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string view, string vehicleSearch,decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            var manager = VehicleManagerFactory.Create();

            try
            {
                var parameters = new VehicleSearchParameters
                {
                    View = view,
                    VehicleSearch = vehicleSearch,
                    MinPrice = minPrice,
                    MaxPrice = maxPrice, 
                    MinYear = minYear,
                    MaxYear = maxYear
                };

                var response = manager.Search(parameters);

                if (response.Success)
                {
                    List<VehicleSearchVM> vehicles = new List<VehicleSearchVM>();
                    foreach(var vehicle in response.Vehicles)
                    {
                        VehicleSearchVM searchVM = new VehicleSearchVM
                        {
                            Vehicle = vehicle,
                            BodyType = vehicle.BodyStyle.ToString(),
                            Transmission = vehicle.Transmission.ToString()
                        };
                        vehicles.Add(searchVM);
                    }

                    return Ok(vehicles);
                }
                return Ok();

            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/get/models")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModelsByMakeId(int makeId)
        {
            var manager = CarModelManagerFactory.Create();

            try
            {
                var response = manager.GetModelsByMakeId(makeId);

                if (response.Success)
                {
                    return Ok(response.CarModels);
                }
                return Ok(); //do something if it is null

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Route("api/get/make")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetMakeByModelId(int modelId)
        {
            var manager = MakeManagerFactory.Create();

            try
            {
                var response = manager.GetMakeByModelId(modelId);

                if (response.Success)
                {
                    return Ok(response.Make);
                }
                return Ok(); //do something if it is null

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/report/inventoryNew")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetNewInventoryReport()
        {
            var manager = VehicleManagerFactory.Create();

            try
            {
                var response = manager.InventoryReport(true);
                if (response.Success)
                {
                    return Ok(response.Report);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/report/inventoryUsed")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetUsedInventoryReport()
        {
            var manager = VehicleManagerFactory.Create();

            try
            {
                var response = manager.InventoryReport(false);
                if (response.Success)
                {
                    return Ok(response.Report);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/report/lotValue")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetLotValue()
        {
            var manager = VehicleManagerFactory.Create();

            try
            {
                var response = manager.GetAll();

                if (response.Success)
                {
                    return Ok(response.Vehicles.Where(v => v.Sold == false).Sum(v => v.SalePrice));
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
