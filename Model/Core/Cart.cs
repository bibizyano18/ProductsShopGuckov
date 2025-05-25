using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model.Core
{
    public class Cart
    {
        private List<Product> Products;
        private decimal Cost;
        public Cart() {
            Products = new List<Product>(); 
        }
        public List<Product> GetProducts()
        {
            return Products;
        }
        public void SetProducts(List<Product> products)
        {
            Products = products;
        }
        public decimal GetCost()
        {
            foreach (var item in Products) 
            {
                if (item.IsWeighted)
                {
                    Cost += item.Price * item.Weight;
                }
                else
                {
                    Cost += item.Price * item.Quantity;
                }
            }
            return Cost;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
        public void DeleteProduct(int id)
        {
            Products.RemoveAt(id);
        }
    }
}
