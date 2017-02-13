using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Entities
{
    public class Prediction
    {
        public int GroupTotal { get; set; }
        public int EamcetTotal { get; set; }
        public bool Done { get; set; }
        public int RankMin { get; set; }
        public int RankMax { get; set; }
        public int CombinedScore { get; set; }
    }
}
