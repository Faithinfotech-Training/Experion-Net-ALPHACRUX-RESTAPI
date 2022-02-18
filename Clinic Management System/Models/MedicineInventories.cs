using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class MedicineInventories
    {
        public MedicineInventories()
        {
            MedicineBills = new HashSet<MedicineBills>();
        }

        public int InventoryId { get; set; }
        public string MedicineType { get; set; }
        public int? MedicineId { get; set; }
        public int? ManufactureId { get; set; }
        public int? MedicineQuantity { get; set; }

        public virtual Manufactures Manufacture { get; set; }
        public virtual MedicineDetails Medicine { get; set; }
        public virtual ICollection<MedicineBills> MedicineBills { get; set; }
    }
}
