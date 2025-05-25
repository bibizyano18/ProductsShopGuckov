using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.Presenter;

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
            var view = new MainForm();
            var model_product = new Cart();
            var model_reader = new FileReader();
            var presenter = new ProductPresenter(view, model_product, model_reader);
            Application.Run(view);
        }
    }
}
