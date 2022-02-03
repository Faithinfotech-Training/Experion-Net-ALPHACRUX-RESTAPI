using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public interface IDoctorRepository
    {
        

        //retrieves patient data

        Task<DoctorViewModel> GetPatient(int? patientId);

        // retrieves patient token
        Task<List<DoctorViewModel>> GetTokenList();


        //Doctor access doctors note

       Task<int> CreateDoctorNote(MedicalHistory note);



        //Doctor records the vitals of patient
        Task<int> PostVitals(Patients patient);

        //Doctor prescribes medicine
        Task<int> PostMedicine(DoctorViewModel medicine);

        //Doctor advises lab test

        Task<int> PostLabTest(DoctorViewModel labTest);


    }
}

