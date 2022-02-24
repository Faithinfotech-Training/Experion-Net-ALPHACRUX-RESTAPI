using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Project.ViewModels
{
    public class GetPrescriptionViewModel
    {

        //Clinic Management System/Models/PrescribedMedicines.cs

        public int PrescriptionId { get; set; }
        public DateTime PrescriptionDateTime { get; set; }

        //
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        //Clinic Management System/Models/MedicineLists.cs
        public int MedicineListId { get; set; }
        public string MedicineName { get; set; }
        public int Dosage { get; set; }
        public int Duration { get; set; }
        public int MedicineId { get; set; }

        //Clinic Management System/Models/Staffs.cs
        public int StaffId { get; set; }
        public string StaffName { get; set; }

        //details
        
        public int MedicineQuantity { get; set; }
        public int MedicinePrice { get; set; }
        public DateTime ExpiryDate { get; set; }

        //


    }
}
