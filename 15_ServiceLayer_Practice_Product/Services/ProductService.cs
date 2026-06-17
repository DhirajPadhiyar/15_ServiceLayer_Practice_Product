using _15_ServiceLayer_Practice_Product.Data;
using _15_ServiceLayer_Practice_Product.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Tokens;

namespace _15_ServiceLayer_Practice_Product.Services
{

    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        } 

        public List<Product> ListProducts(string searchText)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchText))
            {
                products = products.Where(p => p.Name.ToUpper().Contains(searchText.ToUpper()));
            }

            var productList = products.ToList();

            return productList;
        }

        public void AddData(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product? GetId(int id)
        {
            return _context.Products.Find(id);
        }
        public void UpdateData(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteData(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
