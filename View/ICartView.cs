using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsShop.Model;

namespace ProductsShop.View
{
    public interface ICartView
    {
        void DisplayProducts(List<Product> products);
        void UpdateCartCounter(int count);

        event EventHandler DeleteProductRequested;
        void ShowMessage(string message);
        void ShowError(string message);

    }
}
