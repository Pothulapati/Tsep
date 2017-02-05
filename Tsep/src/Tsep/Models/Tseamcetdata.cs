using System;
using System.Collections.Generic;

namespace Tsep.Models
{
    public partial class Tseamcetdata
    {
        public byte PartitionKey { get; set; }
        public int RowKey { get; set; }
        public string Timestamp { get; set; }
        public string Caste { get; set; }
        public decimal? CombinedScore { get; set; }
        public byte? EamcetChemistry { get; set; }
        public byte? EamcetMaths { get; set; }
        public byte? EamcetPhysics { get; set; }
        public byte? EamcetTotal { get; set; }
        public decimal? EamcetW { get; set; }
        public string FathersName { get; set; }
        public string GroupTotal { get; set; }
        public decimal? InterPercent { get; set; }
        public decimal? InterW { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
        public string Region { get; set; }
        public int? RegisNo { get; set; }
        public string Result { get; set; }
        public string Sex { get; set; }
        public string Stream { get; set; }
    }
}
