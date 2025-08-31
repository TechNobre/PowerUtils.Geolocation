using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class MinLatitudeExceptionTests
{
    [Fact]
    public void Validate_exception_message_of_MinLatitudeException()
    {
        // Arrange
        var coordinate = -90.1;


        // Act
        var act = new MinLatitudeException(coordinate);


        // Assert
        act.Should().BeOfType<MinLatitudeException>()
            .Which.Message.Should().Be("The minimum latitude is -90. Value '-90.1'");
    }
}
