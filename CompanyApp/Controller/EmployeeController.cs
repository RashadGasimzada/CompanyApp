﻿using Domain.Models;
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

        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Id: ");
            EnterId:
            string employeeId = Console.ReadLine();

            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee = _employeeServise.GetById(id);

                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{employee.Id} - {employee.Name} - {employee.Surname} works in {employee.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }
        }

        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Id: ");
            EnterId:
            string employeeId = Console.ReadLine();

            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee = _employeeServise.GetById(id);

                if (employee == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try id again");
                    goto EnterId;
                }
                else
                {
                    _employeeServise.Delete(employee);
                    Helper.WriteToConsole(ConsoleColor.Green, "Employee is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }

        }

        public void GetByAge()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Employee Age: ");
            EnterAge:
            string employeeAge = Console.ReadLine();
            int age;
            bool isTrueAge = int.TryParse(employeeAge, out age);

            if(isTrueAge)
            {
                var employeeAges = _employeeServise.GetByAge(age);

                foreach (var item in employeeAges)
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Surname} works in {item.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Employee not found, try age again");
                goto EnterAge;
            }
            
        }

        public void GetAllByCompanyId()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            string companyId = Console.ReadLine();
            int id;
            bool isTrueId = int.TryParse(companyId, out id);
            if(isTrueId)
            {
                var companysId = _employeeServise.GetAllByCompanyId(id);
                foreach (var item in companysId)
                {                    
                    Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Surname}");
                    
                }
            }
        }
    }
}
