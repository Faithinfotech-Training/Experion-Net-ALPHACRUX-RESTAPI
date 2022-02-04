using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class ConsultationBills
    {
        public int ConsultationBillId { get; set; }
        public DateTime ConsultationDateTime { get; set; }
        public int ConsultationAmount { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
    }
}
