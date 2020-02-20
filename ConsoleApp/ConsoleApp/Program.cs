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
                Console.WriteLine("---- EMPLOYEE CRUD MENU ----");
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

        
        static void printEmployeeRepo(List<Employee> employees)
        {
            Console.WriteLine("Employees in repository");
            Console.WriteLine("-----------------------");
            for(int i = 0; i < employees.Count(); i++)
            {
                employees[i].printEmployeeInfo();
                Console.WriteLine("---------------");
            }
        }
        

        static void Main(string[] args)
        {
            IDepartmentRepository departmentRepository = CreateDepartmentRepository();
            IEmployeeRepository employeeRepository = CreateEmployeeRepository();
            var departmentsInRepository = departmentRepository.GetDepartments();
            var employeesInRepository = employeeRepository.GetEmployees();
            int izbor;
            bool programFlow = true;
            do
            {
                izbor = menu();
                switch (izbor)
                {
                    case 1:
                        Department department;
                        Console.WriteLine("Select department type");
                        Console.WriteLine("----------------------");
                        for (int i = 0; i < departmentsInRepository.Count(); i++)
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
                        Employee employee = new Employee(department);
                        employee.setEmployee(department);
                        employeeRepository.CreateEmployee(employee);
                        break;


                    case 2:
                        if (employeesInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Employee repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            printEmployeeRepo(employeeRepository.GetEmployees());
                            Console.Write("Input employee id: ");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            Employee employeeInRepo = employeeRepository.GetEmployee(employeeId);
                            while (employeeInRepo == null)
                            {
                                Console.Write("Input employee id: ");
                                employeeInRepo = employeeRepository.GetEmployee(employeeId);
                            }
                            Console.WriteLine("Select department type");
                            Console.WriteLine("----------------------");
                            for (int i = 0; i < departmentsInRepository.Count(); i++)
                            {
                                departmentsInRepository[i].printDepartmentInfo();
                            }
                            Console.WriteLine("----------------------");
                            Console.Write("Input department id: ");
                            deptId = Convert.ToInt32(Console.ReadLine());
                            department = departmentRepository.GetDepartment(deptId);
                            while (department == null)
                            {
                                Console.Write("Input department id: ");
                                deptId = Convert.ToInt32(Console.ReadLine());
                                department = departmentRepository.GetDepartment(deptId);
                            }
                            employeeInRepo.setEmployee(department);
                            employeeRepository.EditEmployee(employeeInRepo);
                        }
                       
                        break;

                    case 3:
                        if (employeesInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Employee repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Employee ID's in repository");
                            Console.WriteLine("---------------------------");
                            for (int i = 0; i < employeesInRepository.Count(); i++)
                            {
                                Console.WriteLine("ID: " + employeesInRepository[i].Id);
                                Console.WriteLine("------");
                            }
                            Console.Write("Input employee ID to see employee details: ");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            Employee employeeInRepo = employeeRepository.GetEmployee(employeeId);
                            while (employeeInRepo == null)
                            {
                                Console.Write("Input employee id: ");
                                employeeId = Convert.ToInt32(Console.ReadLine());
                                employeeInRepo = employeeRepository.GetEmployee(employeeId);
                            }
                            employeeInRepo.printEmployeeInfo();
                        }
                        break;

                    case 4:
                        if (employeesInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Employee repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            printEmployeeRepo(employeesInRepository);
                        }
                        break;

                    case 5:
                        if (employeesInRepository.Count() == 0)
                        {
                            Console.WriteLine("-----------------------------");
                            Console.WriteLine("Employee repository is empty!");
                            Console.WriteLine("-----------------------------");
                        }
                        else
                        {
                            Console.WriteLine("---------------------------");
                            Console.WriteLine("Employee ID's in repository");
                            Console.WriteLine("---------------------------");
                            for (int i = 0; i < employeesInRepository.Count(); i++)
                            {
                                Console.WriteLine("ID: " + employeesInRepository[i].Id);
                                Console.WriteLine("------");
                            }
                            Console.Write("Input employee ID to delete same: ");
                            int employeeId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Are you sure you want to delete this employee?(Y/N): ");
                            string confirm = Console.ReadLine();
                            if (confirm == "Y" || confirm == "y")
                            {
                                employeeRepository.DeleteEmployee(employeeId);
                            }
                        }
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
