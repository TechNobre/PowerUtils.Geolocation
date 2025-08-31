using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class CreationTests
{
    [Fact]
    public void ValidLatitudeLongitude_Constructor_Create()
    {
        // Arrange
        var latitude = 81.54;
        var longitude = -54.1272;


        // Act
        var act = new GeoDDCoordinate(
            latitude,
            longitude);


        // Assert
        act.Latitude.Should().Be(latitude);
        act.Longitude.Should().Be(longitude);
    }

    [Fact]
    public void SmallLatitude_CreateGeoDDCoordinate_MinLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(-90.1, 12));


        // Assert
        act.Should().BeOfType<MinLatitudeException>();
    }

    [Fact]
    public void LargeLatitude_CreateGeoDDCoordinate_MaxLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(90.1, 12));


        // Assert
        act.Should().BeOfType<MaxLatitudeException>();
    }

    [Fact]
    public void SmallLongitude_CreateGeoDDCoordinate_MinLongitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(12, -180.1));


        // Assert
        act.Should().BeOfType<MinLongitudeException>();
    }

    [Fact]
    public void LargeLongitude_CreateGeoDDCoordinate_MaxLongitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(12, 180.1));


        // Assert
        act.Should().BeOfType<MaxLongitudeException>();
    }
}
