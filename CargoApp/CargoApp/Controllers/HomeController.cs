using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoApp.Models;

namespace CargoApp.Controllers
{
    public class HomeController : Controller
    {   
        // GET: Home
        public ActionResult Index()
        {
            //using (CargoContext context = new CargoContext())
            //{
            //    context.SaveChanges();
            //}

            return View();
        }

    }
}