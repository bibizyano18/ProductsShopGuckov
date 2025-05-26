using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.View;

namespace ProductsShop.Presenter
{
    public class CartPresenter
    {
        private readonly ICartView view;
        private readonly ProductsAndCart model;
        private ProductPresenter productPresenter;
        public void SetPresenter(ProductPresenter _productPresenter)
        {
            productPresenter = _productPresenter;
        }
        public void ShowView()
        {
            ((Form)view).Show();
            view.DisplayProducts(model.GetCartProducts());
        }
        public CartPresenter(ICartView view, ProductsAndCart model)
        {
            this.view = view;
            this.model = model;

            this.view.UpdateCartCount += View_UpdateCartCount;
            this.view.DeleteProductRequested += View_DeleteProductRequested;
        }
        internal void AddProduct(Product product)
        {
            model.AddProduct(product);
            view.DisplayProducts(model.GetCartProducts());
        }

        private void View_DeleteProductRequested(object sender, EventArgs e)
        {
            if (sender != null)
            {
                int index = (int)sender;
                model.DeleteProduct(index);
                view.DisplayProducts(model.GetCartProducts());
                productPresenter.
            }
            
        }

        private void View_UpdateCartCount(object sender, EventArgs e)
        {
            Label labelCart = sender as Label;
            int count = model.UpdateCartCounter();
            labelCart.Text = $"Корзина: {count}";

            labelCart.ForeColor = count == 0 ? Color.Gray : Color.Black;
        }
    }
}
