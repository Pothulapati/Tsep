using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tsep.Models
{
    public class CutOffEntity:TableEntity
    {
        public int OC_GEN_OU { get; set; }
	public int OC_GIRLS_OU { get; set; }
        public int BC_A_GEN_OU { get; set; }
	public int BC_A_GIRLS_OU { get; set; }
        public int BC_B_GEN_OU { get; set; }
	public int BC_B_GIRLS_OU { get; set; }
	public int BC_C_GEN_OU { get; set; }
	public int BC_C_GIRLS_OU { get; set; }
	public int BC_D_GEN_OU { get; set; }
	public int BC_D_GIRLS_OU { get; set; }
	public int BC_E_GEN_OU { get; set; }
	public int BC_E_GIRLS_OU { get; set; }
	public int SC_GEN_OU { get; set; }
	public int SC_GIRLS_OU { get; set; }
	public int ST_GEN_OU { get; set; }
	public int ST_GIRLS_OU { get; set; }
    }
}
