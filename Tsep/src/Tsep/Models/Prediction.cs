using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Models;

namespace Tsep.Entities
{
    public class Prediction
    {
       
        public int GroupTotal { get; set; }
        [DisplayName("Eamcet Total")]
        public int EamcetTotal { get; set; }
        public bool Done { get; set; }
        public RankRangeEntity Rankrange { get; set;}
        public double  EamcetWeightage { get; set; }
        public double InterWeightage { get; set; }
        public double CombinedScore { get; set; }
    }
}
