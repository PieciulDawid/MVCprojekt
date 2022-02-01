using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _DbContext;

        public HomeController()
        {
        }

        public HomeController(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
        }

        public ApplicationDbContext DbContext
        {
            get => _DbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            set => _DbContext = value;
        }
        
        public ActionResult Index()
        {




            //Lista produktów

            HomeIndexViewModel model = new HomeIndexViewModel();
            model.CreateModel();

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