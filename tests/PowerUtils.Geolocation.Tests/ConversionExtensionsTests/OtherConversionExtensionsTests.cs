namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class OtherConversionExtensionsTests
{
    [Theory(DisplayName = "Convert cardinal direction to geographical orientation")]
    [InlineData(CardinalDirection.North, GeographicalOrientation.Longitude)]
    [InlineData(CardinalDirection.South, GeographicalOrientation.Longitude)]
    [InlineData(CardinalDirection.East, GeographicalOrientation.Latitude)]
    [InlineData(CardinalDirection.West, GeographicalOrientation.Latitude)]
    public void GetGeographicalOrientation_CardinalPoint_GeographicalOrientation(CardinalDirection cardinalDirection, GeographicalOrientation expected)
    {
        // Arrange & Act
        var act = cardinalDirection.GetGeographicalOrientation();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Convert degrees to radians")]
    [InlineData(6378137, 111319.49079327357)]
    [InlineData(4234, 73.897240529439912)]
    [InlineData(11, 0.19198621771937624)]
    public void ToRadian_Degrees_Radians(double degree, double radian)
    {
        // Arrange & Act
        var act = degree.ToRadian();


        // Assert
        act.Should()
            .Be(radian);
    }

    [Theory(DisplayName = "Convert radians to degrees")]
    [InlineData(111319.49079327357, 6378137)]
    [InlineData(73.897240529439912, 4234)]
    [InlineData(0.19198621771937624, 11)]
    public void ToRadian_Radians_Degrees(double radian, double degree)
    {
        // Arrange & Act
        var act = radian.ToDegree();


        // Assert
        act.Should()
            .Be(degree);
    }
}
