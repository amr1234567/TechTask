using AspNetCoreHero.ToastNotification.Abstractions;
using Domain.Abstractions;
using Domain.Dtos.Input;
using Domain.Dtos.Output;
using Domain.Helpers;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.Models;

namespace UI.Controllers
{
    public class ProductsController(IProductRepository _repository, IServiceProviderRepository providerRepository, INotyfService _notyf) : Controller
    {
        // GET: ProductsController
        public async Task<ActionResult> Products()
        {
            var products = await _repository.GetProducts(new());
            if (products.IsFailed)
            {
                _notyf.Error(products.GetErrorsMessage());
                return View(new AllProductsModelView([], []));
            }
            var providers = await providerRepository.GetServiceProviders();
            if (providers.IsFailed)
            {
                _notyf.Error(providers.GetErrorsMessage());
                return View(new AllProductsModelView([], []));
            }
            return View(new AllProductsModelView(products.Value, providers.Value));
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> FilterProducts(GetProductsParams input)
        {
            var products = await _repository.GetProducts(input);
            if (products.IsFailed)
            {
                _notyf.Error(products.GetErrorsMessage());
                return PartialView("_ProductsList", Enumerable.Empty<ProductDto>());
            }
            return PartialView("_ProductsList", products.Value);
        }

        // GET: ProductsController/Create
        public async Task<ActionResult> Create()
        {
            var providers = await providerRepository.GetServiceProviders();
            if (providers.IsFailed)
            {
                _notyf.Error(providers.GetErrorsMessage());
                return View(new CreateProductViewModel(new(), Enumerable.Empty<ServiceProviderDto>()));
            }
            return View(new CreateProductViewModel(new ProductModelCreateInput(), providers.Value));
        }

        // POST: ProductsController/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductModelCreateInput model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _notyf.Error("Please fill all the required fields.");
                    return Json(new { Success = false });
                }
                var result = await _repository.CreateProduct(model);
                if (result.IsSuccess)
                {
                    _notyf.Success("Product created successfully.");
                    return Json(new { Success = true });
                }
                _notyf.Error(result.GetErrorsMessage());
                return Json(new { Success = false });
            }
            catch(Exception ex)
            {
                _notyf.Error(ex.Message);
                return Json(new { Success = false });
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
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

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
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
