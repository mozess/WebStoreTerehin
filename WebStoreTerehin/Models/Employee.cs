﻿using System;


namespace WebStoreTerehin.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public DateTime DateOfEmployment { get;set;}
    }
}
