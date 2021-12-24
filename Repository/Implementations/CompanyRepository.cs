﻿using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company entity)
        {
            try
            {
                if (entity == null)
                    throw new CustomException("Entity is null");

                AppDbContext<Company>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            try
            {
                AppDbContext<Company>.datas.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Company GetById(Predicate<Company> filter = null)
        {
            return filter == null ? AppDbContext<Company>.datas[0] : AppDbContext<Company>.datas.Find(filter);
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            return filter == null ? AppDbContext<Company>.datas : AppDbContext<Company>.datas.FindAll(filter);
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException;
           
        }
    }
}
