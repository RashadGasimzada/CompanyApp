using CompanyApp.Controller;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApp
{
    class Program
    {        
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();

            Helper.WriteToConsole(ConsoleColor.Blue, "Select options: ");

            while (true)
            {
                EnterOption:
                ShowMenus();

                string selectOption = Console.ReadLine();

                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int)MyEnums.Menus.CreateCompany:
                            companyController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateCompany:
                            companyController.Update();
                            break;
                        case (int)MyEnums.Menus.DeleteCompany:
                            companyController.Delete();
                            break;
                        case (int)MyEnums.Menus.GetCompanyById:
                            companyController.GetById();
                            break;
                        case (int)MyEnums.Menus.GetCompaniesByName:
                            companyController.GetByName();
                            break;
                        case (int)MyEnums.Menus.GetAllCompanies:
                            companyController.GetAll();
                            break;
                        case (int)MyEnums.Menus.CreateEmployee:
                            employeeController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateEmployee:
                            break;
                        case (int)MyEnums.Menus.DeleteEmployee:
                            employeeController.Delete();
                            break;
                        case (int)MyEnums.Menus.GetEmployeeById:
                            employeeController.GetById();
                            break;
                        case (int)MyEnums.Menus.GetEmployeesByAge:
                            break;
                        case (int)MyEnums.Menus.GetAllEmployeesByCompanyId:
                            break;
                        case (int)MyEnums.Menus.ExitProgramm:
                            break;
                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
            
        }
        private static void ShowMenus()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company, 4 - Get Company by Id, 5 - Get Companies by Name,\n6 - Get all Companies," +
                "7 - Create Employee, 8 - Update Employee, 9 - Delete Employee, 10 - Get Employee by Id,\n11 - Get Employees by Age, 12 - Get all Employees by Company Id, 13 - Exit programm");
        }
    }
}
