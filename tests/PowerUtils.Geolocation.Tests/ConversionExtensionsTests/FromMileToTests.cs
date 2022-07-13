namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

public class FromMileToTests
{
    [Theory]
    [InlineData(11423.457, 18384226)]
    [InlineData(1.154, 1857.17834)]
    [InlineData(221.24, 356050.375)]
    public void FloatMile_FromMileToMeter_Meter(float miles, float expected)
    {
        // Arrange & Act
        var act = miles.FromMileToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 18384226.28838)]
    [InlineData(1.154, 1857.1783599999997)]
    [InlineData(221.24, 356050.3816)]
    public void DoubleMile_FromMileToMeter_Meter(double miles, double expected)
    {
        // Arrange & Act
        var act = miles.FromMileToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 18_384_226.28838)]
    [InlineData(1.154, 1_857.1783599999997)]
    [InlineData(221.24, 356_050.3816)]
    public void DecimalMile_FromMileToMeter_Meter(decimal miles, decimal expected)
    {
        // Arrange & Act
        var act = miles.FromMileToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 18384.2266)]
    [InlineData(1.154, 1.85717833)]
    [InlineData(221.24, 356.050385)]
    public void FloatMile_FromMileToKilometer_Kilometer(float miles, float expected)
    {
        // Arrange & Act
        var act = miles.FromMileToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting double numbers in miles to kilometers")]
    [InlineData(11423.457, 18384.22628838)]
    [InlineData(1.154, 1.8571783599999998)]
    [InlineData(221.24, 356.05038160000004)]
    public void DoubleMile_FromMileToKilometer_Kilometer(double miles, double expected)
    {
        // Arrange & Act
        var act = miles.FromMileToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 18384.22628838)]
    [InlineData(1.154, 1.8571783599999998)]
    [InlineData(221.24, 356.05038160000004)]
    public void DecimalMile_FromMileToKilometer_Kilometer(decimal miles, decimal expected)
    {
        // Arrange & Act
        var act = miles.FromMileToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void DoubleMile_FromMileTo_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void DecimalMile_FromMileTo_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 3.21_868)]
    [InlineData(2, DistanceUnit.Meter, 32_18.68)]
    [InlineData(2, DistanceUnit.Mile, 2)]
    public void FloatMile_FromMileTo_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromMileTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }
}
