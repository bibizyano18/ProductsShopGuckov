using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model.Core.Payment
{
    public interface IPaymentMethods
    {
        decimal Pay(decimal remaining);
    }
    public class MoneyBalance
    {
        public decimal cardMoney { get; internal set; }
        public decimal cashMoney { get; internal set; }
        public decimal bonusMoney { get; internal set; }
    }
    public class CashMethod : IPaymentMethods
    {
        public MoneyBalance balance;
        public CashMethod(MoneyBalance moneyBalance)
        {
            balance = moneyBalance;
        }
        public decimal Pay(decimal remaining)
        {
            decimal min = Math.Min(balance.cashMoney, remaining);
            balance.cashMoney -= min;
            remaining -= min;
            return remaining;
        }
    }
    public class CardMethod : IPaymentMethods
    {
        public MoneyBalance balance;
        public CardMethod(MoneyBalance moneyBalance)
        {
            balance = moneyBalance;
        }

        public decimal Pay(decimal remaining)
        {
            decimal min = Math.Min(balance.cardMoney, remaining);
            balance.cardMoney -= min;
            remaining -= min;
            return remaining;
        }
    }
    public class BonusMethod : IPaymentMethods
    {
        public MoneyBalance balance;
        public BonusMethod(MoneyBalance moneyBalance)
        {
            balance = moneyBalance;
        }
        public decimal Pay(decimal remaining)
        {
            decimal min = Math.Min(balance.bonusMoney, remaining);
            balance.bonusMoney -= min;
            remaining -= min;
            return remaining;
        }
    }
    public class CombinedPayment
    {
        List<IPaymentMethods> paymentMethods;

        public CombinedPayment(List<IPaymentMethods> _paymentMethods)
        {
            paymentMethods = _paymentMethods;
        }
        public void Pay(ref decimal remaining)
        {
            foreach (var paymentMethod in paymentMethods)
            {
                remaining = paymentMethod.Pay(remaining);
                if (remaining == 0) break;
            }
        }
    }
}
