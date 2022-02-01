using System.Collections.Generic;
using System.Web.Mvc;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET
        public ActionResult Index()
        {
            List<int> cart;
            if (Session["Cart"] == null)
            {
                cart = new List<int>();
            }
            else
            {
                cart = (List<int>) Session["Cart"];
            }

            cart.Add(cart.Count);
            Session["Cart"] = cart;
            
            
            return View();
        }

        //     public ActionResult Index()
        //     {
        //         Dictionary<int, int?> cart;
        //         if (Session["Cart"] == null)
        //         {
        //             cart = new Dictionary<int, int?>();
        //         }
        //         else
        //         {
        //             cart = (Dictionary<int, int?>) Session["Cart"];
        //         }
        //
        //         var products = new List<CartProductViewModel>();
        //         cart.ForEach(pair =>
        //         {
        //             var item = db.ProductModels.Find(pair.Key);
        //             
        //             if (item != null)
        //             {
        //                 var tmp = new CartProductViewModel
        //                 {
        //                     ProductID = item.ProductID,
        //                     Amount = item.Amount,
        //                     Name = item.Name,
        //                     Price = item.Price,
        //                     Sum = item.Price * pair.Value ?? 1
        //                 };
        //             
        //                 products.Add(tmp);
        //             }
        //         });
        //
        //         ViewBag.Products = products;
        //         
        //         return View();
        //     }
        // }
        //
        // public class CartUtil
        // {
        //     public static void AddToCart(Dictionary<int, int?> cart, int itemId, int? itemQuantity)
        //     {
        //         var quantity = itemQuantity ?? 1;
        //         cart[itemId] = cart[itemId] == null ? quantity : quantity + cart[itemId];
        //     }
        //     
        //     public static void RemoveFromCart(Dictionary<int, int?> cart, int itemId)
        //     {
        //         cart.Remove(itemId);
        //     }
    }
}