using App2.Business.Exceptions.Account;
using App2.Business.Exceptions.Common;
using App2.Business.Services.Interfaces;
using App2.Business.ViewModels.AccountVMs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace App2.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> CreateRoles()
        {
            await _service.CreateRoles();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _service.Logout();

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    await _service.Register(vm);

                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (UsedEmailException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
            catch (UserRegistrationException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm, string? returnUrl)
        {
            try
            {
                if (!User.Identity.IsAuthenticated)
                {
                    await _service.Login(vm);

                    if (returnUrl is not null)
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (UserNotFoundException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
            catch (ObjectNullException ex)
            {
                ModelState.AddModelError(ex.ParamName, ex.Message);

                return View(vm);
            }
        }
    }
}
