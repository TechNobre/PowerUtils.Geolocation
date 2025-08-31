using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class DeconstructTests
{
    [Fact]
    public void GeoDDCoordinate_Deconstruct_LatitudeAndLongitude()
    {
        // Arrange
        var latitude = 81.54;
        var longitude = -54.1272;

        var coordinates = new GeoDDCoordinate(latitude, longitude);


        // Act
        (var actLatitude, var actLongitude) = coordinates;


        // Assert
        actLatitude.Should().Be(latitude);
        actLongitude.Should().Be(longitude);
    }
}
