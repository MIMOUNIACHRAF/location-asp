using Location_Voiture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Location_Voiture.Controllers
{
    public class MarqueController : Controller
    {
        private readonly MyContext myContext;
        public MarqueController(MyContext myContext)
        {
            this.myContext = myContext; 
        }
        // GET: MarqueController
        public ActionResult Index()
        {
            List<Marque> marques= myContext.Marques.ToList();
            return View(marques);
        }

        // GET: MarqueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MarqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Marque Marque,IFormCollection collection)
        { 
            var marqueV = myContext.Marques.Where(x => x.Libelle.Equals(Marque.Libelle)).FirstOrDefault();
           if(marqueV == null)
                {      
                    if(ModelState.IsValid)
                    {
              
                            myContext.Marques.Add(new Marque { Libelle = Marque.Libelle });
                            myContext.SaveChanges();
                    return RedirectToAction(nameof(Index));
                    }
            }   
            ModelState.AddModelError("Libelle", "Existe deja cette Voiture ");
                return View(Marque);
            
           
        }

        // GET: MarqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MarqueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MarqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MarqueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
