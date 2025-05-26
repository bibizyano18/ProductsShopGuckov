using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model.Core
{
    public class ProductsAndCart
    {
        private List<Product> Products;
        private List<Product> CartProducts;
        
        public ProductsAndCart() {
            Products = new List<Product>(); 
            CartProducts = new List<Product>();
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public List<Product> GetCartProducts()
        {
            return CartProducts;
        }
        public void SetProducts(List<Product> products)
        {
            Products = products;
        }
        public void SetCartProducts(List<Product> products)
        {
            CartProducts = products;
        }
        public int UpdateCartCounter()
        {
            return CartProducts.Count;
        }
        

        public void AddProduct(Product product)
        {
            CartProducts.Add(product);
        }
        public void DeleteProduct(int id)
        {
            CartProducts.RemoveAt(id);
        }
    }
}
