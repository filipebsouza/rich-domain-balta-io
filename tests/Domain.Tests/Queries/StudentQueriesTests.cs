using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.ValueObjects;
using Xunit;

namespace Domain.Queries
{
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document($"11111111{i}", Enums.EDocumentType.CPF),
                    new Email($"{i}@email.com")
                ));
            }
        }

        [Fact]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            //Given
            var expression = StudentQueries.GetStudent("12345678911");

            //When
            var expectedStudent = _students.AsQueryable().Where(expression).FirstOrDefault();

            //Then
            Assert.Null(expectedStudent);
        }
    }
}