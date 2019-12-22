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
            ViewBag.KategoriListesi = db.Categories.ToList(); //Kategori listemizi ViewBag'de saklıyoruz..
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }


        public ActionResult DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult UpdateProduct(int id)
        {
            ViewBag.KategoriListesi = db.Categories.ToList();
            return View(db.Products.Find(id));
            
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product item)
        {
            Product toBeUpdated = db.Products.Find(item.ID);
            db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            db.SaveChanges();

            return RedirectToAction("ProductList");
        }
    }
}