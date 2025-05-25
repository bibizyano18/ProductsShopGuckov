using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model.Core
{
    public class Cart
    {
        private List<Product> products;
        public Cart() { 
            products = new List<Product>(); 
        }
        public Cart(List<Product> Products)
        {
            products = Products;
        }
        public List<Product> GetProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        public void DeleteProduct(int id)
        {
            products.RemoveAt(id);
        }
    }
}
