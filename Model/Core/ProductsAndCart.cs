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
        public void SetCartProducts(List<Product> products)
        {
            CartProducts = products;
        }
        public void SetProducts(List<Product> products)
        {
            Products = products;
        }
        public int UpdateCartCounter()
        {
            return CartProducts.Count;
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0;
            foreach (var item in CartProducts)
            {
                if (item.IsWeighted)
                {
                    total += item.Price * item.Weight;
                }
                else
                {
                    total += item.Price;
                }
            }
            return total;
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
