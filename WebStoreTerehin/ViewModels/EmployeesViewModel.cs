﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreTerehin.ViewModels
{
    public class EmployeesViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int Age { get; set; }

        public DateTime DateOfEmployment { get; set;}
    }
}
