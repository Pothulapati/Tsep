using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private TsEamcetContext _context;
        private IEnumerable<SelectListItem> colleges;
        public CollegesController()
        {
            TsEamcetContext context = new TsEamcetContext();
            _context = context;
            colleges =  _context.Colleges.ToList().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Code

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
            ViewBag.Page = "Colleges";
            colgdet.colgs = colleges;
            colgdet.college =   _context.Colleges.First<Colleges>( x => x.Code == colgdet.college.Code);
            colgdet.colgselected = true;
            return View(colgdet);

        }
    }
}
