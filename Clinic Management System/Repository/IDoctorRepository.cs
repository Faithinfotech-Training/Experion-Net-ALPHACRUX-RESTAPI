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


        //Doctor records the vitals of patient
        Task<int> PostVitals(Vitals vitals);

        //List vitals
        Task<List<Vitals>> GetVitalsList();


        /*
        //retrieves patient data

        Task<DoctorViewModel> GetPatient(int? patientId);

        // retrieves patient token
        Task<List<DoctorViewModel>> GetTokenList();


        //Doctor access doctors note

       Task<int> CreateDoctorNote(MedicalHistory note);

      

        //Doctor advises lab test

        Task<int> PostLabTest(DoctorViewModel labTest);

        */
        // generates prescriptionid
        Task<int> GeneratePrescriptionid(PrescribedMedicines prescribed);
        //Creates Test Advice Id
        Task<int> CreateTestAdviceId(TestAdvices testAdvice);

        //Doctor Adds Tests
        Task<int> AddTest(TestLists testList);

        //Testname listing in doctor page
        Task<List<TestDetailsViewModel>> ListTests();

        Task<int> CreateDoctorNote(MedicalHistory note);
        //Doctor Adds Medicine
        Task<int> AddMedicine(MedicineDetails medicineDetails);

        //Medicine listing in doctor page
        Task<List<MedicineViewModel>> MedicneList();

        //Doctor prescribes medicine
        Task<int> PostMedicine(MedicineLists medicineLists);

        Task<List<MedicineLists>> GetMedicineList();
        Task<int> AddTest(TestDetails testDetails);

        //Doctor prescribes test
        Task<int> PostTest(TestLists testLists);

        //To get test
        Task<List<TestLists>> GetTestList();
    }
}

