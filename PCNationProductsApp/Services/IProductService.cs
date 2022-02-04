using PCNationProductsApp.Models;

namespace PCNationProductsApp.Services
{
    public interface IProductService
    {
        public ParentViewModel GetProducts(int currentPage);
        public Products GetSelectedProduct(int id);
        public void UpdateProduct(Products updateProduct);
        public void DeleteProduct(int id);
    }
}
