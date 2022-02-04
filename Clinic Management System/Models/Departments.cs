using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
