using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.Presenter;
using ProductsShop.View;

namespace ProductsShop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view_main = new MainForm();
            var view_cart = new Cart();

            var model_product = new ProductsAndCart();
            var model_reader = new FileReader();
            var model_payment = new Payment();

            var product_presenter = new ProductPresenter(view_main, model_product, model_reader);
            var cart_presenter = new CartPresenter(view_cart, model_product);
            var payment_presenter = new PaymentPresenter(view_cart, model_payment);

            product_presenter.SetPresenter(cart_presenter);
            cart_presenter.SetPresenter(product_presenter);
            cart_presenter.SetPresenter(payment_presenter);
            payment_presenter.SetPresenter(cart_presenter);

            Application.Run(view_main);
        }
    }
}
