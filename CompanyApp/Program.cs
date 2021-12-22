﻿using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyService companyService = new CompanyService();

            Helper.WriteToConsole(ConsoleColor.Blue, "Select options: ");

            while (true)
            {
                Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company, 4 - Get Company by Id, 5 - Get Companies by Name,\n6 - Get all Companies," +
                    "7 - Create Employee, 8 - Update Employee, 9 - Delete Employee, 10 - Get Employee by Id,\n11 - Get Employees by Age, 12 - Get all Employees by Company Id, 13 - Exit programm");

                EnterOption:
                string selectOption = Console.ReadLine();

                int option;

                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case 1:
                            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Name: ");
                            string companyName = Console.ReadLine();
                            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Address: ");
                            string address = Console.ReadLine();

                            Company company = new Company
                            {
                                Name = companyName,
                                Address = address,
                            };
                            var createResult = companyService.Create(company);

                            if (createResult != null)
                            {
                                Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id} - {company.Name} company created");
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "Something get wrong");
                                goto EnterOption;
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
                            EnterId:
                            string companyId = Console.ReadLine();

                            int id;

                            bool isIdTrue = int.TryParse(companyId, out id);

                            if (isIdTrue)
                            {
                                var idResult = companyService.GetById(id);

                                if (idResult == null)
                                {
                                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found, try id again");
                                    goto EnterId;
                                }
                                else
                                {
                                    Helper.WriteToConsole(ConsoleColor.Green, $"{idResult.Id} - {idResult.Name} - {idResult.Address}");
                                }
                            }
                            else
                            {
                                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                                goto EnterId;
                            }
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        case 9:
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
            
        }
    }
}
