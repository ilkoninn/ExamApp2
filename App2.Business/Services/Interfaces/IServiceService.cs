using App2.Business.ViewModels.ServiceVMs;
using App2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Business.Services.Interfaces
{
    public interface IServiceService
    {
        Task<IQueryable<Service>> GetAllAsync();
        Task<Service> GetByIdAsync(int id);
        Task CreateAsync(CreateServiceVM vm, string web);
        Task UpdateAsync(UpdateServiceVM vm, string web);
        Task DeleteAsync(int id);
    }
}
