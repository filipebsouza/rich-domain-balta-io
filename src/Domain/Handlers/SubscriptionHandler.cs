using System;
using Domain.Commands;
using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Domain.Service;
using Domain.ValueObjects;
using Flunt.Notifications;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable,
        IHandler<CreateBoletoSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(
            IStudentRepository repository,
            IEmailService emailService
        )
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            // Fail Test Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível validar sua assinaturaa.");
            }

            //Verificar se documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Esse CPF já está em uso.");
            }

            //Verificar se e-mail já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Esse E-mail já está em uso.");
            }

            //Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(
                command.Street, command.Number, command.Neighborhood, command.City,
                command.State, command.Country, command.ZipCode);

            //Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");

            //Salvar as Informações
            _repository.CreateSubscription(student);

            //Enviar e-mail de boas-vindas
            _emailService.Send(
                student.Name.ToString(),
                student.Email.Address,
                "Bem-vindo ao curso",
                "Sua assinatura foi criada."
            );

            //Retornar Informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            // Fail Test Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possível validar sua assinaturaa.");
            }

            //Verificar se documento já está cadastrado
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Esse CPF já está em uso.");
            }

            //Verificar se e-mail já está cadastrado
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "Esse E-mail já está em uso.");
            }

            //Gerar VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(
                command.Street, command.Number, command.Neighborhood, command.City,
                command.State, command.Country, command.ZipCode);

            //Gerar as Entidades
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaidDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.PayerDocument, command.PayerDocumentType),
                address,
                email
            );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Agrupar Validações
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Checar as notificações
            if (Invalid)
                return new CommandResult(false, "Não foi possível realizar sua assinatura.");

            //Salvar as Informações
            _repository.CreateSubscription(student);

            //Enviar e-mail de boas-vindas
            _emailService.Send(
                student.Name.ToString(),
                student.Email.Address,
                "Bem-vindo ao curso",
                "Sua assinatura foi criada."
            );

            //Retornar Informações
            return new CommandResult(true, "Assinatura realizada com sucesso");
        }
    }
}