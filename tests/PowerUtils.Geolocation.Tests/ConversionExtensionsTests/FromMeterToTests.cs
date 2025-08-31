using AwesomeAssertions;
using PowerUtils.Geolocation.Types;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

public sealed class FromMeterToTests
{
    [Theory]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void IntMeter_FromMeterToKilometer_Kilometer(int meter, int expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void UIntMeter_FromMeterToKilometer_Kilometer(uint meter, uint expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void LongMeter_FromMeterToKilometer_Kilometer(long meter, long expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void ULongMeter_FromMeterToKilometer_Kilometer(ulong meter, ulong expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void FloatMeter_FromMeterToKilometer_Kilometer(float meter, float expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void DoubleMeter_FromMeterToKilometer_Kilometer(double meter, double expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void DecimalMeter_FromMeterToKilometer_Kilometer(decimal meter, decimal expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(11_423.457, 7.09820461)]
    [InlineData(1.154, 0.000717062154)]
    [InlineData(221.24, 0.137472123)]
    public void FloatMeter_FromMeterToMile_Mile(float meter, float expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(11_423.457, 7.098204899547)]
    [InlineData(1.154, 0.000717062134)]
    [InlineData(221.24, 0.13747212004)]
    public void DoubleMeter_FromMeterToMile_Mile(double meter, double expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(11_423.457, 7.098204899547)]
    [InlineData(1.154, 0.000717062134)]
    [InlineData(221.24, 0.13747212004)]
    public void DecimalMeter_FromMeterToMile_Mile(decimal meter, decimal expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.Kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void DoubleMeter_FromMeterTo_Conversion(double kilometer, DistanceUnit distanceUnit, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.Kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void DecimalMeter_FromMeterTo_Conversion(decimal kilometer, DistanceUnit distanceUnit, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData(2, DistanceUnit.Kilometer, 0.002)]
    [InlineData(2, DistanceUnit.Meter, 2)]
    [InlineData(2, DistanceUnit.Mile, 0.001_242_742)]
    public void FloatMeter_FromMeterTo_Conversion(float kilometer, DistanceUnit distanceUnit, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromMeterTo(distanceUnit);


        // Assert
        act.Should().Be(expected);
    }
}
