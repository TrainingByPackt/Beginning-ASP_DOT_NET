﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson6.Controllers
{

    [Route("Home")]
    public class HomeController : Controller
    {
        // GET: /<controller>/ 
        [HttpGet()]
        public IActionResult Index()
        {
            return Content("Index action method");
        }

        [HttpGet("Index3")]
        public IActionResult Index2()
        {
            return Content("Index2 action method");
        }
        [HttpPost("Index3")]
        public IActionResult Index2_Post()
        {
            return Content("Index2 post method");
        }

    }




}
