﻿using Domain.Common;
using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public bool Create(Employee entity)
        {
            try
            {
                if (entity == null)
                    throw new CustomException("Entity is null");

                AppDbContext<Employee>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                AppDbContext<Employee>.datas.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Employee> GetAll(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Predicate<Employee> filter)
        {
            return filter == null ? AppDbContext<Employee>.datas[0] : AppDbContext<Employee>.datas.Find(filter);
        }

        public List<Employee> GetByName(Predicate<Employee> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
