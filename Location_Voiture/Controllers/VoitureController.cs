using Location_Voiture.Models;
using Location_Voiture.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Location_Voiture.Controllers
{
    public class VoitureController : Controller
    {
        public readonly MyContext _Mycontext;
        [System.Obsolete]
        private readonly IHostingEnvironment he;

        [System.Obsolete]
        public VoitureController(MyContext _Mycontext, IHostingEnvironment he)
        {
            this._Mycontext = _Mycontext;
            this.he = he;
        } 
        public IList<Marque> Marques()
        {
            List<Marque> marque = _Mycontext.Marques.ToList();
            marque.Insert(0, new Marque {Id= 0,Libelle="selectionnez une ligne"});
            return marque;
        }  
        public IActionResult Index()
        {
            ICollection<Voiture> voitures = _Mycontext.Voitures.Include(marque => marque.Marque).ToList(); 
            return View(voitures);
        }
        public IActionResult Create()
        {
            ViewBag.Marques = Marques();
            return View();
        }
        [HttpPost]
        [System.Obsolete]
        public IActionResult Create(VoitureModelView VoitureMV)
        {
            string path = uploadingImage(VoitureMV);
            var Marque = _Mycontext.Marques.Find(VoitureMV.Marque.Id);
            int matricule = _Mycontext.Voitures.Where(matricule => matricule.Matricule.Equals(VoitureMV.Matricule)).Count();
            if(matricule == 0) 
            {
                if (VoitureMV.Photo != null)
                {
                   
                        Voiture Voiture = new Voiture
                        {
                            Matricule = VoitureMV.Matricule,
                            Nbr_Porte = VoitureMV.Nbr_Porte,
                            Photo = path,
                            Couleur = VoitureMV.Couleur,
                            Marque = Marque
                        }; 
                        _Mycontext.Voitures.Add(Voiture);
                        _Mycontext.SaveChanges();
                  
                    return RedirectToAction("Index");
                }
            }
            //Marques();
            return View(VoitureMV);
        }

        public IActionResult Modif(int Id)
        {
            ViewBag.marques = _Mycontext.Marques.ToList();
            Voiture Voiture = _Mycontext.Voitures.Find(Id);
            ViewData["photo"] = "~/Voiture/"+Voiture.Photo;
            var NEwVoiture = new VoitureModelView
            {
                Id= Id,
                Matricule = Voiture.Matricule,
                Nbr_Porte= Voiture.Nbr_Porte,
                image = Voiture.Photo,
                Couleur= Voiture.Couleur,
                Marque= Voiture.Marque
            };
            return View(NEwVoiture);
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Modif(int Id, VoitureModelView Mv)
        {
                string path = uploadingImage(Mv);
                Voiture voiture = _Mycontext.Voitures.Where(v => v.Id == Id).FirstOrDefault();
                voiture.Matricule = Mv.Matricule;
                voiture.Nbr_Porte = Mv.Nbr_Porte;
                if(path!= string.Empty)
                {
                    voiture.Photo = path;
                }               
                voiture.Couleur = Mv.Couleur;
                voiture.Marque = _Mycontext.Marques.Find(Mv.Marque.Id);

                _Mycontext.Update(voiture);
                _Mycontext.SaveChanges();
                return RedirectToAction("Index");
        }
        public IActionResult Details(int Id)
        {
            ViewBag.marque = Marques();
            return View(_Mycontext.Voitures.Find(Id));
        } 
        public IActionResult Delete(int id)
        {
            return View(_Mycontext.Voitures.Find(id));
        }
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            ViewBag.marques = _Mycontext.Marques.ToList();
            _Mycontext.Voitures.Remove(_Mycontext.Voitures.Find(id));
            _Mycontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [System.Obsolete]
        public string uploadingImage(VoitureModelView Voiture)
        {
            string FileName = string.Empty;
            if(Voiture.Photo != null)
            {
                //var photo = Path.Combine(he.WebRootPath, Path.GetFileName(VoitureMV.Photo.FileName));
                //VoitureMV.Photo.CopyTo(new FileStream(photo, FileMode.Create));
                string UploadFolder = Path.Combine(he.WebRootPath,"Voiture");
                FileName = Guid.NewGuid().ToString()+"-"+Voiture.Photo.FileName;
                string ImagePath = Path.Combine(UploadFolder,FileName);
                using (var filestram = new FileStream(ImagePath,FileMode.Create))
                {
                    Voiture.Photo.CopyTo(filestram);
                }
            }
            return FileName;
        }
        public IActionResult MoreDetails()
        {
            
            //if (id == 0)
            //{
            //    return NotFound();
            //}
            //else
            //{
            //    Voiture voiture = _Mycontext.Voitures.Where(V => V.Id == id).FirstOrDefault();

            //}
            return View();
        }

    }
}
