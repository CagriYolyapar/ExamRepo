using MVCAuthenticationTekrar.Models.Context;
using MVCAuthenticationTekrar.Models.Entities;
using MVCAuthenticationTekrar.SingletonPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationTekrar.Controllers
{
    public class HomeController : Controller
    {

        MyContext db;

        public HomeController()
        {
            db = DBTool.DBInstance;
        }
        // GET: Home
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(AppUser item)
        {
            AppUser girisYapan = db.AppUsers.FirstOrDefault(x => x.UserName == item.UserName && x.Password == item.Password);


            if (girisYapan!=null&& girisYapan.Role == Models.Enums.UserRole.Admin)
            {
                Session["admin"] = girisYapan;

                return RedirectToAction("ProductList", "Product");
            }
            else if(girisYapan!=null &&girisYapan.Role == Models.Enums.UserRole.Member)
            {
                Session["member"] = girisYapan;

                return RedirectToAction("ShoppingList", "Shopping");
            }

            return RedirectToAction("Login", "Home");
        }
    }
}