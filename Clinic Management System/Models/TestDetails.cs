using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class TestDetails
    {
        public TestDetails()
        {
            TestLists = new HashSet<TestLists>();
            TestReports = new HashSet<TestReports>();
            Units = new HashSet<Units>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        public int NormalValue { get; set; }
        public int TestAmount { get; set; }

        public virtual ICollection<TestLists> TestLists { get; set; }
        public virtual ICollection<TestReports> TestReports { get; set; }
        public virtual ICollection<Units> Units { get; set; }
    }
}
