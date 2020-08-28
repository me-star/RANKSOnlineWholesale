using Newtonsoft.Json;
using RANKSOnlineWholesale.DBase;
using RANKSOnlineWholesale.Models;
using RANKSOnlineWholesale.Models.Home;
using RANKSOnlineWholesale.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RANKSOnlineWholesale.Controllers
{
    public class HomeController : Controller
    {
        RANKSWHOLESALEEntities ctx = new RANKSWHOLESALEEntities();
        public ActionResult Index(String search, int? page)

        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model.CreateModel(search, 4, page));
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddToCart(int productId)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart= new List<Item>();
                 var product = ctx.Products.Find(productId);
                cart.Add(new Item()
                {
                     Product = product,
                     Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                var product = ctx.Products.Find(productId);
                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });
                Session["cart"] = cart;

            }
            return Redirect("Index");
        }

      
    }
    
}