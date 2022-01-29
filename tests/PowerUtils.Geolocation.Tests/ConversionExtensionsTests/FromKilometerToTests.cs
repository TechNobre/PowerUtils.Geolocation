namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class FromKilometerToTests
{
    [Theory(DisplayName = "Converting int numbers in kilometers to meter")]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void Int_Kilometer_Meter(int kilometer, int expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting uint numbers in kilometers to meter")]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void UInt_Kilometer_Meter(uint kilometer, uint expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting long numbers in kilometers to meter")]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void Long_Kilometer_Meter(long kilometer, long expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting ulong numbers in kilometers to meter")]
    [InlineData(45, 45_000)]
    [InlineData(423, 423_000)]
    [InlineData(42331, 42_331_000)]
    public void ULong_Kilometer_Meter(ulong kilometer, ulong expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in kilometers to meter")]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void Float_Kilometer_Meter(float kilometer, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting double numbers in kilometers to meter")]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void Double_Kilometer_Meter(double kilometer, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in kilometers to meter")]
    [InlineData(45.12, 45_120)]
    [InlineData(423.457, 423_457)]
    [InlineData(11423.457, 11_423_457)]
    public void Decimal_Kilometer_Meter(decimal kilometer, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMeter();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting float numbers in kilometers to miles")]
    [InlineData(11423.457, 7_098.2_0459)]
    [InlineData(1.154, 0.7_170_621)]
    [InlineData(221.24, 137.472_122)]
    public void Float_Kilometer_Mile(float kilometer, float expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting double numbers in kilometers to miles")]
    [InlineData(11423.457, 7098.204899547)]
    [InlineData(1.154, 0.717062134)]
    [InlineData(221.24, 137.47212004)]
    public void Double_Kilometer_Mile(double kilometer, double expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting decimal numbers in kilometers to miles")]
    [InlineData(11423.457, 7098.204899547)]
    [InlineData(1.154, 0.717062134)]
    [InlineData(221.24, 137.47212004)]
    public void Decimal_Kilometer_Mile(decimal kilometer, decimal expected)
    {
        // Arrange & Act
        var act = kilometer.FromKilometerToMile();


        // Assert
        act.Should()
            .Be(expected);
    }

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
