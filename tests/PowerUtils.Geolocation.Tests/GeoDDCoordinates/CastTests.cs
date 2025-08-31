using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class CastTests
{
    [Fact]
    public void GeoDDCoordinate_CastToString_DotAsDecimalSeparator()
    {
        // Arrange
        var coordinates = new GeoDDCoordinate(1.54, 5.1272);


        // Act
        var act = (string)coordinates;


        // Assert
        act.Should().Be("1.54, 5.1272");
    }

    [Fact]
    public void AnyString_Cast_GeoDDCoordinate()
    {
        // Arrange
        var coordinate = "-12.51214,14.1272";


        // Act
        var act = (GeoDDCoordinate)coordinate;


        // Assert
        act.Latitude.Should().Be(-12.51214);
        act.Longitude.Should().Be(14.1272);
    }
}
