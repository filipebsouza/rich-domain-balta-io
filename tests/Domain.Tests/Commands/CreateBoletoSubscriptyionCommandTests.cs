using Domain.Commands;
using Xunit;

namespace Domain.Tests.Commands
{
    public class CreateBoletoSubscriptyionCommandTests
    {
        [Fact]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            //Given
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            //When
            command.Validate();

            //Then
            Assert.False(command.Valid);
        }
    }
}