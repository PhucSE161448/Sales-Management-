using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProduct = new List<Product>();
            try
            {
                using (var db = new FStoreDBContext())
                {
                    Product product = new Product();

                    listProduct = db.Products.ToList();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return listProduct;
        }

        public static List<Category> GetCategories()
        {
            var categoryList = new List<Category>();
            try
            {
                using (var db = new FStoreDBContext())
                {
                    categoryList = db.Categories.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categoryList;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var Context = new FStoreDBContext())
                {
                    Context.Products.Add(p);
                    Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void UpdateProduct(Product pro)
        {
            try
            {
                using (var Context = new FStoreDBContext())
                {
                    Context.Entry<Product>(pro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteProduct(Product pro)
        {
            try
            {
                using (var Context = new FStoreDBContext())
                {
                    var p1 = Context.Products.SingleOrDefault(c => c.ProductId == pro.ProductId);
                    Context.Products.Remove(p1);
                    Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static Product GetProductID(int id)
        {
            using (var db = new FStoreDBContext())
            {
                Product query = db.Products.Where(p => p.ProductId == id).FirstOrDefault<Product>();
                return query;
            }
        }

        public static List<Product> GetProductsName(string name)
        {
            using (var db = new FStoreDBContext())
            {
                List<Product> plist = new List<Product>();
                plist = db.Products.ToList();
                return plist.FindAll(Product => Product.ProductName.Contains(name, StringComparison.CurrentCultureIgnoreCase));
            }
        }

        public static List<Product> GetUnitPrice(decimal UnitPrice)
        {
            using (var db = new FStoreDBContext())
            {
                List<Product> UPList = new List<Product>();
                UPList = db.Products.ToList();
                return UPList.FindAll(Product => Product.UnitPrice <= UnitPrice);
            }
        }

        public static List<Product> GetUnitStock(int UnitStock)
        {
            using (var db = new FStoreDBContext())
            {
                List<Product> USList = new List<Product>();
                USList = db.Products.ToList();
                return USList.FindAll(Product => Product.UnitsInStock <= UnitStock);
            }
        }
    }
}
