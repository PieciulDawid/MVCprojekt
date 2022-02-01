using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Lista produktów

            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model.CreateModel());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}