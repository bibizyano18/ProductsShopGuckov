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
        private PaymentPresenter paymentPresenter;
        public void SetPresenter(ProductPresenter _productPresenter)
        {
            productPresenter = _productPresenter;
        }
        public void SetPresenter(PaymentPresenter _paymentPresenter)
        {
            paymentPresenter = _paymentPresenter;
        }
        public void ShowView()
        {
            ((Form)view).Show();
            view.DisplayProducts(model.GetCartProducts());
            paymentPresenter.UpdateBalance();
            paymentPresenter.SetTotalPrice(model.GetTotalPrice());
        }
        public void SuccessfulPayment()
        {
            model.SetCartProducts(new List<Product>(){ });
            view.DisplayProducts(model.GetCartProducts());
            view.UpdateCartCounter(0);
            productPresenter.UpdateLabelCartCount();
        }
        public CartPresenter(ICartView view, ProductsAndCart model)
        {
            this.view = view;
            this.model = model;

            this.view.DeleteProductRequested += View_DeleteProductRequested;
        }
        internal void AddProduct(Product product)
        {
            model.AddProduct(product);
            view.DisplayProducts(model.GetCartProducts());
            view.UpdateCartCounter(model.UpdateCartCounter());
            paymentPresenter.SetTotalPrice(model.GetTotalPrice());
        }

        private void View_DeleteProductRequested(object sender, EventArgs e)
        {
            if (sender != null)
            {
                int index = (int)sender;
                model.DeleteProduct(index);
                view.DisplayProducts(model.GetCartProducts());
                view.UpdateCartCounter(model.UpdateCartCounter());
                paymentPresenter.SetTotalPrice(model.GetTotalPrice());
                productPresenter.UpdateLabelCartCount();
            }
            
        }
    }
}
