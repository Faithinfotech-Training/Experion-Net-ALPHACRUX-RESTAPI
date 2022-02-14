using Clinic_Management_System.Models;
using Clinic_Management_System.Repository;
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
    public class LabTechnicianController : ControllerBase
    {
        private readonly ILabTechnician _labTechician;

        //constructor
        public LabTechnicianController(ILabTechnician labTechnician)
        {
            _labTechician = labTechnician;
        }

        #region Get Prescription
        [HttpGet]
        [Route("patients")]
        public async Task<IActionResult> GetPrescriptions(int patientId)
        {
            if (patientId == 0)
            {
                return BadRequest();
            }
            try
            {
                var patient = await _labTechician.GetPrescription(patientId);
                if (patient == null)
                {
                    return NotFound();
                }
                return Ok(patient);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Create Lab Bills

        [HttpPost]
        [Route("labbills")]
        public async Task<IActionResult> CreateBills([FromBody] LabBills bill)
        //check validation of body
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bills = await _labTechician.CreateLabBill(bill);
                    if (bills > 0)
                    {
                        return Ok(bills);
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

        #region View all bills

        [HttpGet]
        [Route("viewallbills")]
        public async Task<ActionResult<IEnumerable<LabBills>>> GetAllBills()
        {
            return await _labTechician.GetAllBill();
        }

        #endregion

        #region Create Lab Report

        [HttpPost]
        [Route("labreport")]
        public async Task<IActionResult> CreateReports([FromBody] TestReports report)
        //check validation of body
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var reportId = await _labTechician.CreateTestReport(report);
                    if (reportId > 0)
                    {
                        return Ok(reportId);
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

        #region Update Test Report

        [HttpPut]
        [Route("updatelabreports")]
        public async Task<IActionResult> UpdateUser([FromBody] TestReports report)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    await _labTechician.UpdateReport(report);
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

        #region View all Test reports

        [HttpGet]
        [Route("viewallreports")]

        public async Task<ActionResult<IEnumerable<TestReports>>> GetAllReports()
        {
            return await _labTechician.GetAllReports();
        }

        #endregion
    }
}
