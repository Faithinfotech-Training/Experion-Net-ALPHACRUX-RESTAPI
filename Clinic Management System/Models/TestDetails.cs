using System;
using System.Collections.Generic;

namespace Clinic_Management_System.Models
{
    public partial class TestDetails
    {
        public TestDetails()
        {
            Reportlist = new HashSet<Reportlist>();
            TestLists = new HashSet<TestLists>();
        }

        public int TestId { get; set; }
        public string TestName { get; set; }
        public int MaximumValue { get; set; }
        public int MinimumValue { get; set; }
        public int TestAmount { get; set; }
        public int? UnitId { get; set; }

        public virtual Units Unit { get; set; }
        public virtual ICollection<Reportlist> Reportlist { get; set; }
        public virtual ICollection<TestLists> TestLists { get; set; }
    }
}
