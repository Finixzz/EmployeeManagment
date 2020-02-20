using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ConsoleApp
{
    public class MockUpEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employeeList;
        private IDepartmentRepository deparmentList;

        public MockUpEmployeeRepository(IDepartmentRepository _departmentRepo)
        {
            deparmentList = _departmentRepo;
            Department d1 = new Department();
            d1 = deparmentList.GetDepartment(1);
            Department d2 = new Department();
            d2 = deparmentList.GetDepartment(2);
            Department d3 = new Department();
            d3 = deparmentList.GetDepartment(3);
            employeeList = new List<Employee>()
            {
                new Employee(d1){Id=1,FirstName="Ahmet",LastName="Durmic"},
                new Employee(d2){Id=2,FirstName="Mujo",LastName="Mujic"},
                new Employee(d3){Id=3,FirstName="SoHa",LastName="Hasic"}
            };
        }

        public Employee CreateEmployee(Employee employee)
        {
            if (employeeList.Count() == 0)
            {
                employee.Id = 1;
            }
            else
            {
                employee.Id = employeeList.Max(c => c.Id) + 1;
            }
            employeeList.Add(employee);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Employee added successfully to repository!");
            Console.WriteLine("------------------------------------------");
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employeeInRepo = employeeList.SingleOrDefault(c => c.Id == id);
            if(employeeInRepo==null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid employee ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                employeeList.Remove(employeeInRepo);
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Employee DELETED successfully from repository!");
                Console.WriteLine("----------------------------------------------");
                return employeeInRepo;
            }
            
        }

        public Employee EditEmployee(Employee employee)
        {
            Employee employeeInRepo = employeeList.SingleOrDefault(c => c.Id == employee.Id);
            if (employeeInRepo == null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid employee ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                employeeInRepo.FirstName = employee.FirstName;
                employeeInRepo.LastName = employee.LastName;
                employeeInRepo.Department = employee.Department;
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Employee data successfully updated!");
                Console.WriteLine("-----------------------------------");
                return employeeInRepo;
            }
        }

        public Employee GetEmployee(int id)
        {
            Employee employeeInRepo = employeeList.SingleOrDefault(c => c.Id == id);
            if (employeeInRepo == null)
            {
                Console.WriteLine("--------------------");
                Console.WriteLine("Invalid employee ID!");
                Console.WriteLine("--------------------");
                return null;
            }
            else
            {
                return employeeInRepo;
            }
        }

        List<Employee> IEmployeeRepository.GetEmployees()
        {
            return employeeList;
        }
    }
}
