using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Data
{
    public static class TestData
    {
        public static List<Employee> Employees { get; } = new List<Employee>
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
    }
}
