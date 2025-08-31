using FluentAssertions;
using PowerUtils.Geolocation.Types;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

public class FromKilometerToTests
{
    [Theory]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void IntKilometer_FromKilometerToMeter_Meter(int kilometer, int expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void UIntKilometer_FromKilometerToMeter_Meter(uint kilometer, uint expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void LongKilometer_FromKilometerToMeter_Meter(long kilometer, long expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void ULongKilometer_FromKilometerToMeter_Meter(ulong kilometer, ulong expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void FloatKilometer_FromKilometerToMeter_Meter(float kilometer, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void DoubleKilometer_FromKilometerToMeter_Meter(double kilometer, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void DecimalKilometer_FromKilometerToMeter_Meter(decimal kilometer, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 7_098.2_0459)]
    [InlineData(1.154, 0.7_170_621)]
    [InlineData(221.24, 137.472_122)]
    public void FloatKilometer_FromKilometerToMile_Mile(float kilometer, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 7098.204899547)]
    [InlineData(1.154, 0.717062134)]
    [InlineData(221.24, 137.47212004)]
    public void DoubleKilometer_FromKilometerToMile_Mile(double kilometer, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(11423.457, 7098.204899547)]
    [InlineData(1.154, 0.717062134)]
    [InlineData(221.24, 137.47212004)]
    public void DecimalKilometer_FromKilometerToMile_Mile(decimal kilometer, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void DoubleKilometer_FromKilometerTo_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void DecimalKilometer_FromKilometerTo_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.kilometer, 2)]
    [InlineData(2, DistanceUnit.Meter, 2_000)]
    [InlineData(2, DistanceUnit.Mile, 1.242_742)]
    public void FloatKilometer_FromKilometerTo_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerTo(distanceUnit);


        // Assert
        act.Should()
            .Be(expected);
    }
}
