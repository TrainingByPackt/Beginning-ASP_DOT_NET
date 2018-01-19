using System;
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
        [HttpGet("details/{id:int?}")]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet("details2/{id:int?}")]
        public IActionResult Details2(int id = 123)
        {
            return View();
        }


    }




}
