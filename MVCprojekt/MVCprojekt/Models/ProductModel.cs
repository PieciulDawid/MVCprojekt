using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace MVCprojekt.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public CategoryModel Category { get; set; }

        public virtual ICollection<OrderProductModel> Orders { get; set; }
    }
    
    public class AddProductViewModel
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        [CategoryExistsAttribute(ErrorMessage = "Kategoria nie istnieje.")]
        public int Category { get; set; }
    }
    
    public class CategoryExistsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null && (value is int || value is long || value is uint || value is ulong))
            {
                return HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>()
                    .CategoryModels
                    .Find(value) != null;
            }

            return false;
        }
    }
}