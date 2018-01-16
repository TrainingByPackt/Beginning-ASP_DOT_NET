using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return Content("Hello World! I am learning MVC!");
        }
        public IActionResult IndexUpper()
        {
            return new UpperStringActionResult("Hello World! I am learning MVC!");
        }
    }
}
