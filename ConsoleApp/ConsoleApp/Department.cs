using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class Department
    {
        public int Id { get; set; }
        public String Name { get; set; }

        public void printDepartmentInfo()
        {
            Console.WriteLine("ID: "+Id+" , Name: "+Name);
        }
    }
}
