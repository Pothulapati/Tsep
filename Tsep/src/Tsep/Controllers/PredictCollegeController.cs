using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;
using Tsep.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tsep.Controllers
{
    public class PredictCollegeController : Controller
    {

        private CloudStorageAccount account;
        private CloudTableClient tableclient;
        private CloudTable table;
        private CloudTable cutofs;
        private CloudTable allotments;
        private StorageCredentials creds;
        private TableQuery<CollegeCutoffEntity> que;
        private TableOperation operation;
        IEnumerable<SelectListItem> selectlist;
        public PredictCollegeController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds, false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("colaa");

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
	    ViewBag.Title = "College Predictor";
	    ViewBag.Page = "College Predcitor";
	    return View();
        }
        public IActionResult GetColleges(CollegePred pred)
        {
            string reservation = pred.Caste + "_" + pred.Sex + "_" + pred.Region;
	    if (pred.Group == "all")
	    {
		if(pred.Count ==0)
		que = new TableQuery<CollegeCutoffEntity>().Where(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, reservation), TableOperators.And, TableQuery.GenerateFilterConditionForInt("Rank", QueryComparisons.GreaterThanOrEqual, Convert.ToInt32(pred.Rank))));
	    }
	    else
	    {
		que = new TableQuery<CollegeCutoffEntity>().Where(TableQuery.CombineFilters(TableQuery.CombineFilters(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, reservation), TableOperators.And, TableQuery.GenerateFilterConditionForInt("Rank", QueryComparisons.GreaterThanOrEqual, Convert.ToInt32(pred.Rank))), TableOperators.And, TableQuery.GenerateFilterCondition("GroupCode", QueryComparisons.Equal, pred.Group)));
	    }
	    IEnumerable<CollegeCutoffEntity> cuts = table.ExecuteQuerySegmentedAsync(que, null).Result.ToList().OrderBy(r=>r.Rank);
	    pred.colgs = cuts.Take(pred.Count);
	    ViewBag.Title = "College Predictor";
	    ViewBag.Page = "College Predcitor";
            return View(pred);
            
        }

    }
}
