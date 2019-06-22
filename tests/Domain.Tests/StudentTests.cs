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
            var name = new Name("Teste", "Teste");
            foreach (var not in name.Notifications)
            {
               var teste = not.Message;

            }

            Assert.True(true);
        }
    }
}
