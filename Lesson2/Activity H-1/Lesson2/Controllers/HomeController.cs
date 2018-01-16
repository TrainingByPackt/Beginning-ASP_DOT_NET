using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lesson2.Models;

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
        public IActionResult Index2()
        {
            return View(); // View for this 'Index2' action method 
        }
        [SundayFilter]
        public IActionResult Employee()
        {
            //Sample Model - Usually this comes from database 
            Employee emp1 = new Employee
            {
                EmployeeId = 1,
                Name = "Jon Skeet",
                Designation = " Software Architect"
            };
            ViewBag.Company = "Google Inc";
            ViewData["CompanyLocation"] = "United States";

            return View(emp1);

        }


    }
}
