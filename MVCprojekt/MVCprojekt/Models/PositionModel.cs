using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCprojekt.Models
{
    public class PositionModel
    {
        public int PositionID { set; get; }

        public string Name { set; get; }

        public int AccesLevel { set; get; }

        public virtual ICollection<EmployeeModel> Employees { set; get; }
    }
}