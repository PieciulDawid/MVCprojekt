using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCprojekt.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Contact()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Contact(string body)
        {
            var subject = User.Identity.Name;
            var useremail = "aspnetmvcprojekt@gmail.com";
            WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "Wysłano email";
            return View();
        }
    }
}