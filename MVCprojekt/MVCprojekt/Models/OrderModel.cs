using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime FinalizationDate { get; set; }

        public int State { get; set; }

        public virtual EmployeeModel Employee { get; set; }

        public virtual ApplicationUser Client { get; set; }

        public virtual ICollection<OrderProductModel> Products { get; set; }
    }
}