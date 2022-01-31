using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductModel> Products { get; set; }

        public virtual ICollection<CategoryModel> Categories { get; set; }

    }
}