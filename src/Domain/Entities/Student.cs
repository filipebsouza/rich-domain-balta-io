using System;
using System.Collections.Generic;
using Domain.ValueObjects;
using Shared.Entities.Shared;

namespace Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }
        public Name Name { get; private set; }
        public Document Document { get; set; }
        public Email Email { get; set; }
        public Address Address { get; set; }
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