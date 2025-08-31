using System;
using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class OperatorEqualityTests
{
    [Fact]
    public void When_both_is_null_should_return_True_In_EqualityOperator()
    {
        // Arrange
        GeoDDCoordinate left = null;
        GeoDDCoordinate right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should().BeTrue();
    }

    [Fact]
    public void DifferentCoordinates_EqualityOperator_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(81.54, -54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void DifferentLatitude_EqualityOperator_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(81.54, 54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void DifferentLongitude_EqualityOperator_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(1.54, -54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void EqualsCoordinates_EqualityOperator_True()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should().BeTrue();
    }

    [Fact]
    public void RightValueNull_EqualityOperator_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        GeoDDCoordinate right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should().BeFalse();
    }


    #region Floating-Point Precision Issues

    [Fact]
    public void CoordinatesFromStringParsing_EqualityOperator_ShouldHandleParsingPrecision()
    {
        // Arrange - Parse the same coordinate value in different ways
        var directCoord = new GeoDDCoordinate(45.123456, -90.654321);
        var parsedCoord = GeoDDCoordinate.Parse("45.123456", "-90.654321");
        var stringParsedCoord = GeoDDCoordinate.Parse("45.123456, -90.654321");


        // Act
        var direct_vs_parsed = directCoord == parsedCoord;
        var parsed_vs_string = parsedCoord == stringParsedCoord;
        var direct_vs_string = directCoord == stringParsedCoord;


        // Assert - These should all be equal as they represent the same coordinate
        direct_vs_parsed.Should().BeTrue("Direct and parsed coordinates should be equal");
        parsed_vs_string.Should().BeTrue("Parsed coordinates should be equal regardless of method");
        direct_vs_string.Should().BeTrue("All representations should be equal");
    }

    [Fact]
    public void CoordinatesWithRepeatingDecimals_EqualityOperator_ShouldHandlePrecisionLimitsCorrectly()
    {
        // Arrange - Use values that can't be precisely represented in binary floating-point
        var coord1 = new GeoDDCoordinate(1.0 / 3.0, 2.0 / 3.0); // 0.333... and 0.666...
        var coord2 = new GeoDDCoordinate(0.33333333333333331, 0.66666666666666663); // Approximate values

        // Act
        var areEqual = coord1 == coord2;

        // Assert
        var latDiff = Math.Abs(coord1.Latitude - coord2.Latitude);
        var lonDiff = Math.Abs(coord1.Longitude - coord2.Longitude);

        // Document the precision limitations
        latDiff.Should().BeLessThan(1e-15, "Differences should be within double precision limits");
        lonDiff.Should().BeLessThan(1e-15, "Differences should be within double precision limits");

        // With tolerance-based equality, this should now work reliably
        areEqual.Should().BeTrue("Tolerance-based implementation should handle precision representation differences");
    }

    #endregion


    #region Edge Cases for Floating-Point Issues

    [Fact]
    public void CoordinatesAtBoundaries_EqualityOperator_ShouldHandleBoundaryPrecision()
    {
        // Arrange - Test coordinates at the boundaries of valid ranges
        var maxCoord1 = new GeoDDCoordinate(90.0, 180.0);
        var maxCoord2 = new GeoDDCoordinate(90.0, 180.0);
        var nearMaxCoord = new GeoDDCoordinate(89.9999999999, 179.9999999999);

        var minCoord1 = new GeoDDCoordinate(-90.0, -180.0);
        var minCoord2 = new GeoDDCoordinate(-90.0, -180.0);
        var nearMinCoord = new GeoDDCoordinate(-89.9999999999, -179.9999999999);


        // Act
        var maxEqual = maxCoord1 == maxCoord2;
        var minEqual = minCoord1 == minCoord2;
        var nearMaxDifferent = maxCoord1 == nearMaxCoord;
        var nearMinDifferent = minCoord1 == nearMinCoord;


        // Assert
        maxEqual.Should().BeTrue("Identical boundary coordinates should be equal");
        minEqual.Should().BeTrue("Identical boundary coordinates should be equal");
        nearMaxDifferent.Should().BeFalse("Coordinates with significant differences should not be equal");
        nearMinDifferent.Should().BeFalse("Coordinates with significant differences should not be equal");
    }

    #endregion
}
