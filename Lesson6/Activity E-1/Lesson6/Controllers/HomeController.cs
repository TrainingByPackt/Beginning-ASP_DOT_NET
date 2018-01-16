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
        [AcceptHeader("text/html")]
        [HttpGet("Index2")]
        public IActionResult Index2_HTML()
        {
            return Content("HTML response returns");
        }

        [AcceptHeader("application/json")]
        [HttpGet("Index2")]
        public IActionResult Index2_JSON()
        {
            return Content("Json response returns");
        }

    }





}
