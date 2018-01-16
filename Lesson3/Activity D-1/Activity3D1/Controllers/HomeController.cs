using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activity3D1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Activity3D1.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 10012 , Name = "John Skeet"},
                new Employee { Id = 10013 , Name = "Scott Guthrie"},
            };
            return View(employees);
        }
    }
}
