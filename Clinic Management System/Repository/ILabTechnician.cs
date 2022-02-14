using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public interface ILabTechnician
    {
        //Retrieves patient prescription
        Task<LabTechnicianViewModel> GetPrescription(int patientId);

        //Creates lab test bill
        Task<int> CreateLabBill(LabBills bill);

        //View all bills
        Task<List<LabBills>> GetAllBill();

        //Creates required test report 
        Task<int> CreateTestReport(TestReports report);

        //updates test report
        Task UpdateReport(TestReports user);

        //View Lab Report
        Task<List<TestReports>> GetAllReports();
    }
}
