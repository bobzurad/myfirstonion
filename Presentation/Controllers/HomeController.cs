using System.Linq;
using System.Web.Mvc;
using Domain.Queries;
using Presentation.Models.Home;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        protected IJewelryQueries JewelryQueries { get; private set; }

        public HomeController(IJewelryQueries jewelryQueries)
        {
            //TODO: null checks
            JewelryQueries = jewelryQueries;
        }

        public ActionResult Index()
        {
            var count = JewelryQueries.All().Count();

            return View("Index", new IndexModel { Count = count });
        }

    }
}
