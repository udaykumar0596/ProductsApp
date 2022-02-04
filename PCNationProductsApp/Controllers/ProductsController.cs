using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PCNationProductsApp.Models;
using PCNationProductsApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PCNationProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View(_productService.GetProducts(1));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editProduct = _productService.GetSelectedProduct(id);
            return View(editProduct);
        }

        [HttpPost]
        public IActionResult Edit(Products updateProduct)
        {
            _productService.UpdateProduct(updateProduct);
            return RedirectToAction(nameof(Index));
        }       

        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Index(int currentPageIndex)
        {
            return View(_productService.GetProducts(currentPageIndex));
        }       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
