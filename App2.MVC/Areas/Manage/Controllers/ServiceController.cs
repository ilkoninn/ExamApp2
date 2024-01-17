using App2.Business.Exceptions.Common;
using App2.Business.Services.Interfaces;
using App2.Business.ViewModels.ServiceVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App2.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _service;
        private readonly IWebHostEnvironment _env;

        public ServiceController(IServiceService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }

        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Moderator")]
        public async Task<IActionResult> Table()
        {
            if (User.IsInRole("Moderator"))
            {
               return View((await _service.GetAllAsync()).Where(x => !x.IsDeleted));
            }
            else
            {
                return View(await _service.GetAllAsync());
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteAsync(id);

                return RedirectToAction(nameof(Table));
            }
            catch (IdNullOrZeroException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                return View(await _service.GetByIdAsync(id));
            }
            catch (IdNullOrZeroException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceVM vm)
        {
            try
            {
                await _service.CreateAsync(vm, _env.WebRootPath);

                return RedirectToAction(nameof(Table));
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var oldService = await _service.GetByIdAsync(id);

                UpdateServiceVM newVm = new()
                {
                    Title = oldService.Title,
                    Description = oldService.Description,
                    IconUrl = oldService.IconUrl,
                };

                return View(newVm);
            }
            catch (IdNullOrZeroException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceVM vm)
        {
            try
            {
                await _service.UpdateAsync(vm, _env.WebRootPath);

                return RedirectToAction(nameof(Table));
            }
            catch (IdNullOrZeroException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNotFoundException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View();
            }
        }
    }
}
