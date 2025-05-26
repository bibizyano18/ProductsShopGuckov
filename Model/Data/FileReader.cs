using System;
using System.Collections.Generic;
using System.IO;
using ProductsShop.Model;

namespace ProductsShop.Model.Data
{
    public class FileReader
    {
        public void SaveProductsToFile(string filePath, List<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Id}," +
                                   $"{product.Name}," +
                                   $"{product.Price}," +
                                   $"{product.IsWeighted}," +
                                   $"{product.Weight}");
                }
            }
        }

        public List<Product> ReadProductsFromFile(string filePath)
        {
            var products = new List<Product>();

            if (!File.Exists(filePath))
                return products;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    if (data.Length == 6)
                    {
                        products.Add(new Product(
                            id: int.Parse(data[0]),
                            name: data[1],
                            price: decimal.Parse(data[2]),
                            isWeighted: bool.Parse(data[3]),
                            weight: decimal.Parse(data[4])
                        ));
                    }
                }
            }
            return products;
        }
    }
}