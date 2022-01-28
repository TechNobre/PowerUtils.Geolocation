using System;
using System.Globalization;
using System.Threading;

namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

[Trait("Type", "Extensions")]
public class ToDDPointTests
{
    [Theory(DisplayName = "Converting string to decimal degree for en-GB culture")]
    [InlineData("40.601203", 40.601_203)]
    [InlineData("-79.12", -79.12)]
    [InlineData("-8,668173", -8.668_173)]
    [InlineData("100,8173", 100.8_173)]
    [InlineData("42.342845", 42.342_845)]
    [InlineData("1.193695", 1.193_695)]
    [InlineData("80.463748", 80.463_748)]
    [InlineData("-46.318918", -46.318_918)]
    [InlineData("-24", -24)]
    [InlineData("21", 21)]
    [InlineData("24 234.4", 24_234.4)]
    public void StringDegree_enGB_Conversion(string coordinate, double expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;


        // Act
        var act = coordinate.ToDDPoint();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Theory(DisplayName = "Converting string to decimal degree for pt-PT culture")]
    [InlineData("40.601203", 40.601_203)]
    [InlineData("-79.12", -79.12)]
    [InlineData("-8,668173", -8.668_173)]
    [InlineData("100,8173", 100.8_173)]
    [InlineData("42.342845", 42.342_845)]
    [InlineData("1.193695", 1.193_695)]
    [InlineData("80.463748", 80.463_748)]
    [InlineData("-46.318918", -46.318_918)]
    [InlineData("-24", -24)]
    [InlineData("21", 21)]
    [InlineData("24 234.4", 24_234.4)]
    public void StringDegree_ptPT_Conversion(string coordinate, double expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("pt-PT");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;


        // Act
        var act = coordinate.ToDDPoint();


        // Assert
        act.Should()
            .Be(expected);
    }

    [Fact(DisplayName = "Try to convert a empty string to decimal degree - Should return an exception")]
    public void StringCoordinate_Null_Exception()
    {
        // Arrange
        string coordinate = null;


        // Act
        var act = Record.Exception(() => coordinate.ToDDPoint());


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>()
            .Which
            .Message.Should()
                .Be("The value cannot be null (Parameter 'ddPoint')");
    }

    [Theory(DisplayName = "Try to convert a invalid string to decimal degree - Should return an exception")]
    [InlineData("21sd")]
    [InlineData("1.2.1")]
    [InlineData("1fx2.1")]
    [InlineData("")]
    public void StringDegree_Invalid_Exception(string coordinate)
    {
        // Arrange & Act
        var act = Record.Exception(() => coordinate.ToDDPoint());


        // Assert
        act.Should()
            .BeOfType<InvalidCoordinateException>()
            .Which
            .Message.Should()
                .Be($"Coordinate '{coordinate}' is not formatted correctly");
    }
}
