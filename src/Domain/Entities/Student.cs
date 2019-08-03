using System;
using System.Collections.Generic;
using Domain.ValueObjects;
using Flunt.Validations;
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


        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                    hasSubscriptionActive = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem uma assinatura ativa")
                .AreNotEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
            );

            if (Valid)
                _subscriptions.Add(subscription);
            // Alternativa
            // if (hasSubscriptionActive)
            //     AddNotification("Student.Subscriptions", "Você já tem uma assinatura ativa");
        }
    }
}