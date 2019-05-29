using System;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string number, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string payer, Document document, Address address, Email email)
            : base(number, paidDate, expireDate, total, totalPaid, payer, document, address, email)
        { }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }
    }
}