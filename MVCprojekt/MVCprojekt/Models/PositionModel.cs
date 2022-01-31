using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class PositionModel
    {
        [Key]
        public int PositionID { set; get; }

        public string Name { set; get; }

        public int AccesLevel { set; get; }

        public virtual ICollection<EmployeeModel> Employees { set; get; }
    }
}