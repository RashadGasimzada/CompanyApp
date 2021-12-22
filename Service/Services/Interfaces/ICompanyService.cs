using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Interfaces
{
    public interface ICompanyService
    {
        Company Create(Company model);
        Company Update(int id, Company model);
        void Delete(Company model);
        Company GetById(Predicate<Company> filter);
        Company GetByName(Predicate<Company> filter);
        List<Company> GetAll(Predicate<Company> filter);
    }
}
