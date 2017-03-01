using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Models;

namespace Tsep.Entities
{
    public class CollegeDetails
    {
        public CollegeEntity college { get; set; }
        public IEnumerable<SelectListItem> Colleges { get; set; }
        public bool colgselected { get; set; }
        public List<CutOffEntity> Cutoofs { get; set; }

    }
}
