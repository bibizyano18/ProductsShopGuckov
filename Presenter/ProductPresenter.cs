using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.View;

namespace ProductsShop.Presenter
{
    public class ProductPresenter
    {
        private readonly IProductView view;
        private readonly ProductsAndCart modelProduct;
        private readonly FileReader modelReader;


        public ProductPresenter(IProductView view, ProductsAndCart model_product, FileReader model_reader)
        {
            this.view = view;
            this.modelProduct = model_product;
            this.modelReader = model_reader;

            this.view.UpdateCartCount += View_UpdateCartCount;
            this.view.AddProductRequested += View_AddProductRequested; // подпись на событие добавления продукта
            //this.view.SaveDataInFile += View_SaveDataInFile;
            this.view.ReadDataFromFile += View_ReadDataFromFile;
            //this.view.DeleteProductRequested += View_DeleteProductRequested;
            this.view.DisplayProducts(modelProduct.GetProducts());
           
        }

        private void View_UpdateCartCount(object sender, EventArgs e)
        {
            Label labelCart = sender as Label;
            int count = modelProduct.UpdateCartCounter();
            labelCart.Text = $"Корзина: {count}";

            // Дополнительно можно менять цвет, если корзина пуста
            labelCart.ForeColor = count == 0 ? Color.Gray : Color.Black;
        }

        private void View_AddProductRequested(object sender, EventArgs e)
        {
            if (sender != null)
            {
                modelProduct.AddProduct(sender as Product);
            }
            
        }

        private void View_ReadDataFromFile(object sender, EventArgs e)
        {
            string filePath = sender as string;
            modelProduct.SetProducts(modelReader.ReadProductsFromFile(filePath));
            view.DisplayProducts(modelProduct.GetProducts());
            view.ShowMessage("Данные о продуктах успешно прочитаны.");
        }
    }
}
