using GuildCars.BLL.Factories;
using GuildCars.Models.Enums;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            var model = new SearchVM();
            return View(model);
        }

        [HttpGet]
        public ActionResult Purchase(string id)
        {
            var model = new SaleItemVM()
            {
                SaleItem = new SaleItem(),
                PurchaseTypes = Enum.GetValues(typeof(PurchaseType)).Cast<PurchaseType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList()
            };

            var manager = StateManagerFactory.Create();
            var stateResponse = manager.GetAll();

            if (stateResponse.Success)
            {
                model.States = stateResponse.States.Select(m => new SelectListItem
                {
                    Value = m.StateId,
                    Text = m.StateName
                });

                model.SaleItem.VIN = id;
                var vehicleManager = VehicleManagerFactory.Create();
                var response = vehicleManager.GetVehicle(id);

                if (response.Success)
                {
                    model.Vehicle = response.Vehicle;
                    return View(model);
                }
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult Purchase(SaleItemVM model)
        {
            if (ModelState.IsValid)
            {
                var manager = SaleItemManagerFactory.Create();

                model.SaleItem.UserId = User.Identity.GetUserId();

                var response = manager.Add(model.SaleItem);

                if (response.Success)
                {
                    return RedirectToAction("Index");
                }
            }

            var vehicleManager = VehicleManagerFactory.Create();
            var vehicleResponse = vehicleManager.GetVehicle(model.SaleItem.VIN);
            if (vehicleResponse.Success)
            {
                model.Vehicle = vehicleResponse.Vehicle;
            }
            else
            {
                return RedirectToAction("Index");
            }


            var stateManager = StateManagerFactory.Create();
            var stateResponse = stateManager.GetAll();
            if (stateResponse.Success)
            {
                model.States = stateResponse.States.Select(m => new SelectListItem
                {
                    Value = m.StateId,
                    Text = m.StateName
                });

                model.PurchaseTypes = Enum.GetValues(typeof(PurchaseType)).Cast<PurchaseType>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();

                return View(model);
            }
            else
            {
                return View("Index");
            }
        }
    }
}