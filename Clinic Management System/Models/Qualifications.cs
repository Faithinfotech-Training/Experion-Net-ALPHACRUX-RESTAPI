using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Qualifications
    {
        public Qualifications()
        {
            Staffs = new HashSet<Staffs>();
        }

        public int QualificationId { get; set; }
        public string QualificationName { get; set; }

        public virtual ICollection<Staffs> Staffs { get; set; }
    }
}
