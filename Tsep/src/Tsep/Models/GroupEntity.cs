using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Models
{
    public class GroupEntity:TableEntity
    {
        public GroupEntity()
        {
           
        }
        public string College_Group { get; set; }
        public int Fee { get; set; }
        public int Intake { get; set; }
    }
}
