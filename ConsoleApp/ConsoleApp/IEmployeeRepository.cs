using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee CreateEmployee(Employee employee);
        Employee EditEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }
}
