using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public class Pharmacist : IPharmacist
    {
        //data fields
        private readonly CMSContext _context;

        //default constructor injection
        public Pharmacist(CMSContext context)
        {
            _context=context;
        }
        #region Get Prescription
        public async Task<PharmacistViewModel> GetPrescription(int patientId)
        {
            if (_context != null)
            {
                //linq 
                return await (from a in _context.PrescribedMedicines
                              from b in _context.Patients
                              from c in _context.MedicineLists
                              where a.PatientId == patientId 
                              select new PharmacistViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = b.PatientName,
                                  MedicineId = c.MedicineListId,
                                  MedicineName = c.MedicineName,
                                  Dosage=c.Dosage,
                                  Duration=c.Duration
                              }).FirstOrDefaultAsync();
            }return null;
        }
        #endregion
        #region generate bill
        
        public async Task<int> CreatePharmacyBill(MedicineBills bill)
        {
            if (_context !=null)
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


    }
}
