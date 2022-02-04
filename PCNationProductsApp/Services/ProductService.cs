using PCNationProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PCNationProductsApp.Services
{
    public class ProductService: IProductService
    {
        private readonly Context _dbContext;
        private static List<Stocks> _stocks;
        public ProductService(Context dbContext)
        {
            _dbContext = dbContext;
            _stocks = dbContext.Stocks.ToList();
        }

        public ParentViewModel GetProducts(int currentPage)
        {
            int maxRows = 30;
            ParentViewModel viewModel = new ParentViewModel();

            var _emplst = (from c in _dbContext.Categories
                           join p in _dbContext.Products on c.CategoryId equals p.CategoryId
                           join b in _dbContext.Brands on p.BrandId equals b.BrandId
                           select new ProductViewModel
                           {
                               ProductId = p.ProductId,
                               BrandName = b.BrandName,
                               ProductName = p.ProductName,
                               CategoryName = c.CategoryName,
                               ModelYear = p.ModelYear,
                               ListPrice = p.ListPrice,
                               Quantity = getQuanity(p.ProductId)
                           })
                           .OrderBy(p => p.ProductId)
                           .Skip((currentPage - 1) * maxRows)
                           .Take(maxRows)
                           .ToList();

            viewModel.Products = _emplst;

            double pageCount = (double)(_dbContext.Products.Count() / Convert.ToDecimal(maxRows));
            viewModel.PageCount = (int)Math.Ceiling(pageCount);

            viewModel.CurrentPageIndex = currentPage;
            return viewModel;
        }

        public Products GetSelectedProduct(int id)
        {
            return _dbContext.Products.FirstOrDefault(s => s.ProductId == id);
        }

        public void UpdateProduct(Products updateProduct)
        {
            _dbContext.Products.Update(updateProduct);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var deleteProduct = _dbContext.Products.Single(a => a.ProductId == id);
            _dbContext.Products.Remove(deleteProduct);
            _dbContext.SaveChanges();
        }

        private static int getQuanity(int product_id)
        {
            var data = _stocks.Where(a => a.ProductId == product_id);
            var total = data.Sum(d => d.Quantity);
            return total;
        }
    }
}
