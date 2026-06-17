using _15_ServiceLayer_Practice_Product.Models;
using _15_ServiceLayer_Practice_Product.Services;
using Microsoft.AspNetCore.Mvc;

namespace _15_ServiceLayer_Practice_Product.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }
        
        public IActionResult InsertData()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult InsertData(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            _productService.AddData(product);
            return RedirectToAction("ShowData");
        }
        public IActionResult ShowData(string searchText)
        {
            var products = _productService.ListProducts(searchText);
            return View(products);
        }

        public IActionResult UpdateData(int id)
        {
            var product= _productService.GetId(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateData(Product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }

            _productService.UpdateData(product);
            return RedirectToAction("ShowData");
        }

        public IActionResult DeleteData(int id)
        {
            var product = _productService.GetId(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult DeleteData(Product product)
        {
            _productService.DeleteData(product);
            return RedirectToAction("ShowData");
        }
    }
}
