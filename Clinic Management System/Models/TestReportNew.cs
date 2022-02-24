using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class TestReportNew
    {
        public TestReportNew()
        {
            Reportlist = new HashSet<Reportlist>();
        }

        public int ReportId { get; set; }
        public DateTime ReportDate { get; set; }
        public int PatientId { get; set; }
        public int StaffId { get; set; }

        public virtual Staffs Patient { get; set; }
        public virtual Patients Staff { get; set; }
        public virtual ICollection<Reportlist> Reportlist { get; set; }
    }
}
