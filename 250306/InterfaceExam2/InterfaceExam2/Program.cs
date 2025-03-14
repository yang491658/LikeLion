using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExam2
{
    // 인터페이스를 사용하면 기존 코드 변경 없이 새로운 기능 추가가 가능함.
    // 예) 다양한 결제 시스템 추가(Open-Closed Principle)

    interface Payment
    {
        void ProcessPayment();
    }

    class CreditCard : Payment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("신용카드 결제 완료");
        }
    }

    class PayPal : Payment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("페이팔 결제 완료");
        }
    }

    class PaymentProcessor
    {
        public void Pay(Payment payment)
        {
            payment.ProcessPayment();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            Payment creditcard = new CreditCard();
            processor.Pay(creditcard);

            Payment paypal = new PayPal();
            processor.Pay(paypal);
        }
    }
}
