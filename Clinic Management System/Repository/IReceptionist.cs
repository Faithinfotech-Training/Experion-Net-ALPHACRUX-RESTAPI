using Clinic_Management_System.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Clinic_Management_System.Models;


namespace Clinic_Management_System.Repositories
{
    public interface IReceptionist
    {
        //Retrieve all patients
        Task<List<ReceptionistViewModel>> GetTokenQueue();
        
        //Retrieve all patients using view model
        Task<List<PatientsViewModel>> GetPatients();

        //Retrieve all patients from model
        Task<List<Patients>> GetAllPatients();

        //get patient by id
        Task<ReceptionistViewModel> GetPatient(int? id);

        //Register new patient
        Task<int> AddPatient(Patients patients);

        //Update Patient
        Task UpdatePatient(Patients patients);

        //Generate token
        Task<int> GenerateToken(Tokens token);

        //List Payment record
        Task<List<ReceptionPaymentViewModel>> GetPaymentHistory();

        //Generate Consultation bills
        Task<int> PostCosnultationBill(ConsultationBills bills);

        //get patient by id for Form updation
        Task<PatientsViewModel> GetPatientDetails(int? id);

        //Retrieve all doctors using view model
        Task<List<DoctorsViewModel>> GetDoctors();

        //Delete token
        Task<int> DeleteToken(int? id);


        ///token
        Task<ReceptionistViewModel> GetPatientToken(int? id);


        //get consultation bills

        Task<List<ConsultationViewModel>> GetConsultBills();


        //post consultation bill
        Task<int> AddBill(ConsultationBills bills);
        



    }
}
