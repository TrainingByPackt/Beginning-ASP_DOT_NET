using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Activity3C1.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Activity3C1.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ValidateAge()
        {
            ViewBag.Title = "Validate Age for voting";
            Person person1 = new Person();
            return View(person1);
        }
        [HttpPost]
        public IActionResult ValidateAge(Person person1)
        {

            if(Convert.ToBoolean(Request.Form["OlderThan18"][0]))
            {
                ViewData["OlderThan18"] = true;
                ViewBag.Message = "You are eligible to Vote!";
            }
            else
            {
                ViewBag.Message = "Sorry.You are not old enough to vote!";
            }
            return View();
        }

    }
}
