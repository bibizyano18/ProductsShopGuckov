using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsShop.Model
{
    public class PaymentMethod
    {
        private List<bool> _paymentMethods;
        public decimal cardMoney { get; private set; }
        public decimal cashMoney { get; private set; }
        public decimal bonusMoney { get; private set; }
        public decimal TotalPriceInProccess { get; set; }

        public PaymentMethod() 
        {
            this.cardMoney = 1050;
            this.cashMoney = 345;
            this.bonusMoney = 11;
        }
        public void Payment(List<bool> arr)
        {
            _paymentMethods = arr;
        }
    }
}
