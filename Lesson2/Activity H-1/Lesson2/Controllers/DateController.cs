using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson2.Controllers
{
    public class DateController : Controller
    {
        [ResponseCache(Duration = 600)]
        public IActionResult Index()
        {
            return Content(DateTime.Now.ToShortTimeString());
        }
    }

}
