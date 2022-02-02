using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Staffs
    {
        public Staffs()
        {
            Authentications = new HashSet<Authentications>();
            ConsultationBills = new HashSet<ConsultationBills>();
            MedicalHistory = new HashSet<MedicalHistory>();
            PrescribedMedicines = new HashSet<PrescribedMedicines>();
            Qualifications = new HashSet<Qualifications>();
            TestAdvices = new HashSet<TestAdvices>();
            TestReports = new HashSet<TestReports>();
            Tokens = new HashSet<Tokens>();
        }

        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffPhone { get; set; }
        public string StaffAddress { get; set; }
        public string StaffEmail { get; set; }
        public DateTime StaffDob { get; set; }
        public DateTime StaffJoiningDate { get; set; }

        public virtual ICollection<Authentications> Authentications { get; set; }
        public virtual ICollection<ConsultationBills> ConsultationBills { get; set; }
        public virtual ICollection<MedicalHistory> MedicalHistory { get; set; }
        public virtual ICollection<PrescribedMedicines> PrescribedMedicines { get; set; }
        public virtual ICollection<Qualifications> Qualifications { get; set; }
        public virtual ICollection<TestAdvices> TestAdvices { get; set; }
        public virtual ICollection<TestReports> TestReports { get; set; }
        public virtual ICollection<Tokens> Tokens { get; set; }
    }
}
