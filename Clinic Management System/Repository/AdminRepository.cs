﻿using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public class AdminRepository : IAdminRepository
    {

        //data fields
        private readonly CMSContext _context;

        //default constructor

        public AdminRepository(CMSContext context)
        {
            _context = context;
        }

        

        #region Qualifications

        //Get Qualifications from db
        public async Task<List<Qualifications>> GetQualifications()
        {
            if (_context != null)
            {
                return await _context.Qualifications.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Roles

        //Get Roles from db
        public async Task<List<Roles>> GetRoles()
        {
            if (_context != null)
            {
                return await _context.Roles.ToListAsync();
            }
            return null;
        }
        #endregion

        #region Staffs

        //Get Staffs from db
        public async Task<List<Staffs>> GetStaffs()
        {
            if (_context != null)
            {
                return await _context.Staffs.ToListAsync();
            }
            return null;
        }

        //Post staffs
        public async Task<int> AddStaff(Staffs staff)
        {
            if (_context != null)
            {
                await _context.Staffs.AddAsync(staff);
                await _context.SaveChangesAsync(); //commit the transaction
                return staff.StaffId;
            }
            return 0;
        }

        //List staff details using view model
        public async Task<List<StaffsVM>> ListStaffs()
        {
            if (_context != null)
            {
                return await (
                    from r in _context.Roles
                    from q in _context.Qualifications
                    from s in _context.Staffs
                    where s.RoleId == r.RoleId && s.QualificationId == q.QualificationId
                    select new StaffsVM
                    {
                        StaffId = s.StaffId,
                        StaffName = s.StaffName,
                        StaffPhone = s.StaffPhone,
                        StaffEmail = s.StaffEmail,
                        StaffAddress = s.StaffAddress,
                        StaffDob = s.StaffDob,
                        QualificationName = q.QualificationName,
                        RoleName = r.RoleName,
                        StaffJoiningDate = s.StaffJoiningDate
                    }
                    ).ToListAsync();
            }
            return null;
        }

        //Get a staff by id
        public async Task<ActionResult<Staffs>> GetStaffById(int? id)
        {
            
                if (_context != null)
                {
                    var staff = await _context.Staffs.FindAsync(id);  //Primary key
                    return staff;
                }
                return null;
            
        }

        
        //Update staff
        public async Task UpdateStaff(Staffs staff)
        {
            if (_context != null)
            {
                _context.Entry(staff).State = EntityState.Modified;
                _context.Staffs.Update(staff);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Medicines

        //List Medicines View Model
        public async Task<List<MedicinesVM>> ListMedicines()
        {
            if (_context != null)
            {
                return await (
                    from mfg in _context.Manufactures
                    from med in _context.MedicineDetails
                    from inv in _context.MedicineInventories
                    where inv.ManufactureId == mfg.ManufactureId && inv.MedicineId == med.MedicineId
                    select new MedicinesVM
                    {
                        InventoryId = inv.InventoryId,
                        MedicineName = med.MedicineName,
                        MedicineQuantity = inv.MedicineQuantity,
                        MedicineType = inv.MedicineType,
                        ManufactureName = mfg.ManufactureName,
                        ManufacturingDate = med.ManufacturingDate,
                         ExpiryDate = med.ExpiryDate,
                         MedicinePrice = med.MedicinePrice
                    }
                    ).ToListAsync();
            }
            return null;
        }
        #endregion
    }
}
