using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Models
{
    public class CollegeCutoffEntity : TableEntity
    {
        public CollegeCutoffEntity()
        {

        }
        public int Rank { get; set; }
        public string CollegeCode { get; set; }
        public string   CollegeName { get; set; }
        public string GroupCode { get; set; }
        public string   GroupName { get; set; }
    }
}
