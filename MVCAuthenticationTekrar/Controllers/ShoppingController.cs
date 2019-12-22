using MVCAuthenticationTekrar.AuthenticationClasses;
using MVCAuthenticationTekrar.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationTekrar.Controllers
{
    [MemberAuthentication]
    public class ShoppingController : Controller
    {
        MyContext db;

        public ShoppingController()
        {
            db = new MyContext();
        }
        // GET: Shopping
        public ActionResult ShoppingList()
        {
            return View();
        }
    }
}