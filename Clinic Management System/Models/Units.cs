using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Units
    {
        public int UnitId { get; set; }
        public string TestUnit { get; set; }
        public int? TestId { get; set; }

        public virtual TestDetails Test { get; set; }
    }
}
