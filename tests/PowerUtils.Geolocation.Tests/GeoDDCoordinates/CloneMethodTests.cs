using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class CloneMethodTests
{
    [Fact]
    public void GeoDDCoordinate_Clone_EqualsObject()
    {
        // Arrange
        var coordinate = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = coordinate.Clone() as GeoDDCoordinate;


        // Assert
        act.Latitude.Should().Be(coordinate.Latitude);
        act.Longitude.Should().Be(coordinate.Longitude);
    }
}
