using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public class DoctorRepository : IDoctorRepository
    {

        //data fields
        private readonly CMSContext _context;

        //default constructor

        public DoctorRepository(CMSContext context)
        {
            _context = context;
        }


        public async Task<List<Vitals>> GetVitalsList()
        {
            return await _context.Vitals.ToListAsync();
        }
        #region Add Medicines

        public async Task<int> PostMedicine(MedicineLists medicineLists)
        {
            if (_context != null)
            {
                await _context.MedicineLists.AddAsync(medicineLists);
                await _context.SaveChangesAsync();
                return medicineLists.MedicineListId;
            }
            return 0;
        }
        #endregion

        #region Add vitals

        public async Task<int> PostVitals(Vitals vitals)
        {
            if(_context!= null)
            {
                await _context.Vitals.AddAsync(vitals);
                await _context.SaveChangesAsync();
                return vitals.VitalId;
            }
            return 0;
        }
        #endregion

        #region Generates Prescribed Medicine

        public async Task<int> GeneratePrescriptionid(PrescribedMedicines prescribed)
        {
            if (_context != null)
            {
                await _context.PrescribedMedicines.AddAsync(prescribed);
                await _context.SaveChangesAsync();
                return prescribed.PrescriptionId;
            }
            return 0;
        }
        #endregion

        #region Create Test Advice Id

        public async Task<int> CreateTestAdviceId(TestAdvices testAdvice)
        {
            if (_context != null)
            {
                await _context.TestAdvices.AddAsync(testAdvice);
                await _context.SaveChangesAsync();
                return testAdvice.AdviceId;
            }
            return 0;
        }

        #endregion

        #region Doctor adds Tests

        public async Task<int> AddTest(TestLists testList)
        {
            if (_context != null)
            {
                await _context.TestLists.AddAsync(testList);
                await _context.SaveChangesAsync();
                return testList.TestListId;
            }
            return 0;
        }

        #endregion

        #region List tests in doctor page

        public async Task<List<TestDetailsViewModel>> ListTests()
        {
            if (_context != null)
            {
                return await (from testdetails in _context.TestDetails
                              select new TestDetailsViewModel
                              {
                                  TestName = testdetails.TestName,
                                  TestId = testdetails.TestId,

                              }).ToListAsync();
            }
            return null;
        }

        #endregion

        #region doctor note

        public async Task<int> CreateDoctorNote(MedicalHistory note)
        {
            if (_context != null)
            {
                await _context.MedicalHistory.AddAsync(note);
                await _context.SaveChangesAsync();
                return note.MedicalListId;
            }
            return 0;
        }
        #endregion

        #region Medicine details
        public async Task<int> AddMedicine(MedicineDetails medicineDetails)
        {
            if (_context != null)
            {
                await _context.MedicineDetails.AddAsync(medicineDetails);
                await _context.SaveChangesAsync();
                return medicineDetails.MedicineId;
            }
            return 0;
        }
        #endregion

        #region List Medicine details in doctor page

       

        public async Task<List<MedicineViewModel>> MedicneList()
        {
            if (_context != null)
            {
                return await(from medicineDetails in _context.MedicineDetails
                             select new MedicineViewModel
                             {
                                 MedicineName=medicineDetails.MedicineName,
                                 MedicineId = medicineDetails.MedicineId,

                             }).ToListAsync();
            }
            return null;
        }


        /*

        #region Get Patient

        public async Task<DoctorViewModel> GetPatient(int? patientId)
        {
            if(_context != null)
            {
                return await (from patient in _context.Patients
                              from token in _context.Tokens
                              where patient.PatientId ==token.PatientId
                              select new DoctorViewModel
                              {
                                  PatientId = patient.PatientId,
                                  PatientName =patient.PatientName,
                                  PatientPhone=patient.PatientPhone,
                                  PatientLocation=patient.PatientLocation,
                                  PatientWeight=patient.PatientWeight,
                                  PatientGender=patient.PatientGender,
                                  PatientBlood=patient.PatientBlood,
                                  PatientDob=patient.PatientDob,
                                  TokenId=token.TokenId,
                                  //TokenNum=token.TokenNum,
                                  TokenDateTime=token.TokenDateTime
                               }).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion

        #region get token list
        public async Task<List<DoctorViewModel>> GetTokenList()
        {

            if(_context != null)
            {
                return await (from token in _context.Tokens
                              from patient in _context.Patients
                              from staff in _context.Staffs
                              where token.PatientId == patient.PatientId && token.StaffId == staff.StaffId
                              select new DoctorViewModel
                              {
                                  TokenId = token.TokenId,
                                  //TokenNum=token.TokenNum,
                                  TokenDateTime=token.TokenDateTime,
                                  PatientId=patient.PatientId,
                                  PatientName=patient.PatientName,
                                  StaffId=staff.StaffId,
                                  StaffName=staff.StaffName
                              }).ToListAsync();
            }
            return null;
        }

        #endregion

        #region Add Medicine
        public async Task<int> PostMedicine(DoctorViewModel medicine)
        {
            if(_context != null)
            {
                PrescribedMedicines medicinePrescription= new PrescribedMedicines();
                medicinePrescription.PrescriptionDateTime=medicine.PrescriptionDateTime;
                medicinePrescription.PatientId=medicine.PatientId;
                medicinePrescription.StaffId=medicine.StaffId;

                await _context.PrescribedMedicines.AddAsync(medicinePrescription);
                await _context.SaveChangesAsync();

                MedicineLists medList=new MedicineLists();
                medList.MedicineName=medicine.MedicineName;
                medList.Dosage=medicine.Dosage;
                medList.Duration=medicine.Duration;

                await _context.MedicineLists.AddAsync(medList);
                await _context.SaveChangesAsync();

                return medList.MedicineListId;
            }
            return 0;
        }
        #endregion

        #region Add Test
        public async Task<int> PostLabTest(DoctorViewModel labTest)
        {
           if(_context != null)
            {
                TestAdvices testAdvice= new TestAdvices();
                testAdvice.TestAdviceDateTime =labTest.TestAdviceDateTime;
                testAdvice.PatientId=labTest.PatientId;
                testAdvice.StaffId=labTest.StaffId;

                await _context.TestAdvices.AddAsync(testAdvice);
                await _context.SaveChangesAsync();

                TestLists testList=new TestLists();
                testList.TestName=labTest.TestName;

                await _context.TestLists.AddAsync(testList);
                await _context.SaveChangesAsync();

                return testList.TestListId;
            }
            return 0;
        }
        #endregion

        //doctor note

        #region doctor note

       public async Task<int> CreateDoctorNote(MedicalHistory note)
        {
             if(_context !=null)
            {
                await _context.MedicalHistory.AddAsync(note);
                await _context.SaveChangesAsync();
                return note.MedicalListId;
            }
            return 0;
        }
        #endregion
        */
        #endregion


        #region Add Test

        public async Task<int> PostTest(TestLists testLists)
        {
            if (_context != null)
            {
                await _context.TestLists.AddAsync(testLists);
                await _context.SaveChangesAsync();
                return testLists.TestListId;
            }
            return 0;
        }
        #endregion

        public async Task<List<MedicineLists>> GetMedicineList()
        {
            return await _context.MedicineLists.ToListAsync();
        }

        public async Task<List<TestLists>> GetTestList()
        {
            return await _context.TestLists.ToListAsync();
        }

        #region Test details
        public async Task<int> AddTest(TestDetails testDetails)
        {
            if (_context != null)
            {
                await _context.TestDetails.AddAsync(testDetails);
                await _context.SaveChangesAsync();
                return testDetails.TestId;
            }
            return 0;
        }
        #endregion
    }
}

