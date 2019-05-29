using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string payer, Document document, Address address, Email email)
            : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
        { }

        public string TransactionCode { get; set; }
    }
}