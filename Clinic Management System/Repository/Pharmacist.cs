using Clinic_Management_System.Models;
using CMS_Project.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Project.Repository
{
    public class Pharmacist : IPharmacist   
    {
        //data fields
        private readonly CMSContext _context;

        //default constructor injection
        public Pharmacist(CMSContext context)
        {
            _context = context;
        }

        #region Get Prescription
        public async Task<GetPrescriptionViewModel> GetPrescription(int? patientId)
        {
            if (_context != null)
            {
                //linq 
                return await (from pres in _context.PrescribedMedicines
                              from list in _context.MedicineLists
                              from details in _context.MedicineDetails
                              from patient in _context.Patients
                              from staff in _context.Staffs

                              where pres.PrescriptionId == list.PrescriptionId
                              && list.MedicineId == details.MedicineId
                              && patient.PatientId == patientId
                              && pres.StaffId == staff.StaffId
                              && pres.PatientId == patient.PatientId

                              select new GetPrescriptionViewModel
                              {
                                 PatientId= (int)pres.PatientId,
                                 PatientName=patient.PatientName,
                                 PrescriptionDateTime=pres.PrescriptionDateTime,
                                 StaffName=staff.StaffName,
                                 StaffId=staff.StaffId,
                                 PrescriptionId= (int)list.PrescriptionId
                              }
                    ).FirstOrDefaultAsync();
            }
            return null;
        }
        #endregion
        #region generate bill

        public async Task<int> CreatePharmacyBill(MedicineBills bill)
        {
            if (_context != null)
            {
                await _context.MedicineBills.AddAsync(bill);
                await _context.SaveChangesAsync();
                return bill.MedicineBillId;
            }
            return 0;
        }
        #endregion



        public async Task<List<MedicineBills>> GetAllBill()
        {
            if (_context != null)
            {
                return await _context.MedicineBills.ToListAsync();
            }
            return null;
        }



        #region Get Medicine List

        public async Task<List<PharmacyList>> GetMedicineList(int? id)
        {
           if(_context != null)
            {
                return await (
                    from list in _context.MedicineLists
                    from details in _context.MedicineDetails
                    where list.PrescriptionId == id
                    && list.MedicineId == details.MedicineId
                    select new PharmacyList
                    {
                        MedicineId = (int)list.MedicineId,
                        MedicineName =details.MedicineName,
                        Dosage = list.Dosage,
                        Duration = list.Duration,
                        MedicinePrice = details.MedicinePrice

                    }
                    ).ToListAsync();
            }
            return null;

        }

        Task<GetPrescriptionViewModel> IPharmacist.GetPrescription(int? patientId)
        {
            throw new NotImplementedException();
        }

        Task<List<PharmacyList>> IPharmacist.GetMedicineList(int? id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
