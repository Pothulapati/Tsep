using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tsep.Entities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tsep.Controllers
{
    public class PredictorController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Page = "Predictor";
            var Model = new Prediction();
            Model.Done = false;
            return View(Model);
        }
        [HttpPost]
        public IActionResult Index(Prediction Model)
        {
            Model.CombinedScore = (int)((double)Model.GroupTotal*25/600 +(double)Model.EamcetTotal*75/16);
            Model.CombinedScore = (int)Model.CombinedScore;
            Model.Done = true;
            ViewBag.Page = "Predictor";
            return View(Model);
        }
    }
}
