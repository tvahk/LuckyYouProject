using System.Web.Mvc;

namespace WebService.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Vertigo Web API";
            return View();
        }
    }
}
