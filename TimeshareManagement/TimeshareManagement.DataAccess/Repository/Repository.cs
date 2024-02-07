﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeshareManagement.DataAccess.Data;
using TimeshareManagement.DataAccess.Repository.IRepository;
using TimeshareManagement.Models.Models.DTO;

namespace TimeshareManagement.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        private ResponseDTO _response;
        private readonly DbSet<T> _dbSet;
        private readonly IMapper _mapper;

        public Repository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _dbSet = db.Set<T>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> GetByName(string name)
        {
            return await _dbSet.FindAsync(name);
        }

        public async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
             _dbSet.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            await _db.SaveChangesAsync();
        }
        public async Task<T> GetUserById(string id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
