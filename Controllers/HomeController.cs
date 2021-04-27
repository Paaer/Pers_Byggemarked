using ClassLibrary_Byggemarked;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication_Byggemarked.Controllers
{
    public class HomeController : Controller
    {
        ByggemarkedRigtigEntities db = new ByggemarkedRigtigEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email)
        {
            KundeSet kunde = db.KundeSet.Find(email);
           
            
            return RedirectToAction("Edit/" + kunde.Email + "/", "KundeSets");
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