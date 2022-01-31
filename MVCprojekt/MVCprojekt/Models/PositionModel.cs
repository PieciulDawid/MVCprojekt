using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCprojekt.Models
{
    public class PositionModel
    {
        [Key]
        public int PositionID { set; get; }

        public string Name { set; get; }

        public AccessLevel AccessLevel { set; get; }

        public virtual ICollection<EmployeeModel> Employees { set; get; }
    }

    public enum AccessLevel
    {
        NonAdmin,
        HeadAdmin,
        MinorAdmin
    }
}