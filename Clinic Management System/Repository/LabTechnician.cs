using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public class LabTechnician : ILabTechnician
    {
        //data field
        private readonly CMSContext _context;

        //default constructor injection
        public LabTechnician(CMSContext context)
        {
            _context = context;
        }

        #region Create Test Report 
        public async Task<int> CreateTestReport(TestReports report)
        {
            if (_context != null)
            {
                await _context.TestReports.AddAsync(report);
                await _context.SaveChangesAsync();
                return report.ReportId;
            }
            return 0;
        }
        #endregion

        #region Update Test Report

        public async Task UpdateReport(TestReports user)
        {
            if (_context != null)
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.TestReports.Update(user);
                await _context.SaveChangesAsync();
            }
        }

        #endregion

        #region View all Lab Reports

        public async Task<List<TestReports>> GetAllReports()
        {

            if (_context != null)
            {
                return await _context.TestReports.ToListAsync();
            }
            return null;
        }

        #endregion

        #region Create Lab Bills
        public async Task<int> CreateLabBill(LabBills bill)
        {
            if (_context != null)
            {
                await _context.LabBills.AddAsync(bill);
                await _context.SaveChangesAsync();
                return bill.LabBillId;
            }
            return 0;
        }

        #endregion

        #region View all lab bills

        public async Task<List<LabBills>> GetAllBill()
        {
            if (_context != null)
            {
                return await _context.LabBills.ToListAsync();
            }
            return null;
        }


        #endregion

        #region Get Prescription
        public async Task<LabTechnicianViewModel> GetPrescription(int patientId)
        {

            if (_context != null)
            {
                //linq
                return await (from a in _context.TestAdvices
                              from b in _context.Patients
                              from c in _context.TestLists
                              where a.PatientId==patientId 
                              select new LabTechnicianViewModel
                              {
                                  PatientId = b.PatientId,
                                  PatientName = b.PatientName,
                                  TestId = c.TestId,
                                  TestName = c.TestName
                              }).FirstOrDefaultAsync();
            }
            return null;
        }

        #endregion





    }
}
