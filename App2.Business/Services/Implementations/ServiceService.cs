using App2.Business.Exceptions.Common;
using App2.Business.Services.Interfaces;
using App2.Business.ViewModels.ServiceVMs;
using App2.Core.Entities;
using App2.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Business.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _repository;

        public ServiceService(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<Service>> GetAllAsync()
        {
            IQueryable<Service> query = await _repository.GetAllAsync();

            return query;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            if(id <= 0) throw new IdNullOrZeroException("Id must be over than and not equal to zero!", nameof(id));
            var service = await _repository.GetByIdAsync(id);
            if(service is null) throw new ObjectNotFoundException("Object not found!", nameof(service));


            return service;
        }

        public async Task CreateAsync(CreateServiceVM vm, string web)
        {
            if(vm.IconUrl is null || vm.Title is null || vm.Description is null)
            {
                throw new ObjectNullException("Parameters is required!", nameof(vm));
            }

            Service newService = new()
            {
                Title = vm.Title,
                Description = vm.Description,
                IconUrl = vm.IconUrl,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            await _repository.CreateAsync(newService);
            await _repository.SaveChangeAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id <= 0) throw new IdNullOrZeroException("Id must be over than and not equal to zero!", nameof(id));
            var service = await _repository.GetByIdAsync(id);
            if (service is null) throw new ObjectNotFoundException("Object not found!", nameof(service));

            await _repository.DeleteAsync(id);
            await _repository.SaveChangeAsync();
        }

        public async Task UpdateAsync(UpdateServiceVM vm, string web)
        {
            if (vm.Id <= 0) throw new IdNullOrZeroException("Id must be over than and not equal to zero!", nameof(vm.Id));
            Service oldService = await _repository.GetByIdAsync(vm.Id);
            if (oldService is null) throw new ObjectNotFoundException("Object not found!", nameof(oldService));

            if (vm.IconUrl is null || vm.Title is null || vm.Description is null)
            {
                throw new ObjectNullException("Parameters is required!", nameof(vm));
            }


            oldService.Title = vm.Title;
            oldService.Description = vm.Description;
            oldService.IconUrl = vm.IconUrl;
            oldService.UpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(oldService);
            await _repository.SaveChangeAsync();
        }
    }
}
