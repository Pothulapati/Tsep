using System;
using System.Collections.Generic;

namespace Tsep.Models
{
    public partial class CollegeGroups
    {
        public string CollegeGroup { get; set; }
        public string CollegeCode { get; set; }
        public string GroupCode { get; set; }
        public short Intake { get; set; }
        public int Fee { get; set; }

        public virtual Colleges CollegeCodeNavigation { get; set; }
        public virtual Groups GroupCodeNavigation { get; set; }
    }
}
