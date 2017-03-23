using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Table;
using Tsep.Models;
using Tsep.Entities;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tsep.Controllers
{
    public class RankController : Controller
    {
        // GET: /<controller>/

        private CloudStorageAccount account;
        private CloudTableClient tableclient;
        private CloudTable table;
        private CloudTable cutofs;
        private TableOperation operation;
        private StorageCredentials creds;
        public RankController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds, false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("Predictions");
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var Model = new Prediction();
            ViewBag.page = "Rank Predictor";
	    ViewBag.Title = "Rank Predictor";
            Model.Done = false;
            return View(Model);
        }
        [HttpPost]
        public async Task<IActionResult> Getdata(Prediction Model)
        {
	    if (Model.EamcetTotal <= 160&&Model.EamcetTotal >0 && Model.GroupTotal <= 600&&Model.GroupTotal>0)
	    {
		Model.EamcetWeightage = (((float)Model.EamcetTotal / 160) * 75);
		Model.InterWeightage = ((float)Model.GroupTotal * 25) / 600;
		Model.CombinedScore = (int)(Model.EamcetWeightage + Model.InterWeightage);
		Model.Done = true;
		operation = TableOperation.Retrieve<RankRangeEntity>("Ranks", Model.CombinedScore.ToString());
		TableResult result = await table.ExecuteAsync(operation);
		Model.Rankrange = (RankRangeEntity)result.Result;
		Model.CombinedScore = Model.EamcetWeightage + Model.InterWeightage;
		ViewBag.Page = "Rank Predictor";
		ViewBag.Title = "Rank Predictor";
		
	    }
            return View(Model);
        }
    }
}
