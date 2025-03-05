/*
using System;
using System.Diagnostics.Contracts;

namespace ElearningPortal.Services
{
    public abstract class PaymentMethod
    {
        protected decimal Amount { get; private set; }

        // 🔐 Invariant: Amount should never be negative
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(Amount >= 0, "Amount must be non-negative.");
        }

        public PaymentMethod(decimal amount)
        {
            Contract.Requires(amount > 0, "Payment amount must be greater than zero.");
            Amount = amount;
        }

        // Abstract method for processing payment
        public abstract bool ProcessPayment();
    }

    // ✅ Credit Card Payment
    public class CreditCardPayment : PaymentMethod
    {
        public CreditCardPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Contract.Ensures(Contract.Result<bool>() == true, "Payment should be successful.");
            Console.WriteLine($"💳 Processing credit card payment of ₹{Amount}...");
            return true;  // Assume success
        }
    }

    // ✅ PayPal Payment
    public class PayPalPayment : PaymentMethod
    {
        public PayPalPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Contract.Ensures(Contract.Result<bool>() == true, "Payment should be successful.");
            Console.WriteLine($"🅿️ Processing PayPal payment of ₹{Amount}...");
            return true;  // Assume success
        }
    }

    // ✅ UPI Payment
    public class UPIPayment : PaymentMethod
    {
        public UPIPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Contract.Ensures(Contract.Result<bool>() == true, "Payment should be successful.");
            Console.WriteLine($"📲 Processing UPI payment of ₹{Amount}...");
            return true;  // Assume success
        }
    }
}
*/

using System;

namespace ElearningPortal.Functionalities
{
    public abstract class PaymentMethod
    {
        public decimal Amount { get; protected set; }

        protected PaymentMethod(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Payment amount must be greater than zero.");

            Amount = amount;
        }

        public abstract bool ProcessPayment();
    }

    public class CreditCardPayment : PaymentMethod
    {
        public CreditCardPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Console.WriteLine($"✅ Paid ₹{Amount} using Credit Card.");
            return true;
        }
    }

    public class PayPalPayment : PaymentMethod
    {
        public PayPalPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Console.WriteLine($"✅ Paid ₹{Amount} using PayPal.");
            return true;
        }
    }

    public class UPIPayment : PaymentMethod
    {
        public UPIPayment(decimal amount) : base(amount) { }

        public override bool ProcessPayment()
        {
            Console.WriteLine($"✅ Paid ₹{Amount} using UPI.");
            return true;
        }
    }
}
