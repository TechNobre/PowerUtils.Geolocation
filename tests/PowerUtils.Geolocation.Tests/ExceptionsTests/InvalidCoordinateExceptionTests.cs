using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class InvalidCoordinateExceptionTests
{
    [Fact]
    public void Validate_exception_message_of_InvalidCoordinateException()
    {
        // Arrange
        var coordinate = "2.12..1";


        // Act
        var act = new InvalidCoordinateException(coordinate);


        // Assert
        act.Should().BeOfType<InvalidCoordinateException>()
            .Which.Message.Should().Be("Coordinate '2.12..1' is not formatted correctly");
    }
}
