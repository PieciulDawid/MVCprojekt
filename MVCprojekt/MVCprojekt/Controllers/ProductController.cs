using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVCprojekt.Models;
using PagedList;

namespace MVCprojekt.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AmountSortParm = sortOrder == "Amount" ? "amount_desc" : "";
            var products = from s in db.ProductModels
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Name.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                case "Amount":
                    products = products.OrderBy(s => s.Amount);
                    break;
                case "amount_desc":
                    products = products.OrderByDescending(s => s.Amount);
                    break;
                default:
                    products = products.OrderBy(s => s.Name);
                    break;
            }
            return View(products.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db.CategoryModels.ToList().ConvertAll(category =>
                new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });
            
            return View();
        }

        // POST: Product/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var productModel = db.ProductModels.Create();

                productModel.Amount = model.Amount;
                productModel.Description = model.Description;
                productModel.Name = model.Name;
                productModel.Price = model.Price;
                productModel.IsDeleted = false;
                productModel.Category = db.CategoryModels.Find(model.Category);
                
                db.ProductModels.Add(productModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

            ViewBag.Categories = db.CategoryModels.ToList().ConvertAll(category =>
                new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });
            
            return View(model);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }

            var model = new ModifyProductViewModel
            {
                ProductID = productModel.ProductID,
                Amount = productModel.Amount,
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                IsDeleted = productModel.IsDeleted,
                Category = productModel.Category.CategoryID
            };

            ViewBag.Categories = db.CategoryModels.ToList().ConvertAll(category =>
                new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });

            return View(model);
        }

        // POST: Product/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ModifyProductViewModel model)
        {
            if (db.CategoryModels.Find(model.Category) == null)
            {
                ModelState.AddModelError("Category", "Kategoria nie istnieje.");
            }
            
            if (ModelState.IsValid)
            {
                var productModel = db.ProductModels.Find(model.ProductID);
                
                productModel.Amount = model.Amount;
                productModel.Description = model.Description;
                productModel.Name = model.Name;
                productModel.Price = model.Price;
                productModel.IsDeleted = model.IsDeleted;
                productModel.Category = db.CategoryModels.Find(model.Category);
                
                db.Entry(productModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.Categories = db.CategoryModels.ToList().ConvertAll(category =>
                new SelectListItem { Text = category.Name, Value = category.CategoryID.ToString() });
            
            return View(model);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModel productModel = db.ProductModels.Find(id);
            if (productModel == null)
            {
                return HttpNotFound();
            }
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModel productModel = db.ProductModels.Find(id);
            db.ProductModels.Remove(productModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
