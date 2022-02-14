using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.ViewModel
{
    public class LabTechnicianViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? TestId { get; set; }
        public string TestName { get; set; }

        public int ReportId { get; set; }
        public int PatientValue { get; set; }
        public DateTime ReportDateTime { get; set; }
        public int? StaffId { get; set; }
    }
}
