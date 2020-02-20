using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static int menu()
        {
            int izbor;
            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("------EMPLOYEE Menu---------");
                Console.WriteLine("----------------------------");
                Console.Write("1) Create employee\n");
                Console.Write("2) Edit employee\n");
                Console.Write("3) Get employee\n");
                Console.Write("4) Get employee(s)\n");
                Console.Write("5) Delete employee\n");
                Console.Write("6) END\n");
                Console.WriteLine("----------------------------");
                Console.Write("Input choice: ");
                izbor = Convert.ToInt32(Console.ReadLine());
                return izbor;
            } while (true);
        }

        //Dependency injection
        static IDepartmentRepository CreateDepartmentRepository()
        {
            return new MockUpDepartmentRepository();
        }
        static IEmployeeRepository CreateEmployeeRepository()
        {
            return new MockUpEmployeeRepository(CreateDepartmentRepository());
        }

        static void Main(string[] args)
        {
            IDepartmentRepository departmentRepository = CreateDepartmentRepository();
            IEmployeeRepository employeeRepository = CreateEmployeeRepository();
            var departmentsInRepository = departmentRepository.GetDepartments();
            int izbor;
            bool programFlow = true;
            do
            {
                izbor = menu();
                switch (izbor)
                {
                    case 1:
                        Department department = departmentRepository.GetDepartment(1);
                        Employee employee = new Employee(department);
                        Console.WriteLine("Select department type");
                        Console.WriteLine("----------------------");
                        for(int i = 0; i < departmentsInRepository.Count(); i++)
                        {
                            departmentsInRepository[i].printDepartmentInfo();
                        }
                        Console.WriteLine("----------------------");
                        int deptId;
                        Console.Write("Input department id: ");
                        deptId = Convert.ToInt32(Console.ReadLine());
                        department = departmentRepository.GetDepartment(deptId);
                        while (department == null)
                        {
                            Console.Write("Input department id: ");
                            deptId = Convert.ToInt32(Console.ReadLine());
                            department = departmentRepository.GetDepartment(deptId);
                        }
                        employee.setEmployee(department);
                        employeeRepository.CreateEmployee(employee);
                        break;


                    case 2:
                        break;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        break;

                    case 6:
                        programFlow = false;
                        break;





                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            } while (programFlow);
        }
    }
}
