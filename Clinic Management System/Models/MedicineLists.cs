using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class MedicineLists
    {
        public int MedicineListId { get; set; }
        public string MedicineName { get; set; }
        public int Dosage { get; set; }
        public int Duration { get; set; }
        public int? MedicineId { get; set; }
        public int? PrescriptionId { get; set; }

        public virtual MedicineDetails Medicine { get; set; }
        public virtual PrescribedMedicines Prescription { get; set; }
    }
}
