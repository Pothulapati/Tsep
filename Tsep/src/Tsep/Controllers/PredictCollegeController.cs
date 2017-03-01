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
        private StorageCredentials creds;
        private TableQuery<CutOffEntity> que;
        private TableOperation operation;
        IEnumerable<SelectListItem> selectlist;
        public PredictCollegeController()
        {
            creds = new StorageCredentials("eamcetts2016", "j76JE1NR/K2BAy57zaR4nN6JLris6eJ2Ourjs8GOKqaTMvHkX6k5SYA2ld1jZ45kcj9nAzgU49fqvv6Wwmi3tg==");
            account = new CloudStorageAccount(creds, false);
            tableclient = account.CreateCloudTableClient();
            table = tableclient.GetTableReference("Colleges");
            cutofs = tableclient.GetTableReference("Cutoffs");
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetColleges(int rank)
        {

            return View();
        }

    }
}
