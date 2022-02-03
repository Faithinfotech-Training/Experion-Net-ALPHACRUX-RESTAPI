﻿using Clinic_Management_System.Models;
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

        #region Add vitals

        public async Task<int> PostVitals(Patients patient)
        {
            if(_context!= null)
            {
                await _context.Patients.AddAsync(patient);
                await _context.SaveChangesAsync();
                return patient.PatientId;
            }
            return 0;
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
    }
}
