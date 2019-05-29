using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class CreditPayment : Payment
    {
        public CreditPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string payer, Document document, Address address, Email email)
            : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
        { }

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
    }
}