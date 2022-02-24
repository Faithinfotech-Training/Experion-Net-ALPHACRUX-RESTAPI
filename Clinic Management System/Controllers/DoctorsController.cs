using Clinic_Management_System.Models;
using Clinic_Management_System.Repository;
using Clinic_Management_System.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        //data member

        private readonly IDoctorRepository _doctorRepository;

        //constructor

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }


        /*
        //get user by username
        [HttpGet]
        [Route("patient/getpatient")]

        public async Task<IActionResult> GetPatient(int? patientId)
        {
            if (patientId == null)
            {
                return BadRequest();
            }
            try
            {
                var patient_data = await _doctorRepository.GetPatient(patientId);
                if (patient_data == null)
                {
                    return NotFound();
                }
                return Ok(patient_data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //get token list
        #region Get token List
        [HttpGet]
        [Route("tokens/tokenlist")]
        public async Task<IActionResult> GetTokens()
        {
            try
            {
                var tokens = await _doctorRepository.GetTokenList();
                if (tokens == null)
                {
                    return NotFound();
                }
                return Ok(tokens);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        //add medicine list

        #region medicine prescription
        [HttpPost]
        [Route("medicines/medicine")]
        public async Task<IActionResult> PostMedicine([FromBody] DoctorViewModel medicine)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var medId = await _doctorRepository.PostMedicine(medicine);
                    if(medId>0)
                    {
                        return Ok(medId);
                    }
                    else
                    {
                        return NotFound();

                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
       #endregion


        //add lab test
        #region lab test
        [HttpPost]
        [Route("tests/test")]
        public async Task<IActionResult> PostLabTest([FromBody] DoctorViewModel labTest)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var testId = await _doctorRepository.PostLabTest(labTest);
                    if(testId>0)
                    {
                        return Ok(testId);
                    }
                    else
                    {
                        return NotFound();

                    }
                }
                catch(Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();

        }
        #endregion

        #region Medical history/Doctor note
            [HttpPost]
            [Route("patient/medicalhistory")]
            public async Task<IActionResult> AddDoctorNote([FromBody] MedicalHistory patient)
            {
                //check validation of body
                if (ModelState.IsValid)
                {
                    try
                    {
                        var patientId = await _doctorRepository.CreateDoctorNote(patient);
                        if (patientId > 0)
                        {
                            return Ok(patientId);
                        }
                        else
                        {
                            return NotFound();
                        }
                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
        #endregion
        */

        #region Post vitals

        //Methods: /api/doctors/vitals
        [HttpPost("Vitals")]
        public async Task<IActionResult> PostVitals([FromBody] Vitals vitals)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var vitalsId = await _doctorRepository.PostVitals(vitals);
                    if (vitalsId > 0)
                    {
                        return Ok(vitalsId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Post Medicine in doctor

        //Methods: /api/doctors/medicine
        [HttpPost("medicine")]
        public async Task<IActionResult> PostMedicine([FromBody] MedicineLists medicineLists)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medicinelistId = await _doctorRepository.PostMedicine(medicineLists);
                    if (medicinelistId > 0)
                    {
                        return Ok(medicinelistId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Get medicineList 

        [HttpGet]
        [Route("Getmedicine")]
        public async Task<IActionResult> GetMedicine()
        {
            try
            {
                var medicines = await _doctorRepository.GetMedicineList();
                if (medicines == null)
                {
                    return NotFound();
                }
                return Ok(medicines);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion


        #region List vitals

        [HttpGet]
        [Route("GetVitals")]
        public async Task<IActionResult> GetVitals()
        {
            try
            {
                var vitals = await _doctorRepository.GetVitalsList();
                if (vitals == null)
                {
                    return NotFound();
                }
                return Ok(vitals);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Prescribe
        [HttpPost]
        [Route("CreatePrescribed")]
        public async Task<IActionResult> GeneratePrescriptionid([FromBody]PrescribedMedicines prescribed)
        {
            if (ModelState.IsValid)
            {
                try {

                    var prescriptionId = await _doctorRepository.GeneratePrescriptionid(prescribed);
                    if (prescriptionId > 0)
                    {
                        return Ok(prescriptionId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }return BadRequest();
            }

        #endregion

        #region Create Test Advice Id

        //ROUTE: api/doctor/CreateTestListId
        [HttpPost]
        [Route("CreateTestListId")]
        public async Task<IActionResult> CreateTestListId([FromBody] TestAdvices testAdvice)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testListid = await _doctorRepository.CreateTestAdviceId(testAdvice);
                    if (testListid > 0)
                    {
                        return Ok(testListid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region List test
        //ROUTE: api/doctors/ViewTestLists
        [HttpGet]
        [Route("ViewTestLists")]
        public async Task<IActionResult> ListTests()
        {
            try
            {
                var list = await _doctorRepository.ListTests();
                if (list == null)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Medical history/Doctor note
        [HttpPost]
        [Route("patient/medicalhistory")]
        public async Task<IActionResult> AddDoctorNote([FromBody] MedicalHistory patient)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var patientId = await _doctorRepository.CreateDoctorNote(patient);
                    if (patientId > 0)
                    {
                        return Ok(patientId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Doctor adds Medicine

        //ROUTE: api/doctors/AddMedicine
        [HttpPost]
        [Route("AddMedicine")]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineDetails medicineDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var medicieListid = await _doctorRepository.AddMedicine(medicineDetails);
                    if (medicieListid> 0)
                    {
                        return Ok(medicieListid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region List Medicine
        //ROUTE:    
        [HttpGet]
        [Route("viewMedicinelists")]
        public async Task<IActionResult> MedicineList()
        {
            try
            {
                var list = await _doctorRepository.MedicneList();
                if (list == null)
                {
                    return NotFound();
                }
                return Ok(list);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Add Doctor test
        //ROUTE: api/doctors/AddTest
        [HttpPost]
        [Route("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] TestDetails testDetails)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var testListid = await _doctorRepository.AddTest(testDetails);
                    if (testListid > 0)
                    {
                        return Ok(testListid);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Post Test in doctor 

        //Methods: /api/doctors/test
        [HttpPost("test")]
        public async Task<IActionResult> PostTest([FromBody] TestLists testLists)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var testlistId = await _doctorRepository.PostTest(testLists);
                    if (testlistId > 0)
                    {
                        return Ok(testlistId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Get testList 

        [HttpGet]
        [Route("Gettest")]
        public async Task<IActionResult> GetTest()
        {
            try
            {
                var tests = await _doctorRepository.GetTestList();
                if (tests == null)
                {
                    return NotFound();
                }
                return Ok(tests);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion





    }
}
