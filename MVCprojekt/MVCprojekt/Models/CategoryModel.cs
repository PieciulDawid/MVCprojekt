using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductCategoryModel> Products { get; set; }

    }
}