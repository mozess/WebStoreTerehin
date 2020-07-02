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

        public IActionResult AddEmployees() => View();


        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        public IActionResult DeleteEmployees(int id)
        {
            var employee = _Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null)
                return NotFound();

            _Employees.Remove(employee);

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
            if (_Employees.Count() == 0)
                id = 1;
            else
                id = _Employees.Max(e => e.Id) + 1;

            _Employees.Add(new Employee
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
