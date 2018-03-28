using GuildCars.BLL.Factories;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    [Authorize(Roles = "Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Purchase(string vin)
        {
            var model = new SaleItemVM();
            model.SaleItem.VIN = vin;
            var manager = StateManagerFactory.Create();
            var stateResponse = manager.GetAll();

            model.States = stateResponse.States.Select(m => new SelectListItem
            {
                Value = m.StateId,
                Text = m.StateName
            });

            return View(model);
        }
    }
}