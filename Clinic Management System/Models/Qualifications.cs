using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Qualifications
    {
        public int QualificationId { get; set; }
        public string QualificationName { get; set; }
        public int? StaffId { get; set; }

        public virtual Staffs Staff { get; set; }
    }
}
