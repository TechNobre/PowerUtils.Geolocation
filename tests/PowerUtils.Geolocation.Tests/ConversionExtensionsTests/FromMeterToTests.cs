namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class FromMeterToTests
{
    [Theory(DisplayName = "Converting int numbers in meters to kilometers")]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void Int_Meter_Kilometer(int meter, int expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting uint numbers in meters to kilometers")]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void UInt_Meter_Kilometer(uint meter, uint expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting long numbers in meters to kilometers")]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void Long_Meter_Kilometer(long meter, long expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting ulong numbers in meters to kilometers")]
    [InlineData(45_000, 45)]
    [InlineData(423_000, 423)]
    [InlineData(42_331_000, 42_331)]
    public void ULong_Meter_Kilometer(ulong meter, ulong expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in meters to kilometers")]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void Float_Meter_Kilometer(float meter, float expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting double numbers in meters to kilometers")]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void Double_Meter_Kilometer(double meter, double expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in meters to kilometers")]
    [InlineData(45_120, 45.12)]
    [InlineData(423_457, 423.457)]
    [InlineData(11_423_457, 11_423.457)]
    public void Decimal_Meter_Kilometer(decimal meter, decimal expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToKilometer();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in meters to miles")]
    [InlineData(11_423.457, 7.09820461)]
    [InlineData(1.154, 0.000717062154)]
    [InlineData(221.24, 0.137472123)]
    public void Float_Meter_Mile(float meter, float expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting double numbers in meters to miles")]
    [InlineData(11_423.457, 7.098204899547)]
    [InlineData(1.154, 0.000717062134)]
    [InlineData(221.24, 0.13747212004)]
    public void Double_Meter_Mile(double meter, double expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in meters to miles")]
    [InlineData(11_423.457, 7.098204899547)]
    [InlineData(1.154, 0.000717062134)]
    [InlineData(221.24, 0.13747212004)]
    public void Decimal_Meter_Mile(decimal meter, decimal expected)
    {
        // Arrange & Act
        var act = meter.FromMeterToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

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
