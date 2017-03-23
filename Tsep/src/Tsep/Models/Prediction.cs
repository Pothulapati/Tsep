using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Models;

namespace Tsep.Entities
{
    public class Prediction
    {
       [Range(0,600)]
        public int GroupTotal { get; set; }
	[Range(0,160)]
        public int EamcetTotal { get; set; }
        public bool Done { get; set; }
        public RankRangeEntity Rankrange { get; set;}
        public double  EamcetWeightage { get; set; }
        public double InterWeightage { get; set; }
        public double CombinedScore { get; set; }
    }
}
