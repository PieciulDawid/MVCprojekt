using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            //TODO tu wstawić email użytkownika naj jaki można odesłać odpoweidź
            string subject = "Email użytkownika";
            string useremail = "aspnetmvcprojekt@gmail.com";
            WebMail.Send(useremail, subject, body, null, null, null, true, null, null, null, null, null, null);
            ViewBag.msg = "Wysłano email";
            return View();
        }
    }
}