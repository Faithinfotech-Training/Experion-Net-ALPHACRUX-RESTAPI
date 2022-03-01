using Clinic_Management_System.Models;
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

        //List Medicine Inventory from db
        public async Task<List<MedicineInventories>> GetInventories()
        {
            if (_context != null)
            {
                return await _context.MedicineInventories.ToListAsync();
            }
            return null;
        }


        //Delete inventory
        public async Task<int> DeleteInventory(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var inventory = await _context.MedicineInventories.FirstOrDefaultAsync(inv => inv.InventoryId == id);
                if (inventory != null) //Check condition
                {
                    //Delete
                    _context.MedicineInventories.Remove(inventory);

                    //Commiting to change the physical db
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        //Add to inventory
        public async Task<int> AddInventory(MedicineInventories inv)
        {
            if (_context != null)
            {
                await _context.MedicineInventories.AddAsync(inv);
                await _context.SaveChangesAsync(); //commit the transaction
                return inv.InventoryId;
            }
            return 0;
        }

        //Get inventory by id
        public async Task<ActionResult<MedicineInventories>> GetInventoryById(int? id)
        {
            if (_context != null)
            {
                var inv = await _context.MedicineInventories.FindAsync(id);  //Primary key
                return inv;
            }
            return null;
        }

        //Update inventory
        public async Task UpdateInventory(MedicineInventories inventories)
        {
            if (_context != null)
            {
                _context.Entry(inventories).State = EntityState.Modified;
                _context.MedicineInventories.Update(inventories);
                await _context.SaveChangesAsync();
            }
        }
        #endregion


        #region Medicine Details

        //List from db medicine details
        public async Task<List<MedicineDetails>> GetMedicineDetails()
        {
            if (_context != null)
            {
                return await _context.MedicineDetails.ToListAsync();
            }
            return null;
        }

        //Add Medicine
        public async Task<int> AddMedicine(MedicineDetails medicine)
        {
            if (_context != null)
            {
                await _context.MedicineDetails.AddAsync(medicine);
                await _context.SaveChangesAsync(); //commit the transaction
                return medicine.MedicineId;
            }
            return 0;
        }

        //Delete Medicine
        public async Task<int> DeleteMedicine(int? id)
        {   
            int result = 0;
            if (_context != null)
            {
                var medicines = await _context.MedicineDetails.FirstOrDefaultAsync(medicine => medicine.MedicineId == id);
                if (medicines != null) //Check condition
                {
                    //Delete
                    _context.MedicineDetails.Remove(medicines);

                    //Commiting to change the physical db
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        //Update MedicineDetails
        public async Task UpdateMedicine(MedicineDetails medicine)
        {
            if (_context != null)
            {
                _context.Entry(medicine).State = EntityState.Modified;
                _context.MedicineDetails.Update(medicine);
                await _context.SaveChangesAsync();
            }
        }
        #endregion


        #region Mfgs

        //List Manufactures
        public async Task<List<Manufactures>> GetMfgs()
        {
            if (_context != null)
            {
                return await _context.Manufactures.ToListAsync();
            }
            return null;
        }


        // Delete Manufactures
        public async Task<int> DeleteManufacture(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var mfgs = await _context.Manufactures.FirstOrDefaultAsync(mfg => mfg.ManufactureId == id);
                if (mfgs != null) //Check condition
                {
                    //Delete
                    _context.Manufactures.Remove(mfgs);

                    //Commiting to change the physical db
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        //Update Manufactures
        public async Task UpdateManufacture(Manufactures manufacture)
        {
            if (_context != null)
            {
                _context.Entry(manufacture).State = EntityState.Modified;
                _context.Manufactures.Update(manufacture);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
