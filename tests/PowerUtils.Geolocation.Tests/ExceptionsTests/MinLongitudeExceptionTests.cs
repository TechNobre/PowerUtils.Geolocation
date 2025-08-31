using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class MinLongitudeExceptionTests
{
    [Fact]
    public void Validate_exception_message_of_MinLongitudeException()
    {
        // Arrange
        var coordinate = -180.1;


        // Act
        var act = new MinLongitudeException(coordinate);


        // Assert
        act.Should().BeOfType<MinLongitudeException>()
            .Which.Message.Should().Be("The minimum longitude is -180. Value '-180.1'");
    }
}
