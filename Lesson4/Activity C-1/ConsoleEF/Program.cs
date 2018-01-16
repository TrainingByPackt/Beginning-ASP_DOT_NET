using System;
using System.Linq;

namespace ConsoleEF
{
    class Program
    {
        static void Main(string[] args)
        {
            DeleteEmployee();
        }

        static void AddEmployee()
        {
            using (var db = new EmployeeDbContext())
            {
                Employee employee = new Employee
                {
                    Designation = "Software Engineer",
                    Name = "Scott",
                    Salary = 5600
                };

                db.Employees.Add(employee);
                int recordsInserted = db.SaveChanges();
                Console.WriteLine("Number of records inserted:" +
                 recordsInserted);
                Console.ReadLine();
            }
        }
        static void UpdateSalary()
        {
            using (var db = new EmployeeDbContext())
            {
                Employee employee = db.Employees.Where(emp => emp.EmployeeId == 1).FirstOrDefault();
                if (employee != null)
                {
                    employee.Salary = 6500;
                    int recordsUpdated = db.SaveChanges();
                    Console.WriteLine("Records updated:" + recordsUpdated);
                    Console.ReadLine();
                }
            }
        }

        static void DeleteEmployee()
        {
            using (var db = new EmployeeDbContext())
            using(var transaction = db.Database.BeginTransaction())
            {
                Employee employeeToBeDeleted = db.Employees.Where(emp => emp.EmployeeId == 1).FirstOrDefault();
                if (employeeToBeDeleted != null)
                {
                    db.Entry(employeeToBeDeleted).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    int recordsDeleted = db.SaveChanges();
                    Console.WriteLine("Number of records deleted:" + recordsDeleted);
                    Console.ReadLine();
                }
                transaction.Commit();
            }
        }



    }

}
