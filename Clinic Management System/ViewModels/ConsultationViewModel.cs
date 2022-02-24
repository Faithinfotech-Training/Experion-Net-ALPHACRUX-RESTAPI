using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.ViewModels
{
    public class ConsultationViewModel
    {
        public int ConsultationBillId { get; set; }
        public DateTime ConsultationDateTime { get; set; }
        public int ConsultationAmount { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
    }
}
