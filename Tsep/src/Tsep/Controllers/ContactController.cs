using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tsep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Auth;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tsep.Controllers
{
    public class ContactController : Controller
    {
        private CloudStorageAccount account;
        private CloudTableClient tableclient;
        private CloudTable table;
        private StorageCredentials creds;
        private TableQuery<FeedBack> query;
        TableOperation op;
        public ContactController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds, false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("Feedbackk");   
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
	    ViewBag.Title = "Contact";
	    ViewBag.Page = "Contact";
            return View();
        }
        [HttpPost]
        public  IActionResult SendFeedback(FeedBack Model)
        {
            var result = table.ExecuteQuerySegmentedAsync<FeedBack>(query, null);
           Model.RowKey =  result.Result.Count().ToString();
            op = TableOperation.Insert(Model);
            table.ExecuteAsync(op);
            ViewBag.Name = Model.Name;
	    ViewBag.Page = "Contact";
	    ViewBag.Title = "Contact";
            return View("Thanks");
        }
    }
}
