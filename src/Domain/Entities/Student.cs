using System.Collections.Generic;
using PaymentContext.Domain.ValueObject;

namespace Domain.Entities
{
    public class Student
    {
        private List<Subscription> _subscriptions;

        public Student(Name name, Document document, string email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }
        public Name Name { get; private set; }
        public Document Document { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public IReadOnlyList<Subscription> Subscriptions
        {
            get
            {
                return _subscriptions.ToArray();
            }
        }

        public void AddSubsciption(Subscription subscription)
        {
            foreach (var sub in Subscriptions)
            {
                sub.Inactive();
            }
        }
    }
}