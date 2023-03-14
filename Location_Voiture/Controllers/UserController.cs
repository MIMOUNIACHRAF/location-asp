using Location_Voiture.Models;
using Location_Voiture.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace Location_Voiture.Controllers
{
    public class UserController : Controller
    {
        readonly MyContext myContext;
        public UserController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public void Mysession(User user)
        {
            HttpContext.Session.SetString("Nom", user.Nom);
            HttpContext.Session.SetString("Prenom", user.Prenom);
            HttpContext.Session.SetString("Role", user.Role);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(UserRegisterModelView MV)
        {
            var Login = myContext.Users.Where(x => x.Login.Equals(MV.Login)).FirstOrDefault();
            if(Login == null)
            {
                if(ModelState.IsValid)
                {
                    var user = new User {
                        Nom = MV.Nom,
                        Prenom = MV.Prenom,
                        Login = MV.Login,
                        PassWord = MV.PassWord,
                        Role = "Client",
                        Date_inscription = System.DateTime.Now,
                        date_connction = System.DateTime.Now
                     };
                    myContext.Users.Add(user);
                    Mysession(user);
                    myContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("Login", "Ce Login existe deja");
            return View(MV);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModelView UMV)
        {
            if(ModelState.IsValid)
            {
                var login = myContext.Users.Where(Login => Login.Login.Equals(UMV.Login) && Login.PassWord.Equals(UMV.PassWord)).FirstOrDefault();
                if (login != null)
                {
                    Mysession(login);
                    return RedirectToAction("Index","Home");
                }
            }
            ModelState.AddModelError("", "Verifiez Login ou PassWord Errone");
            return View(UMV);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
          public IActionResult Test()
            {
                return View();
            }
    }
}
