﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tsep.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string id)
        {
            return View(id);
        }
    }
}
