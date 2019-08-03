using Domain.Entities;
using Domain.Repositories;

namespace Domain.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExists(string document)
        {
            return !string.IsNullOrWhiteSpace(document);
        }

        public bool EmailExists(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        }
    }
}