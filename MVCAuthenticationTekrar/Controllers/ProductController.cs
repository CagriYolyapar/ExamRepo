using MVCAuthenticationTekrar.AuthenticationClasses;
using MVCAuthenticationTekrar.Models.Context;
using MVCAuthenticationTekrar.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAuthenticationTekrar.Controllers
{
    [AdminAuthentication]
    public class ProductController : Controller
    {
        MyContext db;

        public ProductController()
        {
            db = new MyContext();
        }
        // GET: Product
        public ActionResult ProductList()
        {
            return View(db.Products.ToList());
        }


        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}