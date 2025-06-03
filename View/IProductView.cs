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
        void UpdateCartCounter(int count);
        
        event EventHandler AddProductRequested;
        event EventHandler ReadDataFromFile;
        event EventHandler ShowCartForm;
        void ShowMessage(string message);
        void ShowError(string message);
        
    }
}
