using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEF.ViewModels;
using MVCEF.Models;


namespace MVCEF.Controllers
{
    public class EmployeeController : Controller
    {
        readonly EmployeeDbContext employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel();
            var db = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = db.Employees.ToList();
            employeeAddViewModel.NewEmployee = new Employee();

            return View(employeeAddViewModel);
        }
        [HttpPost]
        public IActionResult Index(EmployeeAddViewModel employeeAddViewModel)
        {

            var db = this.employeeDbContext;
            db.Employees.Add(employeeAddViewModel.NewEmployee);
            db.SaveChanges();
            //Redirect to get Index GET method 
            return RedirectToAction("Index");

        }

    }
}
