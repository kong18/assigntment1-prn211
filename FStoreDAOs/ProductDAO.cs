using FStoreBOs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FStoreDAOs
{
    public class ProductDAO
    {
        private readonly FStoreDBContext _dbContext;
        private static ProductDAO instance = null;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }
                return instance;
            }
        }
        public Product GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
        }
        public List<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }
        public ProductDAO()
        {
            _dbContext = new FStoreDBContext();
        }

        
        public void DeleteProduct(int id)
        {
            var existedProduct = _dbContext.Products.FirstOrDefault(x => x.ProductId == id);
            if (existedProduct != null)
            {
                _dbContext.Products.Remove(existedProduct);
                _dbContext.SaveChanges();
            }
        }
        public void CreateProduct(Product product)
        {
            if(product == null)
            {
                _dbContext.Add(product);
                _dbContext.SaveChanges();
            }
        }


        public void UpdateProduct(int id,Product Product)
        {
            Product product = GetProductById(id);
            if(product != null) {
                product.ProductName = Product.ProductName;
                product.UnitPrice = Product.UnitPrice;
                product.UnitsInStock = Product.UnitsInStock;
                product.Weight = Product.Weight;    
                product.CategoryId = Product.CategoryId;    
            }
        }
        
    }
}
