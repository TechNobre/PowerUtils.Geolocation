namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class FromMileToTests
{
    [Theory(DisplayName = "Converting double numbers in miles to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void DoubleNumbers_Mile_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in miles to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void DecimalNumbers_Mile_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in miles to a new unit")]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void FloatNumbers_Mile_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }
}
