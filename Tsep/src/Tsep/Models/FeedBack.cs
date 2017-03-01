using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Models
{
    public class FeedBack:TableEntity
    {
        public FeedBack()
        {
            this.PartitionKey = "Feedback";
           
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
