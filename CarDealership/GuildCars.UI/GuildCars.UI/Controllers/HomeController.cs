using GuildCars.BLL.Factories;
using GuildCars.Models.Tables;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            if(vehicleResponse.Success == true)
            {
                model.FeaturedVehicles = vehicleResponse.Vehicles;
            }

            var specialManager = SpecialManagerFactory.Create();
            var specialResponse = specialManager.GetAll();
            if(specialResponse.Success == true)
            {
                model.Specials = specialResponse.Specials;
            }

            //What to do if success' are false??
            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            var model = new SpecialsVM();
            var manager = SpecialManagerFactory.Create();
            var specialResponse = manager.GetAll();
            if (specialResponse.Success == true)
            {
                model.Specials = specialResponse.Specials;
            }
            //What to do if success is false?? 
            return View(model);
        }

        [HttpGet]
        public ActionResult Contact(string vin)
        {
            var model = new ContactVM();
            if (vin != null)
            {
                model.Contact.VIN = vin;
            }
            return View(model);
        }
    }
}