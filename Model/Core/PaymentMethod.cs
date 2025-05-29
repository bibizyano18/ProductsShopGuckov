using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model
{
    public class PaymentMethod
    {
        public decimal cardMoney { get; private set; }
        public decimal cashMoney { get; private set; }
        public decimal bonusMoney { get; private set; }
        public decimal totalPrice { get; set; }

        public PaymentMethod() 
        {
            this.cardMoney = 1050;
            this.cashMoney = 345;
            this.bonusMoney = 11;
        }
        public PaymentMethod(decimal cardMoney, decimal cashMoney, decimal bonusMoney, decimal totalPrice)
        {
            this.cardMoney = cardMoney;
            this.cashMoney = cashMoney;
            this.bonusMoney = bonusMoney;
            this.totalPrice = totalPrice;
        }

        public bool Payment(List<bool> paymentMethods)
        {
            if (totalPrice <= 0) return false;
            if (paymentMethods == null || paymentMethods.Count < 3) return false;

            bool useCard = paymentMethods[0] && cardMoney > 0;
            bool useCash = paymentMethods[1] && cashMoney > 0;
            bool useBonus = paymentMethods[2] && bonusMoney > 0;

            // Считаем общий доступный баланс
            decimal totalAvailable = 0;
            if (useCard) totalAvailable += cardMoney;
            if (useCash) totalAvailable += cashMoney;
            if (useBonus) totalAvailable += bonusMoney;

            // Если денег недостаточно
            if (totalAvailable < totalPrice) return false;

            decimal remaining = totalPrice;

            if (useBonus)
            {
                decimal min = Math.Min(bonusMoney, remaining);
                bonusMoney -= min;
                remaining -= min;
                if (remaining == 0) return true;
            }

            if (useCard)
            {
                decimal min = Math.Min(cardMoney, remaining);
                cardMoney -= min;
                remaining -= min;
                if (remaining == 0) return true;
            }

            if (useCash)
            {
                decimal min = Math.Min(cashMoney, remaining);
                cashMoney -= min;
                remaining -= min;

            }

            return remaining == 0;
        }
    }
}
