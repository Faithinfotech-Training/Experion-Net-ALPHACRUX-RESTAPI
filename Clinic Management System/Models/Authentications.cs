using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class Authentications
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? StaffId { get; set; }

        public virtual Staffs Staff { get; set; }
    }
}
