using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookieCookie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCookie()
        {
            string Nom = string.Empty;
            if (Request.Cookies["Nom"]!= null)
            {
                Nom = Request.Cookies["Nom"].Value;
                DateTime expire = DateTime.Now;
                expire.AddDays(10);
                Response.Cookies["Histo"].Value = "test";
                Response.Cookies["Histo"].Expires = expire;

            }
            return View("Index");
        }
    }
}