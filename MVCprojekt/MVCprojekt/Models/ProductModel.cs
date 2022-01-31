using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<ProductCategoryModel> Categories { get; set; }

        public virtual ICollection<OrderProductModel> Orders { get; set; }
    }
}