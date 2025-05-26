using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.View
{
    public interface IPaymentView
    {
        void UpdateBalance(decimal cardMoney, decimal cashMoney, decimal bonusMoney);
        void ShowMessage(string message);
        void ShowError(string message);

        event EventHandler MakePayment;
    }
}
