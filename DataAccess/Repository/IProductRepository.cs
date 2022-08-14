using BusinessObject.Models;
using System.Collections.Generic;
namespace DataAccess.Repository

{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        List<Category> GetCategories();
        void SaveProduct(Product p);
        void UpdateProduct(Product pro);
        void DeleteProduct(Product pro);
        Product GetProductID(int id);
        List<Product> GetProductsName(string name);
        List<Product> GetUnitPrice(decimal UnitPrice);
        List<Product> GetUnitStock(int UnitStock);
    }
}
