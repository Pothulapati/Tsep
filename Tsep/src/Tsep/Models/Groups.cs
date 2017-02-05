using System;
using System.Collections.Generic;

namespace Tsep.Models
{
    public partial class Groups
    {
        public Groups()
        {
            CollegeGroups = new HashSet<CollegeGroups>();
        }

        public string GroupCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CollegeGroups> CollegeGroups { get; set; }
    }
}
