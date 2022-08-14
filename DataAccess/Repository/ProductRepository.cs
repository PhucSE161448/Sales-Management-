using BusinessObject.Models;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteProduct(Product pro)
        => ProductDAO.DeleteProduct(pro);

        public List<Category> GetCategories()
        => ProductDAO.GetCategories();

        public List<Product> GetProducts()
        => ProductDAO.GetProducts();

        public void SaveProduct(Product p)
        => ProductDAO.SaveProduct(p);

        public void UpdateProduct(Product pro)
        => ProductDAO.UpdateProduct(pro);

        public Product GetProductID(int id)
        => ProductDAO.GetProductID(id);

        public List<Product> GetProductsName(string name)
        => ProductDAO.GetProductsName(name);

        public List<Product> GetUnitPrice(decimal UnitPrice)
        => ProductDAO.GetUnitPrice(UnitPrice);

        public List<Product> GetUnitStock(int UnitStock)
        => ProductDAO.GetUnitStock(UnitStock);
    }
}
