using System;
using System.Collections.Generic;

namespace CMS_Project.Models
{
    public partial class Units
    {
        public Units()
        {
            TestDetails = new HashSet<TestDetails>();
        }

        public int UnitId { get; set; }
        public string TestUnit { get; set; }

        public virtual ICollection<TestDetails> TestDetails { get; set; }
    }
}
