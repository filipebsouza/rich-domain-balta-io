using System;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void ShouldBeCreatedStudent()
        {
            var student = new Student(
                new Name("Filipe", "Souza"),
                new Document("152456", EDocumentType.CPF),
                "asd@asd.com"
            );

            Assert.NotNull(student);
        }
    }
}
