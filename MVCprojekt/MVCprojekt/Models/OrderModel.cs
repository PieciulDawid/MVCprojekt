using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCprojekt.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? FinalizationDate { get; set; }

        public OrderState State { get; set; }

        public virtual ApplicationUser Client { get; set; }

        public virtual ICollection<OrderProductModel> Products { get; set; }
    }

    public enum OrderState
    {
        New,
        InProgress,
        Finalized,
        Cancelled
    }
}