namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class FromKilometerToTests
{
    [Theory(DisplayName = "Converting double numbers in kilometers to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void DoubleNumbers_Kilometer_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in kilometers to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void DecimalNumbers_Kilometer_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in kilometers to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void FloatNumbers_Kilometer_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }
}
