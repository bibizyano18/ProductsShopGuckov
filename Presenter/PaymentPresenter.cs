using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsShop.Model.Core;
using ProductsShop.View;
using System.Windows.Forms;
using ProductsShop.Model;

namespace ProductsShop.Presenter
{
    public class PaymentPresenter
    {
        private readonly IPaymentView view;
        private readonly PaymentMethod model;
        private CartPresenter cartPresenter;
        public void SetPresenter(CartPresenter _cartPresenter)
        {
            cartPresenter = _cartPresenter;
        }
        public PaymentPresenter(IPaymentView view, PaymentMethod model)
        {
            this.view = view;
            this.model = model;

            this.view.MakePayment += View_MakePayment;
        }

        private void View_MakePayment(object sender, EventArgs e)
        {
            if (sender != null)
            {
                var arr = sender as List<bool>;
                bool payable = model.Payment(arr);
                if (payable)
                {
                    view.UpdateBalance(model.cardMoney, model.cashMoney, model.bonusMoney);
                    SetTotalPrice(0);
                    cartPresenter.SuccessfulPayment();
                    view.ShowMessage("Оплата прошла успешно, не забудьте свои покупки");
                }
                else
                {
                    view.ShowError("Недостаточно средств");
                }
            }
            
        }

        public void SetTotalPrice(decimal price)
        {
            model.TotalPriceInProccess = price;
        }

        public void UpdateBalance()
        {
            view.UpdateBalance(model.cardMoney, model.cashMoney, model.bonusMoney);
        }
    }
}
