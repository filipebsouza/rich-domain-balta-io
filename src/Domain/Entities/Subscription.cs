using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Subscription
    {
        public DateTime CreateDate { get; }
        public DateTime LastUpdateDate { get; }
        public DateTime? ExpireDate { get; }
        public bool Active { get; private set; }
        public List<Payment> Payments { get; }

        public void Inactive()
        {
            Active = false;
        }
    }
}