using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET
        // public ActionResult Index()
        // {
        //     List<int> cart;
        //     if (Session["Cart"] == null)
        //     {
        //         cart = new List<int>();
        //     }
        //     else
        //     {
        //         cart = (List<int>) Session["Cart"];
        //     }
        //
        //     cart.Add(cart.Count);
        //     Session["Cart"] = cart;
        //     
        //     
        //     return View();
        // }

        public ActionResult Index()
        {
            var cart = CartUtil.GetCartDict(Session);

            var products = new List<CartProductViewModel>();
            foreach (var pair in cart)
            {
                if (pair.Value == 0) continue;

                var item = db.ProductModels.Find(pair.Key);

                if (item != null)
                {
                    var tmp = new CartProductViewModel
                    {
                        ProductID = item.ProductID,
                        Amount = pair.Value ?? 1,
                        Name = item.Name,
                        Price = item.Price,
                        Sum = item.Price * pair.Value ?? 1
                    };

                    products.Add(tmp);
                }
            }

            return View(products);
        }

        public ActionResult PlusOne(int id)
        {
            var cart = CartUtil.GetCartDict(Session);
            CartUtil.AddToCart(cart, id, 1);

            Session["Cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult MinusOne(int id)
        {
            var cart = CartUtil.GetCartDict(Session);
            CartUtil.RemoveFromCart(cart, id, 1);

            Session["Cart"] = cart;

            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            var cart = CartUtil.GetCartDict(Session);
            CartUtil.RemoveFromCart(cart, id);

            Session["Cart"] = cart;

            return RedirectToAction("Index");
        }
    }

    public static class CartUtil
    {
        public static void AddToCart(Dictionary<int, int?> cart, int itemId, int? itemQuantity)
        {
            var quantity = itemQuantity ?? 1;
            cart[itemId] = cart.ContainsKey(itemId) ? quantity : quantity + cart[itemId];
        }

        public static void RemoveFromCart(Dictionary<int, int?> cart, int itemId, int? itemQuantity)
        {
            var quantity = itemQuantity ?? 1;
            cart[itemId] = cart.ContainsKey(itemId) ? 0 : quantity - cart[itemId];
            if (cart[itemId] <= 0) cart.Remove(itemId);
        }

        public static void RemoveFromCart(Dictionary<int, int?> cart, int itemId)
        {
            cart.Remove(itemId);
        }

        public static Dictionary<int, int?> GetCartDict(HttpSessionStateBase session)
        {
            Dictionary<int, int?> cart;
            if (session["Cart"] == null)
                cart = new Dictionary<int, int?>();
            else
                cart = (Dictionary<int, int?>) session["Cart"];

            session["Cart"] = cart;

            return cart;
        }
    }
}