using App2.Core.Entities.Common;
using App2.DAL.Context;
using App2.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DAL.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();  
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            IQueryable<T> query = _table;

            return query;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().Where(x => !x.IsDeleted).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _table.AddAsync(entity);

            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id); 
            entity.IsDeleted = true;

            await UpdateAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);

            return entity;
        }

        public async Task<int> SaveChangeAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
