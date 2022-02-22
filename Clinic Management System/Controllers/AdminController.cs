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
    public class AdminController : ControllerBase
    {
        //data member

        private readonly IAdminRepository _adminRepo;

        //constructor
        public AdminController(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }


        #region Get Qualifications

        // api/admin/qualifications
        [HttpGet("Qualifications")]
        public async Task<ActionResult<IEnumerable<Qualifications>>>GetQualifications()
        {
            return await _adminRepo.GetQualifications();
        }
        #endregion

        #region Roles

        //api/admin/roles
        [HttpGet("Roles")]
        public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
        {
            return await _adminRepo.GetRoles();
        }
        #endregion

        #region Staffs

        //api/admin/staffs
        [HttpGet("Staffs")]
        public async Task<ActionResult<IEnumerable<Staffs>>> GetStaffs()
        {
            return await _adminRepo.GetStaffs();
        }

        // api/admin/staff
        [HttpPost("Staff")]
        public async Task<IActionResult> AddStaff([FromBody] Staffs staff)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var staffId = await _adminRepo.AddStaff(staff);
                    if (staffId > 0)
                    {
                        return Ok(staffId);
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

        //List staffs from view model -----------api/admin/liststaffs
        [HttpGet("ListStaffs")]
        public async Task<IActionResult> ListStaffs()
        {
            try
            {
                var staffs = await _adminRepo.ListStaffs();
                if (staffs == null)
                {
                    return NotFound();
                }
                return Ok(staffs);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //Get a staff by id  ---api/admin/staff/1
        [HttpGet("Staff/{id}")]
        public async Task<ActionResult<Staffs>> GetStaffById(int? id)
        {
            try
            {
                var staff = await _adminRepo.GetStaffById(id);
                if (staff == null)
                {
                    return NotFound();
                }
                return staff;        //return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //Update staff  ------------api/admin/updatestaff/1
        [HttpPut("UpdateStaff")]
        public async Task<IActionResult> UpdateStaff([FromBody] Staffs staff)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _adminRepo.UpdateStaff(staff);
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion

        #region Medicines

        //List Medicine inventory view model -----------api/admin/medicines
        [HttpGet("Medicines")]
        public async Task<IActionResult> ListMedicines()
        {
            try
            {
                var inventory = await _adminRepo.ListMedicines();
                if (inventory == null)
                {
                    return NotFound();
                }
                return Ok(inventory);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        // api/admin/inventory
        [HttpGet("Inventory")]
        public async Task<ActionResult<IEnumerable<MedicineInventories>>> GetInventories()
        {
            return await _adminRepo.GetInventories();
        }
        #endregion


        #region Medicine details

        // api/admin/medicinedetails
        [HttpGet("MedicineDetails")]
        public async Task<ActionResult<IEnumerable<MedicineDetails>>> GetMedicineDetails()
        {
            return await _adminRepo.GetMedicineDetails();
        }


        // api/admin/addmedicine
        [HttpPost("AddMedicine")]
        public async Task<IActionResult> AddMedicine([FromBody] MedicineDetails medicine)
        {
            //Check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var medId = await _adminRepo.AddMedicine(medicine);
                    if (medId > 0)
                    {
                        return Ok(medId);
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


        #region Get Qualifications

        // api/admin/mfgs
        [HttpGet("Mfgs")]
        public async Task<ActionResult<IEnumerable<Manufactures>>> GetMfgs()
        {
            return await _adminRepo.GetMfgs();
        }
        #endregion
    }
}
