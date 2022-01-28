namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class FromMeterToTests
{
    [Theory(DisplayName = "Converting double numbers in meters to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void DoubleNumbers_Meter_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in meters to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void DecimalNumbers_Meter_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in meters to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void FloatNumbers_Meter_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }
}
