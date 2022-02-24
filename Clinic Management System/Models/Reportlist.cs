using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Reportlist
    {
        public int ReportlistId { get; set; }
        public int? PatientValue { get; set; }
        public int ReportId { get; set; }
        public int TestId { get; set; }

        public virtual TestReportNew Report { get; set; }
        public virtual TestDetails Test { get; set; }
    }
}
