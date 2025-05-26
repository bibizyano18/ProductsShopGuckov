using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductsShop.Model.Core;
using ProductsShop.Model.Data;
using ProductsShop.View;

namespace ProductsShop.Presenter
{
    public class CartPresenter
    {
        private readonly ICartView view;
        private readonly ProductsAndCart model;
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
            this.view.ReadDataFromFile += View_ReadDataFromFile;
            this.view.DeleteProductRequested += View_DeleteProductRequested;
            this.view.SaveDataInFile += View_SaveDataInFile;
        }

        private void View_SaveDataInFile(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_DeleteProductRequested(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_ReadDataFromFile(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void View_UpdateCartCount(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
