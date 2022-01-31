using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class CounterModel
    {
        [Key]
        public int CounterID { get; set; }

        public int Counter { get; set; }
    }
}