using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public virtual CategoryModel Category { get; set; }

        public virtual ICollection<OrderProductModel> Orders { get; set; }
    }
}