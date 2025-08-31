using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class ToStringTests
{
    [Fact]
    public void Coordinate_ToString_DotAsDecimalSeparator()
    {
        // Arrange
        var coordinate = GeoDDCoordinate.Parse("12,152", "-8,12");


        // Act
        var act = coordinate.ToString();


        // Assert
        act.Should().Be("12.152, -8.12");
    }
}
