using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Models
{
    public class RankRangeEntity:TableEntity
    {
        public RankRangeEntity()
        {
            this.RowKey = Number;

            this.PartitionKey = "Ranks";
        }
        public string Number { get; set; }
        public int max { get; set; }
        public int min { get; set; }
    }
}
