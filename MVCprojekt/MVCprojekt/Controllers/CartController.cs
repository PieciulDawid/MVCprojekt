using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCprojekt.Controllers
{
    public class CartController : Controller
    {
        // GET
        public ActionResult Index()
        {
            List<int> list;
            if (Session["koszyk"] == null)
            {
                list = new List<int>();
            }
            else
            {
                list = (List<int>) Session["koszyk"];
            }
            list.Add(list.Count);
            
            Session["koszyk"] = list;
            return View();
        }
    }
}