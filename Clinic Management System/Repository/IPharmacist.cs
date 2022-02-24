using Clinic_Management_System.Models;

using CMS_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Project.Repository
{
    public interface IPharmacist
    {
        // Retrieve patient prescription
        Task<GetPrescriptionViewModel> GetPrescription(int? patientId);

        //Create medicine bill
        Task<int> CreatePharmacyBill(MedicineBills bill);

        //get all medicine bills

        Task<List<MedicineBills>> GetAllBill();

        //get all medicine list

        Task<List<PharmacyList>> GetMedicineList(int? id);

        
    }
}
