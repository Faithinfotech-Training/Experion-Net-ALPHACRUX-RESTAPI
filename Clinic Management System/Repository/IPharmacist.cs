using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public interface IPharmacist
    {
        // Retrieve patient prescription
        Task<PharmacistViewModel>GetPrescription(int patientId);
    
        //Create medicine bill
        Task<int> CreatePharmacyBill(MedicineBills bill);

       
        Task<List<MedicineBills>> GetAllBill();



    }
}
