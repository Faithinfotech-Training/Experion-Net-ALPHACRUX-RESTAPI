using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public interface ILabTechnicianRepository
    {
        //get patient by id 
        Task<TestReportViewModel> GetPatientDetails(int? id);
    
        //get test details using advice id
        Task<List<TestAmountViewModel>> GetTestDetails(int? id);

        //get patient by id 
        Task<List<TestReportViewModel>>GetPatient(int? id);

        //add lab bill
        Task<int> AddBill(LabBills labbill);


        //create report id
        Task<int> CreateReport(TestReportNew report);

        //insert labreport
        Task<int> LabReport(Reportlist report);

        Task<Authentications> GetUserByNameandPassword(string name, string password);




    }
}
