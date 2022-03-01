using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.Repository
{
    public interface IAdminRepository
    {


        #region staffs
        
        //List from db
        Task<List<Staffs>> GetStaffs();

        //List from view model
        Task<List<StaffsVM>> ListStaffs();


        //Get staff by id
        Task<ActionResult<Staffs>> GetStaffById(int? id);

        //Add staff to db
        Task<int> AddStaff(Staffs staff);

        //Update staff
        Task UpdateStaff(Staffs staff);
        #endregion


        #region Qualifications

        //List from db
        Task<List<Qualifications>> GetQualifications();
        #endregion


        #region Roles

        //List from db
        Task<List<Roles>> GetRoles();
        #endregion


        #region Medicines Inventory

        //List Medicines View Model
        Task<List<MedicinesVM>> ListMedicines();

        //List Medicine Inventory from db
        Task<List<MedicineInventories>> GetInventories();

        //Delete inventory
        Task<int> DeleteInventory(int? id);

        //Add inventory to db
        Task<int> AddInventory(MedicineInventories inv);

        //Get inventory by id
        Task<ActionResult<MedicineInventories>> GetInventoryById(int? id);

        //Update inventory
        Task UpdateInventory(MedicineInventories inventories);
        #endregion

        #region Medicine Details

        //List from db medicine details
        Task<List<MedicineDetails>> GetMedicineDetails();

        //Add Medicine
        Task<int> AddMedicine(MedicineDetails medicine);

        //Delete Medicine
        Task<int> DeleteMedicine(int? id);

        //Update Medicine
        Task UpdateMedicine(MedicineDetails medicine);
        #endregion

        #region Manufactures

        //List from db
        Task<List<Manufactures>> GetMfgs();

        //Delete mfg
        Task<int> DeleteManufacture(int? id);

        //Update Manufacture
        Task UpdateManufacture(Manufactures manufacture);
        #endregion



    }
}

