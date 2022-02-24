﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Management_System.ViewModels
{
    public class ReceptionPaymentViewModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime DateTime { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public string PaymentMode { get; set; }
    }
}