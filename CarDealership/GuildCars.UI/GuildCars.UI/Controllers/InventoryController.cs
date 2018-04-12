using GuildCars.BLL.Factories;
using GuildCars.UI.Models;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult New()
        {
            var model = new SearchVM();
            return View(model);
        }

        [HttpGet]
        public ActionResult Used()
        {
            var model = new SearchVM();
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var model = new VehicleVM();
            var manager = VehicleManagerFactory.Create();
            var response = manager.GetVehicle(id);

            if (response.Success == true)
            {
                model.Vehicle = response.Vehicle;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}