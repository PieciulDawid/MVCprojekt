using System.Net;
using System.Web.Mvc;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
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
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        public ActionResult AddToCart(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var productModel = db.ProductModels.Find(id);

            if (productModel == null) return HttpNotFound();

            CartUtil.AddToCart(CartUtil.GetCartDict(Session), id.Value, 1);

            return RedirectToAction("Index");
        }
    }
}