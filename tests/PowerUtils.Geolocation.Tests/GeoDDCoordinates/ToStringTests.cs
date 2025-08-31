using System.Globalization;
using System.Threading;
using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class ToStringTests
{
    [Theory]
    [InlineData("12,152", "-8,12", "12.152, -8.12")]
    [InlineData("12.152", "-8.12", "12.152, -8.12")]
    [InlineData("12,152", "-8.12", "12.152, -8.12")]
    [InlineData("2.1", "8,12", "2.1, 8.12")]
    [InlineData("1.23456789", "8,12", "1.23456789, 8.12")]
    public void Coordinate_ToString_DotAsDecimalSeparator_For_EnGBCulture(string latitude, string longitude, string expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;

        var coordinate = GeoDDCoordinate.Parse(latitude, longitude);


        // Act
        var act = coordinate.ToString();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
    [InlineData("12.152", "-8.12", "12.152, -8.12")]
    [InlineData("12.152", "-8,12", "12.152, -8.12")]
    [InlineData("2.1", "8,12", "2.1, 8.12")]
    [InlineData("1.23456789", "8,12", "1.23456789, 8.12")]
    public void Coordinate_ToString_DotAsDecimalSeparator_For_PtPTCulture(string latitude, string longitude, string expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("pt-PT");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;

        var coordinate = GeoDDCoordinate.Parse(latitude, longitude);


        // Act
        var act = coordinate.ToString();


        // Assert
        act.Should().Be(expected);
    }
}
