using System;
using System.Globalization;
using System.Threading;
using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ConversionExtensionsTests;

public class ToDDPointTests
{
    [Theory]
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
    [InlineData("22 ", 22)]
    [InlineData(" 31 ", 31)]
    [InlineData(" 47", 47)]
    public void StringDegreeEnGB_ToDDPoint_Conversion(string coordinate, double expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("en-GB");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;


        // Act
        var act = coordinate.ToDDPoint();


        // Assert
        act.Should().Be(expected);
    }

    [Theory]
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
    [InlineData("22 ", 22)]
    [InlineData(" 31 ", 31)]
    [InlineData(" 47", 47)]
    public void StringDegreePtPT_ToDDPoint_Conversion(string coordinate, double expected)
    {
        // Arrange
        var cultureInfo = new CultureInfo("pt-PT");
        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;


        // Act
        var act = coordinate.ToDDPoint();


        // Assert
        act.Should().Be(expected);
    }

    [Fact]
    public void NullStringCoordinate_ToDDPoint_Exception()
    {
        // Arrange
        string coordinate = null;


        // Act
        var act = Record.Exception(() => coordinate.ToDDPoint());


        // Assert
        act.Should().BeOfType<ArgumentNullException>()
            .Which.Message.Should().Be("The value cannot be null (Parameter 'ddPoint')");
    }

    [Theory]
    [InlineData("21sd")]
    [InlineData("1.2.1")]
    [InlineData("1fx2.1")]
    [InlineData("")]
    [InlineData(" 1 2 ")]
    [InlineData("24 234.4")]
    [InlineData(" 24 234.4 32c")]
    public void InvalidStringDegree_ToDDPoint_Exception(string coordinate)
    {
        // Arrange & Act
        var act = Record.Exception(() => coordinate.ToDDPoint());


        // Assert
        act.Should().BeOfType<InvalidCoordinateException>()
            .Which.Message.Should().Be($"Coordinate '{coordinate}' is not formatted correctly");
    }
}
