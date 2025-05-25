using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model
{
    public class Product
    {
        public Product(int id, string name, decimal price, bool isWeighted, decimal weight, int quantity)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price; 
            this.IsWeighted = isWeighted;
            this.Weight = weight;
            this.Quantity = quantity;
            
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsWeighted { get; set; }
        public decimal Weight { get; set; }
        public int Quantity { get; set; }
    }
}
