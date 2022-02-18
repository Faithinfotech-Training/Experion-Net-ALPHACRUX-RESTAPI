using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.ViewModel
{
    public class MedicinesVM
    {
        public int InventoryId { get; set; }
        public string MedicineType { get; set; }
        public int? MedicineQuantity { get; set; }
        public string MedicineName { get; set; }
        public int MedicinePrice { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public string ManufactureName { get; set; }
    }
}
