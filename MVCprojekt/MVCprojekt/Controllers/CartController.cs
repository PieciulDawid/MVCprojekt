using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVCprojekt.Models;

namespace MVCprojekt.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
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
                        Amount = pair.Value,
                        Name = item.Name,
                        Price = item.Price,
                        Sum = item.Price * pair.Value
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

        public ActionResult PlaceOrder(List<CartProductViewModel> model)
        {
            if (ModelState.IsValid)
            {
                var body = new StringBuilder();
                body.Append("Zamówiono:\n");
                model.ForEach(item =>
                {
                    body.Append(item.Name + " " + item.Amount + " " + item.Price + " " + item.Sum + "\n");
                });
                var userEmail = User.Identity.Name;
                WebMail.Send(userEmail, "Dziękujemy za złożenie zamówienia", body.ToString());
                Session.Remove("Cart");
                ViewBag.Ordered = "Zamówiono pomyślnie!";
            }

            return RedirectToAction("Index");
        }
        
    }

    public static class CartUtil
    {
        public static void AddToCart(Dictionary<int, int> cart, int itemId, int? itemQuantity)
        {
            var quantity = itemQuantity ?? 1;
            if (cart.ContainsKey(itemId))
                cart[itemId] += quantity;
            else
                cart.Add(itemId, quantity);
        }

        public static void RemoveFromCart(Dictionary<int, int> cart, int itemId, int? itemQuantity)
        {
            var quantity = itemQuantity ?? 1;
            if (cart.ContainsKey(itemId))
            {
                cart[itemId] -= quantity;

                if (cart[itemId] <= 0) cart.Remove(itemId);
            }
        }

        public static void RemoveFromCart(Dictionary<int, int> cart, int itemId)
        {
            if (cart.ContainsKey(itemId)) cart.Remove(itemId);
        }

        public static Dictionary<int, int> GetCartDict(HttpSessionStateBase session)
        {
            Dictionary<int, int> cart;
            if (session["Cart"] == null)
                cart = new Dictionary<int, int>();
            else
                cart = (Dictionary<int, int>) session["Cart"];

            session["Cart"] = cart;

            return cart;
        }
    }
}