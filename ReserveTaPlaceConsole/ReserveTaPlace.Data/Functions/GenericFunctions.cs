﻿using Microsoft.EntityFrameworkCore;
using ReserveTaPlace.Data.ApplicationContext;
using ReserveTaPlace.Data.Interfaces;
using ReserveTaPlace.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReserveTaPlace.Data.Functions
{
    public class GenericFunctions<T> : IGenericRepo<T> where T : class, new()
    {
        private DbContext _context;
        public GenericFunctions(DbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result == 1;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return  await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
