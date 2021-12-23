using Domain.Models;
using Repository.Exceptions;
using Repository.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _employeeRepository { get; }
        private CompanyRepository _companyRepository { get; }
        private int count { get; set; }

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }

        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.GetById(m => m.Id == companyId);
                if (company == null) return null;
                model.Id = count;
                count++;
                model.Company = company;
                _employeeRepository.Create(model);

                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Delete(Employee employee)
        {
            _employeeRepository.Delete(employee);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.GetById(m => m.Id == id);
        }
    }
}
