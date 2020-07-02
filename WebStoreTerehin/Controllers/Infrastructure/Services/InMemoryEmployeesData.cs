using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreTerehin.Controllers.Infrastructure.Interfaces;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Controllers.Infrastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        public int Add(Employee employee) { throw new NotImplementedException(); }

        public bool Delete(int id) { throw new NotImplementedException(); }

        public void Employee(Employee employee) { throw new NotImplementedException(); }

        public IEnumerable<Employee> Get() { throw new NotImplementedException(); }

        public Employee GetById(int id) { throw new NotImplementedException(); }

        public void SaveChanges() { throw new NotImplementedException(); }
    }
}
