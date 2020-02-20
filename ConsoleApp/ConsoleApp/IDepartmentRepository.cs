using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public interface IDepartmentRepository
    {
        Department GetDepartment(int id);
        List<Department> GetDepartments();

    }
}
