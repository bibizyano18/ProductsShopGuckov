using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductsShop.Model.Core.Payment;

namespace ProductsShop.Model
{
    public class Payment
    {
        public decimal cardMoney => moneyBalance.cardMoney;
        public decimal cashMoney => moneyBalance.cashMoney;
        public decimal bonusMoney => moneyBalance.bonusMoney;
        public decimal totalPrice { get; set; }

        List<IPaymentMethods> payments = new List<IPaymentMethods> { };
        MoneyBalance moneyBalance = new MoneyBalance();

        public Payment() : this(1010, 345, 10, 0) {}
       
        public Payment(decimal cardMoney, decimal cashMoney, decimal bonusMoney, decimal totalPrice)
        {
            moneyBalance.cardMoney = cardMoney;
            moneyBalance.cashMoney = cashMoney;
            moneyBalance.bonusMoney = bonusMoney;
            this.totalPrice = totalPrice;
        }

        public bool MakePayment(List<bool> paymentMethods)
        {
            if (totalPrice <= 0) return false;
            if (paymentMethods == null || paymentMethods.Count != 3) return false;

            bool useCard = paymentMethods[0] && cardMoney > 0;
            bool useCash = paymentMethods[1] && cashMoney > 0;
            bool useBonus = paymentMethods[2] && bonusMoney > 0;

            // Считаем общий доступный баланс
            decimal totalAvailable = 0;
            if (useCard)
            {
                totalAvailable += cardMoney;
                payments.Add(new CardMethod(moneyBalance));
            }
            if (useCash)
            {
                totalAvailable += cashMoney;
                payments.Add(new CashMethod(moneyBalance));
            }
            if (useBonus)
            {
                totalAvailable += bonusMoney;
                payments.Add(new BonusMethod(moneyBalance));
            }

            // Если денег недостаточно
            if (totalAvailable < totalPrice) return false;

            decimal remaining = totalPrice;
            CombinedPayment combinedPayment = new CombinedPayment(payments);
            combinedPayment.Pay(ref remaining);
            return remaining == 0;
        }
    }
   
}
