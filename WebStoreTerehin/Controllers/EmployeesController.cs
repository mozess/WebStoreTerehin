using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Controllers
{
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> _Employees = new List<Employee>
        {
            new Employee
            {
                Id=1,
                Surname="Иванов",
                Name = "Иван",
                Patronymic="Иванович",
                Age=39,
                DateOfEmployment=Convert.ToDateTime("01.01.2010")
            },
            new Employee
            {
                Id=2,
                Surname="Петров",
                Name = "Петр",
                Patronymic="Петрович",
                Age=49,
                DateOfEmployment=Convert.ToDateTime("01.01.2015")
            },
            new Employee
            {
                Id=3,
                Surname="Степанов",
                Name = "Степан",
                Patronymic="Степанович",
                Age=18,
                DateOfEmployment=Convert.ToDateTime("01.01.2020")
            },
        };
        public IActionResult Index()=> View(_Employees);

        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }
    }
}
