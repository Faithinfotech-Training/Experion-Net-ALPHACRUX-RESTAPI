using System;
using System.Collections.Generic;

namespace CMS_Project.Models
{
    public partial class DoctorNote
    {
        public int NoteId { get; set; }
        public string NoteData { get; set; }
        public DateTime? DateTime { get; set; }
        public int? PatientId { get; set; }
        public int? StaffId { get; set; }

        public virtual Patients Patient { get; set; }
        public virtual Staffs Staff { get; set; }
    }
}
