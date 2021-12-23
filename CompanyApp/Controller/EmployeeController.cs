using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Controller
{
    public class EmployeeController
    {
        private EmployeeService _employeeServise { get; }

        public EmployeeController()
        {
            _employeeServise = new EmployeeService();
        }

        public void Create()
        {
            EnterOption:
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Name: ");
            string employeeName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Surname: ");
            string employeeSurname = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Age: ");
            string Age = Console.ReadLine();
            int employeeAge;
            bool isTrueAge = int.TryParse(Age, out employeeAge);
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            string Id = Console.ReadLine();
            int companyId;
            bool isTrueId = int.TryParse(Id, out companyId);
            if (isTrueAge && isTrueId) {
                Employee employee = new Employee
                {
                    Name = employeeName,
                    Surname = employeeSurname,
                    Age = employeeAge,
    
                };
                var createResult = _employeeServise.Create(employee,companyId);

                if (createResult != null)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Surname} employee in {employee.Company.Name} created");
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                    goto EnterOption;
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again");
                goto EnterOption;
            }
        }
    }
}
