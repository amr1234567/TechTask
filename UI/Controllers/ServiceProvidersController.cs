using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Abstractions;
using Domain.Dtos.Input;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Domain.Dtos.Output;
using Domain.Helpers;

namespace UI.Controllers
{
    public class ServiceProvidersController(IServiceProviderRepository _repository, INotyfService _notyf) : Controller
    {
        // GET: ServiceProvidersController1
        public async Task<ActionResult> Providers()
        {
            var services = await _repository.GetServiceProviders();
            if(services.IsSuccess)
                return View(services.Value);
            _notyf.Error(services.GetErrorsMessage());
            return View(Enumerable.Empty<ServiceProviderDto>());
        }

        // GET: ServiceProvidersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceProvidersController1/Create
        public ActionResult Create()
        {
            return View(new ServiceProviderModelCreateInput());
        }

        // POST: ServiceProvidersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ServiceProviderModelCreateInput model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _notyf.Error("please enter a valid input");
                    return Json(new { Success = false });
                }
                var result = await _repository.CreateServiceProvider(model);
                if (result.IsFailed)
                {
                    _notyf.Error(result.GetErrorsMessage());
                    return Json(new { Success = false });
                }
                return Json(new { Success = true });
            }
            catch(Exception ex)
            {
                _notyf.Error(ex.Message);
                return Json(new { Success = false });
            }
        }

        // GET: ServiceProvidersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ServiceProvidersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceProvidersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceProvidersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
