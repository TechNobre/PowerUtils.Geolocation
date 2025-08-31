using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class DistanceMethodTests
{
    [Fact]
    public void SameCoordinatesFromDifferentSources_DistanceCalculation_ShouldBeZero()
    {
        // Distance Calculation Reliability Tests

        // Arrange
        var lat = 45.123456789;
        var lon = -90.987654321;

        var coord1 = new GeoDDCoordinate(lat, lon);
        var coord2 = new GeoDDCoordinate(lat * 2 / 2, lon * 2 / 2); // Should be same but may have precision error


        // Act
        var distance = GeoDDCoordinate.Distance(
            coord1.Latitude, coord1.Longitude,
            coord2.Latitude, coord2.Longitude);


        // Assert
        distance.Should().BeLessThan(0.1, "Distance between same coordinates should be essentially zero");
    }
}
