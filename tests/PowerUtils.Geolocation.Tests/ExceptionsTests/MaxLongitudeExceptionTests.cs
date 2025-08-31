using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class MaxLongitudeExceptionTests
{
    [Fact]
    public void Validate_exception_message_of_MaxLongitudeException()
    {
        // Arrange
        var coordinate = 180.1;


        // Act
        var act = new MaxLongitudeException(coordinate);


        // Assert
        act.Should().BeOfType<MaxLongitudeException>()
            .Which.Message.Should().Be("The maximum longitude is 180. Value '180.1'");
    }
}
