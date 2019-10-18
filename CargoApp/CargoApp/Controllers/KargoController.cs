using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CargoApp.Models;
using CargoApp.ViewModels;

namespace CargoApp.Controllers
{
    public class KargoController : Controller
    {
        private readonly CargoContext _context = new CargoContext(); // 4521 9856 25

        // GET: Kargo
        public ActionResult KargoTakip()
        {
            return View();
        }

        // _ GetCargoResult partialview'ı için
        [HttpGet]
        public PartialViewResult GetCargoPartialView(string cargoNumber)
        {
            //Include("Category").Include("CargoStatus")
            Cargo getCargo = _context.Cargo.FirstOrDefault(x => x.CargoNumber == cargoNumber);
            if (getCargo != null)
            {
                return PartialView("_GetCargoResult", getCargo);
            }
            else
            {
                ViewBag.Information = "Değer null geldi";
            }
            
            return PartialView();
        }

        // _GetCargoProcess partialview'ı için
        [HttpGet]
        public PartialViewResult GetCargoProcessPartialView(int id)
        {

            var getProcess = _context.CargoProcess.OrderBy(x => x.CargoProcessId).Take(id).OrderByDescending(x => x.CargoProcessId).Take(2).OrderBy(x=>x.CargoProcessId).ToList();
         
            if (getProcess != null)
            {
                return PartialView("_GetCargoProcess",getProcess);
            }
           
            return PartialView();
        }

        /*----------------------------------------------------------------------------------------------------------------------*/

        public ActionResult KargoGönder()
        {
  
            return View();
        }

        [HttpPost]
        public ActionResult KargoGönder(KargoGönderViewmodel model)
        {
            if (!ModelState.IsValid) //modelde yazdığımız data annotaionslar doğru çalışmıyorsa yani şunlar [Requied]
            {

                return View(model);  //bunun anlamı hata varsa tekrar o sayfaya gidecek ve model tekrar gelecek.
            }

            Cargo cargo = new Cargo
            {
                CargoNumber = model.cargonumber,
                CategoryId = model.kategoriler,
                CargoStatusId = model.statuler
            };

            _context.Cargo.Add(cargo);
            _context.SaveChanges();

            ViewBag.Information = "Kargo kayıtı gerçekleşti";

            return View();
        }

    }
}