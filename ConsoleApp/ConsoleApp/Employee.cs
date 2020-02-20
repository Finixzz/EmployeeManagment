using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Employee
    {

        public int Id { get; set; }
        public String FirstName{ get; set; }
        public String LastName { get; set; }
        public Department Department { get; set; }

        public Employee(Department dept)
        {
            Department = dept;
        }

        private void setFirstName()
        {
            Console.Write("Input employees first name: ");
            this.FirstName = Console.ReadLine();
        }
        private void setLastName()
        {
            Console.Write("Input employees last name: ");
            this.LastName = Console.ReadLine();
        }
        private void setDepartment(Department department)
        {
            Department = department;
        }

        public void setEmployee(Department department)
        {
            this.setFirstName();
            this.setLastName();
            this.setDepartment(department);
        }

        public void printEmployeeInfo()
        {
            Console.WriteLine("ID: " + this.Id);
            Console.WriteLine("First Name: " + this.FirstName);
            Console.WriteLine("Last Name: " + this.LastName);
            Console.WriteLine("Department: "+Department.Name);
        }
    }
}
