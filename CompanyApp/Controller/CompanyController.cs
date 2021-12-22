﻿using Domain.Models;
using Repository.Data;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Controller
{
    public class CompanyController
    {
        private CompanyService _companyServise { get; }
        public CompanyController()
        {
            _companyServise = new CompanyService();
        }
        public void Create()
        {
            EnterOption:
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Name: ");
            string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Address: ");
            string address = Console.ReadLine();

            Company company = new Company
            {
                Name = companyName,
                Address = address,
            };
            var createResult = _companyServise.Create(company);

            if (createResult != null)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id} - {company.Name} company created");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Something get wrong");
                goto EnterOption;
            }
        }

        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            EnterId:
            string companyId = Console.ReadLine();

            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company = _companyServise.GetById(id);

                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found, try id again");
                    goto EnterId;
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"{company.Id} - {company.Name} - {company.Address}");
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
            Helper.WriteToConsole(ConsoleColor.Blue, "Add Company Id: ");
            EnterId:
            string companyId = Console.ReadLine();

            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var company = _companyServise.GetById(id);

                if (company == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found, try id again");
                    goto EnterId;
                }
                else
                {
                    _companyServise.Delete(company);
                    Helper.WriteToConsole(ConsoleColor.Green, "Company is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try id again");
                goto EnterId;
            }

        }

        public void GetAll()
        {
            var companies = _companyServise.GetAll();

            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"{item.Id} - {item.Name} - {item.Address}");
            }
        }
        public void GetByName()
        {

        }
    }
}
