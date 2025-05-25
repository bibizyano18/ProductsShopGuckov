using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.View;

namespace ProductsShop.Presenter
{
    public class ProductPresenter
    {
        private readonly IProductView view;
        private readonly Cart modelProduct;
        private readonly FileReader modelReader;


        public ProductPresenter(IProductView view, Cart model_product, FileReader model_reader)
        {
            this.view = view;
            this.modelProduct = model_product;
            this.modelReader = model_reader;

            this.view.AddProductRequested += View_AddProductRequested; // подпись на событие добавления продукта
            //this.view.SaveDataInFile += View_SaveDataInFile;
            this.view.ReadDataFromFile += View_ReadDataFromFile;
            //this.view.DeleteProductRequested += View_DeleteProductRequested;
            this.view.DisplayProducts(modelProduct.GetProducts());
           
        }

        private void View_AddProductRequested(object sender, EventArgs e)
        {
            if (sender != null)
            {
                int index = (int)sender;
                view.ShowMessage(index.ToString());
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
