using PensionsConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionsConsoleApp
{
   public class Program
    {
        static void Main(string[] args)
        {
            GetEmployeeseViaAnORM();
            Console.WriteLine("BEFORE PENSION UPDATE");
            GetPensionsViaAnORM();
            AddFivePercentOfSalaryToPensions();
            Console.WriteLine("AFTER PENSION UPDATE");
            GetPensionsViaAnORM();
            Console.ReadLine();
        }

        private static void GetEmployeeseViaAnORM()
        {
            var ormAccess = new ORMAccess();
            Console.WriteLine();
            Console.WriteLine("Employees");
            Console.WriteLine("---------");

            foreach (Employee employee in ormAccess.GetAllEmployees())
            {
                Console.WriteLine($"{employee.Id}: {employee.FirstName} {employee.LastName}, {employee.Age}");
            }
        }

        private static void GetPensionsViaAnORM()
        {
            var ormAccess = new ORMAccess();
            Console.WriteLine();
            Console.WriteLine("Details");
            Console.WriteLine("---------");

            foreach (PensionFund pension in ormAccess.GetAllPensions())
            {
                var employee = pension.Employee;
                Console.WriteLine($"{employee.FirstName} {employee.LastName}: Fund: {pension.AmountContributed}, Salary: {employee.Salary}");
            }
        }

        private static void AddFivePercentOfSalaryToPensions()
        {
            var ormAccess = new ORMAccess();

            foreach (PensionFund pension in ormAccess.GetAllPensions())
            {
                var salary = pension.Employee.Salary;
                pension.AmountContributed += (int)(salary * 0.05);
                ormAccess.UpdatePension(pension);
            }
        }
    }
}
