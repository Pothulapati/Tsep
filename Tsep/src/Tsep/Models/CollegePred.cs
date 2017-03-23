using System.Collections.Generic;

namespace Tsep.Models
{
    public class CollegePred
    {
	public int Rank { get; set; }
	public string Caste { get; set; }
	public string Region { get; set; }
	public string Sex { get; set; }
	public string Group { get; set; }
	public int Count { get; set; }
	public IEnumerable<CollegeCutoffEntity> colgs {get;set;}

    }
}