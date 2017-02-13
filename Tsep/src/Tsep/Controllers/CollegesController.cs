using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Entities;
using Tsep.Models;

namespace Tsep.Controllers
{
    public class CollegesController:Controller
    {

        private CloudStorageAccount account;
        private CloudTableClient tableclient;
        private CloudTable table;
        private CloudTable cutofs;
        private StorageCredentials creds;
        private TableQuery<CollegeEntity> query;
        private TableQuery<CutOffEntity> que;
        private IEnumerable<SelectListItem> colleges;
        private TableOperation operation;
        public CollegesController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds,false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("Colleges");
            cutofs = tableclient.GetTableReference("Cutoffs");
            query = new TableQuery<CollegeEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "College"));
            var result = table.ExecuteQuerySegmentedAsync(query, null);
            colleges =  result.Result.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.RowKey

            });
        }
        public IActionResult Index()
        {
            ViewBag.Page = "Colleges";
            var Model = new CollegeDetails();
            Model.colgselected = false;
            Model.colgs = colleges;
            return View(Model);
        }
        [HttpPost]
        public IActionResult Index(CollegeDetails colgdet)
        {
            operation = TableOperation.Retrieve<CollegeEntity>("College", colgdet.college.RowKey);
            ViewBag.Page = "Colleges";
            colgdet.colgs = colleges;
            var result = table.ExecuteAsync(operation);
            colgdet.college = (CollegeEntity)result.Result.Result;
            colgdet.colgselected = true;
            que= new TableQuery<CutOffEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, colgdet.college.RowKey));
           var  results = cutofs.ExecuteQuerySegmentedAsync<CutOffEntity>(que, null);
           colgdet.Cutoofs = results.Result.ToList<CutOffEntity>();
            return View(colgdet);
        }
    }
}
