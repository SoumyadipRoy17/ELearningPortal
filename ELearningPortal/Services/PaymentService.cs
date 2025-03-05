using System;
using ElearningPortal.Functionalities;

namespace ElearningPortal.Services
{
    public class PaymentService
    {
        public bool ProcessPayment(PaymentMethod paymentMethod)
        {
            if (paymentMethod == null)
            {
                Console.WriteLine("❌ Payment method is invalid.");
                return false;
            }

            Console.WriteLine($"Processing payment of ₹{paymentMethod.Amount} using {paymentMethod.GetType().Name}...");
            return paymentMethod.ProcessPayment();
        }
    }
}
