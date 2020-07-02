using System.Collections.Generic;
using WebStoreTerehin.Models;

namespace WebStoreTerehin.Controllers.Infrastructure.Interfaces
{
    public interface IEmployeesData
    {
        IEnumerable<Employee> Get();

        Employee GetById(int id);

        int Add(Employee employee);

        void Employee(Employee employee);

        bool Delete(int id);

        void SaveChanges();
    }
}
