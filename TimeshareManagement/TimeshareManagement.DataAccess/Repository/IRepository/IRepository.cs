﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task Create(T entity);
        Task Update(T entity);
        Task DeleteById(int id);
    }
}
