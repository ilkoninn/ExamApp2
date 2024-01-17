using App2.Core.Entities;
using App2.DAL.Context;
using App2.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DAL.Repositories.Abstractions
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context) { }
    }
}
