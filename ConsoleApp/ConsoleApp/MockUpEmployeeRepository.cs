using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class MockUpEmployeeRepository
    {
        private List<Employee> employeeList;

        public MockUpEmployeeRepository()
        {
            employeeList = new List<Employee>()
            {
                new Employee(new Department()){ Id=1,FirstName="Amet",LastName="Durmic"},


            };
        }
    }
}
