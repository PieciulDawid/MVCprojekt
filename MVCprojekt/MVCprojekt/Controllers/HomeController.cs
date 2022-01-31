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
            var counter = DbContext.CounterModels.Find(1) ??
                          DbContext.CounterModels.Create();

            counter.Counter++;

            DbContext.CounterModels.Add(counter);
            
            return View();
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