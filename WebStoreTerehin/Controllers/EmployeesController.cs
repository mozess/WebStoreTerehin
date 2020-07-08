using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStoreTerehin.Controllers.Infrastructure.Interfaces;
using WebStoreTerehin.Data;
using WebStoreTerehin.Models;
using WebStoreTerehin.ViewModels;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebStoreTerehin.Controllers
{
    //[Route("Users")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData EmployeesData) { _EmployeesData = EmployeesData; }

        //[Route("All")]
        public IActionResult Index() => View(_EmployeesData.Get());

        public IActionResult AddEmployees() => View();

        //[Route("User-{id}")]
        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeesViewModel());

            if (id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.Name,
                LastName = employee.Surname,
                Patronymic=employee.Patronymic,
                Age = employee.Age,
                DateOfEmployment=employee.DateOfEmployment
            }) ;
        }
        [HttpPost]
        public IActionResult Edit(EmployeesViewModel Model)
        {
            if (Model is null)
                throw new ArgumentNullException(nameof(Model));

            //Валидация

            Regex rgx = new Regex(@"^[А-Я]{1}([а-я])+$");
            if (Model.LastName is null)
                ModelState.AddModelError("LastName", "Заполните поле Фамилия");
            else if (!rgx.IsMatch(Model.LastName))
                ModelState.AddModelError("LastName", "Недопустимые символы в поле Фамилия");

            if (Model.FirstName is null)
                ModelState.AddModelError("FirstName", "Заполните поле Имя");
            else if (!rgx.IsMatch(Model.FirstName))
                ModelState.AddModelError("FirstName", "Недопустимые символы в поле Имя");

            if (Model.Patronymic is null)
                ModelState.AddModelError("Patronymic", "Заполните поле Отчество");
            else if (!rgx.IsMatch(Model.Patronymic))
                ModelState.AddModelError("Patronymic", "Недопустимые символы в поле Отчество");

            if (Model.Age < 16 | Model.Age > 100)
                ModelState.AddModelError("Age", "Возраст указан не верно");

            if (!ModelState.IsValid)
                return View(Model);

            var employee = new Employee
            {
                Id = Model.Id,
                Surname = Model.LastName,
                Name = Model.FirstName,
                Patronymic = Model.Patronymic,
                Age = Model.Age,
                DateOfEmployment = Model.DateOfEmployment
            } ;

            if (Model.Id == 0)
                _EmployeesData.Add(employee);
            else
                _EmployeesData.Edit(employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeesViewModel
            {
                Id = employee.Id,
                FirstName = employee.Name,
                LastName = employee.Surname,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
                DateOfEmployment = employee.DateOfEmployment
            });
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        #endregion

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
