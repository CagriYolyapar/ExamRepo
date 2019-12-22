using MVCAuthenticationTekrar.AuthenticationClasses;
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
    [AdminAuthentication]
    public class CategoryController : Controller
    {
        MyContext db;
        public CategoryController()
        {
            db = DBTool.DBInstance;
        }
        public ActionResult CategoryList()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            db.Categories.Add(item);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }


        public ActionResult DeleteCategory(int id)
        {
            db.Categories.Remove(db.Categories.Find(id));
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            return View(db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category item)
        {
            Category toBeUpdated = db.Categories.Find(item.ID);
            db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            db.SaveChanges();
            return RedirectToAction("CategoryList");
        }





       
    }
}