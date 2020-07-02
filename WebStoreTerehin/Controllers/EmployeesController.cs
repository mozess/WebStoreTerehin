using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreTerehin.Data;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Controllers
{
    //[Route("Users")]
    public class EmployeesController : Controller
    {
        //[Route("All")]
        public IActionResult Index()=> View(TestData.Employees);
       
        public IActionResult AddEmployees() => View();

        //[Route("User-{id}")]
        public IActionResult Details(int id)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        public IActionResult DeleteEmployees(int id)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            TestData.Employees.Remove(employee);

            return RedirectToRoute("default", new { controller = "Employees", action = "Index"});
        }
        public IActionResult AddEmp(string surname, string name, string patronymic, string age, string employment)
        {
            if (surname is null)
                return NotFound();
            if (name is null)
                return NotFound();
            if (patronymic is null)
                return NotFound();
            int _age;
            if (!int.TryParse(age, out _age))
                return NotFound();

            DateTime _employment;
            if (!DateTime.TryParse(employment, out _employment))
                return NotFound();

            int id;
            if (TestData.Employees.Count() == 0)
                id = 1;
            else
                id = TestData.Employees.Max(e => e.Id) + 1;

            TestData.Employees.Add(new Employee
            {
                Id = id,
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Age = _age,
                DateOfEmployment = _employment
            });

            return RedirectToRoute("default", new { controller = "Employees", action = "Index" });
        }

    }
}
