using System;
using System.Collections.Generic;

namespace Tsep.Models
{
    public partial class Colleges
    {
        public Colleges()
        {
            CollegeGroups = new HashSet<CollegeGroups>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string CoEd { get; set; }
        public string Minority { get; set; }
        public string Region { get; set; }
        public string Aided { get; set; }
        public string Type { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public string Hostel { get; set; }
        public string District { get; set; }
        public short? EstablishmentYear { get; set; }
        public string Email { get; set; }
        public string Affliation { get; set; }
        public string Website { get; set; }

        public virtual ICollection<CollegeGroups> CollegeGroups { get; set; }
    }
}
