namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

public class OtherConversionExtensionsTests
{
    [Theory]
    [InlineData(CardinalDirection.North, GeographicalOrientation.Longitude)]
    [InlineData(CardinalDirection.South, GeographicalOrientation.Longitude)]
    [InlineData(CardinalDirection.East, GeographicalOrientation.Latitude)]
    [InlineData(CardinalDirection.West, GeographicalOrientation.Latitude)]
    public void CardinalPoint_GetGeographicalOrientation_GeographicalOrientation(CardinalDirection cardinalDirection, GeographicalOrientation expected)
    {
        // Arrange & Act
        var act = cardinalDirection.GetGeographicalOrientation();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(6378137, 111319.49079327357)]
    [InlineData(4234, 73.897240529439912)]
    [InlineData(11, 0.19198621771937624)]
    public void Degrees_ToRadian_Radians(double degree, double radian)
    {
        // Arrange & Act
        var act = degree.ToRadian();


        // Assert
        act.Should()
            .Be(radian);
    }

    [Theory]
    [InlineData(111319.49079327357, 6378137)]
    [InlineData(73.897240529439912, 4234)]
    [InlineData(0.19198621771937624, 11)]
    public void Radians_ToRadian_Degrees(double radian, double degree)
    {
        // Arrange & Act
        var act = radian.ToDegree();


        // Assert
        act.Should()
            .Be(degree);
    }
}
