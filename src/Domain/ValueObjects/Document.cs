using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObject
{
    public class Document
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

    }
}