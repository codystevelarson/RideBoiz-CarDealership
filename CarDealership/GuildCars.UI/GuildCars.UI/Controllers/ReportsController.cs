using GuildCars.UI.Models;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            var model = new SearchVM();

            return View(model);
        }
    }
}