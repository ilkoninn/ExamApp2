using App2.Core.Entities;
using App2.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App2.MVC.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceRepository _rep;

        public ServiceViewComponent(IServiceRepository rep)
        {
            _rep = rep;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IQueryable<Service> services = await _rep.GetAllAsync();

            return View(services);
        }
    }
}
