using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class OrderProductModel
    {
        [Key]
        public int OrderProductID { get; set; }

        public int Amount { get; set; }

        public virtual ProductModel Product { get; set; }

        public virtual OrderModel Order { get; set; }
    }
}