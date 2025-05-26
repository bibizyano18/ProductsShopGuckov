using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsShop.Model;

namespace ProductsShop.View
{
    public interface IProductView
    {
        void DisplayProducts(List<Product> products);
        
        event EventHandler AddProductRequested;
        event EventHandler DeleteProductRequested;
        event EventHandler UpdateCartCount;
        event EventHandler SaveDataInFile;
        event EventHandler ReadDataFromFile;
        void ShowMessage(string message);
        void ShowError(string message);
        
    }
}
