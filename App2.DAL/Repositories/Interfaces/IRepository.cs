using App2.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<int> SaveChangeAsync();
    }
}
