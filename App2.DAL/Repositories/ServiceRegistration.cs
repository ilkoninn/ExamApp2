using App2.DAL.Repositories.Abstractions;
using App2.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.DAL.Repositories
{
    public static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
