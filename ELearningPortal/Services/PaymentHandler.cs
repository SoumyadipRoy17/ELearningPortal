using System;
using ElearningPortal.Functionalities;
using ElearningPortal.Models;

namespace ElearningPortal.Services
{
    public class PaymentHandler
    {
        private readonly PaymentService _paymentService;

        public PaymentHandler(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public bool ProcessPayment(double price)
        {
            Console.WriteLine($"Course Price: Rs{price}");
            Console.WriteLine("Select Payment Method (1. Credit Card, 2. PayPal, 3. UPI): ");
            string paymentChoice = Console.ReadLine();
            PaymentMethod paymentMethod = null;

            switch (paymentChoice)
            {
                case "1":
                    paymentMethod = new CreditCardPayment(Convert.ToDecimal(price));
                    break;
                case "2":
                    paymentMethod = new PayPalPayment(Convert.ToDecimal(price));
                    break;
                case "3":
                    paymentMethod = new UPIPayment(Convert.ToDecimal(price));
                    break;
                default:
                    Console.WriteLine("Invalid payment method.");
                    return false;
            }

            return _paymentService.ProcessPayment(paymentMethod);
        }
    }
}
