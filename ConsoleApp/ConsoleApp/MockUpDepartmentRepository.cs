using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp
{
    public class MockUpDepartmentRepository : IDepartmentRepository
    {
        private List<Department> departmentList;

        public MockUpDepartmentRepository()
        {
            departmentList = new List<Department>()
            {
                new Department{Id=1,Name="None"},
                new Department{Id=2, Name="IT"},
                new Department{Id=3,Name="HR"},
            };
        }
        public Department GetDepartment(int id)
        {
            Department departmentInRepo = departmentList.SingleOrDefault(c => c.Id == id);
            if(departmentInRepo==null)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Invalid department id!");
                Console.WriteLine("----------------------");
                return null;
            }
            return departmentInRepo;
        }


        List<Department> IDepartmentRepository.GetDepartments()
        {
            return departmentList;
        }
    }
}
