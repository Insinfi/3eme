using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Envoie_Ajax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string Identite)
        {
            return View();
        }
        public ActionResult Traitement(string Identite)
        {

            return View("Index");
        }
    }
}