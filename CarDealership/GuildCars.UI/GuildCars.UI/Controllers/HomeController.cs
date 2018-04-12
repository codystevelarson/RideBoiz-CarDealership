using GuildCars.BLL.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var model = new HomepageVM();

            var vehicleManager = VehicleManagerFactory.Create();
            var vehicleResponse = vehicleManager.GetAllFeatured();
            if(vehicleResponse.Success)
            {
                model.FeaturedVehicles = vehicleResponse.Vehicles;
            }

            var specialManager = SpecialManagerFactory.Create();
            var specialResponse = specialManager.GetAll();
            if(specialResponse.Success)
            {
                model.Specials = specialResponse.Specials;
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialVM();
            var manager = SpecialManagerFactory.Create();
            var specialResponse = manager.GetAll();
            if (specialResponse.Success == true)
            {
                model.Specials = specialResponse.Specials;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Contact(string vin)
        {
            var model = new ContactVM();

            if (!string.IsNullOrEmpty(vin))
            {
                model.Contact = new Contact
                {
                    VIN = vin
                };
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactVM model)
        {
            if (ModelState.IsValid)
            {
                var manager = ContactManagerFactory.Create();
                var response = manager.Add(model.Contact);
                if (response.Success == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}