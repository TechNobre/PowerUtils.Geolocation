using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public sealed class MaxLatitudeExceptionTests
{
    [Fact]
    public void Validate_exception_message_of_MaxLatitudeException()
    {
        // Arrange
        var coordinate = 90.1;


        // Act
        var act = new MaxLatitudeException(coordinate);


        // Assert
        act.Should().BeOfType<MaxLatitudeException>()
            .Which.Message.Should().Be("The maximum latitude is 90. Value '90.1'");
    }
}
