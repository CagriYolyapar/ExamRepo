using MVCAuthenticationTekrar.AuthenticationClasses;
using MVCAuthenticationTekrar.Models.Context;
using MVCAuthenticationTekrar.Models.CustomTools;
using MVCAuthenticationTekrar.Models.Entities;
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
            return View(db.Products.ToList());
        }


        public ActionResult AddToCart(int id)
        {
            //Kullanıcı ilk ürün aldıgında 
            //Kullanıcı sayfaya girer(sepeti bostur)
            //Kullanıcı ürün bakar (sepeti bostur)
            //Kullanıcı ürün begenir(sepeti bostur)
            //Kullanıcı ürünü sepete at der(sepet bostur(
            //Arka tarafta ürünün sepete atılma işlemleri yapılır(buradaki kodlar)
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart; //sepet burada olusturulur(session hala bos)

            Product eklenecekUrun = db.Products.Find(id);

            CartItem ci = new CartItem();
            ci.ID = eklenecekUrun.ID;
            ci.Name = eklenecekUrun.ProductName;
            ci.Price = eklenecekUrun.UnitPrice;

            c.SepeteEkle(ci);

            Session["scart"] = c; //sepet burada Session'a atılır(ilk ürünle birlikte) kullanıcı ikinci ürünü sectigi zaman artık Session dolu olacaktır).
            return RedirectToAction("ShoppingList");



        }


        public ActionResult CartPage()
        {
            Cart c = Session["scart"] as Cart;
            return View(c);


        }

        public ActionResult ConfirmOrder()
        {


            return View();
        }

        [HttpPost]
        public ActionResult ConfirmOrder(Order item)
        {
            AppUser kullanici = Session["member"] as AppUser;
            item.AppUserID = kullanici.ID;
            db.Orders.Add(item);
            db.SaveChanges(); //item ID'si identity oldugu icin otomatik olarak artacak. Bu artım da ancak SaveChanges() ifadesinde kayıt edilirken yapılır..Bizim Order'in ID'sine ihtiyacımız var cünkü bu OrderID'sine OrderDetail'e ekleyecegiz.
            Cart c = Session["scart"] as Cart;

            foreach (CartItem sepettekiUrun in c.Sepetim)
            {
                OrderDetail od = new OrderDetail();
                od.OrderID = item.ID;
                od.ProductID = sepettekiUrun.ID;
                db.OrderDetails.Add(od);
                db.SaveChanges();

            }

            Session["scart"] = null;
            TempData["SiparisAlindi"] = "Siparişiniz alınmızstır. Tesekkür ederiz";
            return RedirectToAction("ShoppingList");
        }
    }
}