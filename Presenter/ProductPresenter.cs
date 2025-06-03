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
        private CartPresenter cartPresenter;
        public void SetPresenter(CartPresenter _cartPresenter)
        {
            cartPresenter = _cartPresenter;
        }
        public ProductPresenter(IProductView view, ProductsAndCart model_product, FileReader model_reader)
        {
            this.view = view;
            this.modelProduct = model_product;
            this.modelReader = model_reader;

            this.view.ShowCartForm += View_ShowCartForm;
            this.view.AddProductRequested += View_AddProductRequested; // подпись на событие добавления продукта
            this.view.ReadDataFromFile += View_ReadDataFromFile;
            this.view.DisplayProducts(modelProduct.GetProducts());
           
        }
        internal void UpdateLabelCartCount()
        {
            view.UpdateCartCounter(modelProduct.UpdateCartCounter());
        }
        private void View_ShowCartForm(object sender, EventArgs e)
        {
            cartPresenter.ShowView();
        }

        private void View_AddProductRequested(object sender, EventArgs e)
        {
            if (sender != null)
            {
                cartPresenter.AddProduct(sender as Product);
                view.UpdateCartCounter(modelProduct.UpdateCartCounter());
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
