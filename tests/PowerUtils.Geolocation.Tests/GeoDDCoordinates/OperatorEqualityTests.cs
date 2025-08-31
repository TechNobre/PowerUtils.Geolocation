using System;
using FluentAssertions;
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
    public void CoordinatesFromCalculations_EqualityOperator_ShouldDetectFloatingPointIssue()
    {
        // Arrange - Create coordinates that should be equal but may have tiny floating-point differences
        var base1 = 45.123456789;
        var base2 = 90.987654321;

        // Perform calculations that may introduce floating-point precision errors
        var calculated1 = base1 * 3 / 3; // Should equal base1, but may have precision error
        var calculated2 = base2 * 7 / 7; // Should equal base2, but may have precision error

        var coord1 = new GeoDDCoordinate(calculated1, calculated2);
        var coord2 = new GeoDDCoordinate(base1, base2);


        // Act
        // The coordinates should be considered equal, but direct == comparison may fail
        var areEqual = coord1 == coord2;


        // Assert - This test may fail due to floating-point precision issues
        // Document the issue: these should be equal but may not be due to floating-point precision
        // Uncomment the line below to see the potential failure:
        areEqual.Should().BeTrue("Coordinates should be equal despite floating-point calculation differences");

        // For now, let's just verify the values are very close
        Math.Abs(coord1.Latitude - coord2.Latitude).Should().BeLessThan(1e-10);
        Math.Abs(coord1.Longitude - coord2.Longitude).Should().BeLessThan(1e-10);
    }

    [Fact]
    public void MinusculeFloatingPointDifferences_EqualityOperator_ShouldBeEqualWithToleranceBasedComparison()
    {
        // Arrange - Create coordinates with tiny differences that should be considered equal
        var lat1 = 45.123456789012345;
        var lon1 = -90.987654321098765;

        var lat2 = 45.123456789012346; // Difference of 1e-15
        var lon2 = -90.987654321098766; // Difference of 1e-15

        var coord1 = new GeoDDCoordinate(lat1, lon1);
        var coord2 = new GeoDDCoordinate(lat2, lon2);


        // Act
        var areEqual = coord1 == coord2;


        // Assert - With tolerance-based equality, tiny differences should be considered equal
        areEqual.Should().BeTrue("Tolerance-based implementation should consider tiny differences as equal");

        // Demonstrate that the differences are minuscule
        var latDiff = Math.Abs(lat1 - lat2);
        var lonDiff = Math.Abs(lon1 - lon2);

        latDiff.Should().BeLessThan(1e-10, "Latitude difference is minuscule");
        lonDiff.Should().BeLessThan(1e-10, "Longitude difference is minuscule");
    }

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


    #region Proposed Tolerance-Based Equality Tests

    [Fact]
    public void DemonstrateToleranceBasedEquality_ShouldSolveFloatingPointIssues()
    {
        // Arrange
        var lat1 = 45.123456789012345;
        var lon1 = -90.987654321098765;
        var lat2 = 45.123456789012346; // Tiny difference
        var lon2 = -90.987654321098764; // Tiny difference

        const double tolerance = 1e-10; // Reasonable tolerance for geographical coordinates


        // Act - Demonstrate how tolerance-based comparison works
        var manualToleranceComparison =
            Math.Abs(lat1 - lat2) < tolerance &&
            Math.Abs(lon1 - lon2) < tolerance;

        var coord1 = new GeoDDCoordinate(lat1, lon1);
        var coord2 = new GeoDDCoordinate(lat2, lon2);
        var actualEqualityResult = coord1 == coord2;


        // Assert
        manualToleranceComparison.Should().BeTrue(
            "Coordinates with tiny differences should be considered equal with tolerance-based comparison");

        // Now the implementation should work correctly with tolerance-based comparison
        actualEqualityResult.Should().BeTrue(
            "Fixed implementation now uses tolerance-based comparison");

        // Demonstrate the difference vs old direct equality - make sure differences are detectable
        var directEquality = lat1 == lat2 && lon1 == lon2;
        if(Math.Abs(lat1 - lat2) > double.Epsilon || Math.Abs(lon1 - lon2) > double.Epsilon)
        {
            directEquality.Should().BeFalse(
                "Direct equality comparison still fails for tiny differences");
        }
    }

    [Theory]
    [InlineData(45.123456789, -90.987654321, 45.123456789, -90.987654321)] // Identical
    [InlineData(45.123456789, -90.987654321, 45.1234567890001, -90.9876543210001)] // Tiny difference within tolerance
    [InlineData(0.0, 0.0, 0.0000000000001, 0.0000000000001)] // Near zero with tiny difference within tolerance
    public void ToleranceBasedEquality_VariousScenarios_ShouldWorkReliably(
        double lat1, double lon1, double lat2, double lon2)
    {
        // Arrange
        const double tolerance = 1e-12; // Updated tolerance to match implementation


        // Act - How tolerance-based equality would work
        var wouldBeEqual =
            Math.Abs(lat1 - lat2) < tolerance &&
            Math.Abs(lon1 - lon2) < tolerance;

        var coord1 = new GeoDDCoordinate(lat1, lon1);
        var coord2 = new GeoDDCoordinate(lat2, lon2);
        var coordinateEquals = coord1 == coord2;

        // Demonstrate current behavior with raw doubles
        var currentlyEqual = lat1 == lat2 && lon1 == lon2;


        // Assert - For tiny differences, tolerance-based should be more reliable
        var latDiff = Math.Abs(lat1 - lat2);
        var lonDiff = Math.Abs(lon1 - lon2);

        if(latDiff < tolerance && lonDiff < tolerance)
        {
            wouldBeEqual.Should().BeTrue("Coordinates within tolerance should be considered equal");
            coordinateEquals.Should().BeTrue("Our implementation should consider coordinates within tolerance as equal");
        }

        // Document when current implementation might fail
        if(latDiff > 0 && latDiff < 1e-14)
        {
            currentlyEqual.Should().BeFalse("Direct equality comparison still fails for tiny differences due to floating-point precision");
        }
    }

    [Theory]
    [InlineData(90.0, 180.0, 89.9999999999, 179.9999999999)] // Near bounds with significant difference
    [InlineData(45.0, -90.0, 44.999999999, -89.999999999)] // Significant difference beyond tolerance
    public void SignificantDifferences_EqualityOperator_ShouldNotBeEqual(
        double lat1, double lon1, double lat2, double lon2)
    {
        // Arrange
        var coord1 = new GeoDDCoordinate(lat1, lon1);
        var coord2 = new GeoDDCoordinate(lat2, lon2);

        // Act
        var areEqual = coord1 == coord2;

        // Assert - These coordinates have significant differences and should not be equal
        areEqual.Should().BeFalse("Coordinates with significant differences should not be considered equal");
    }

    #endregion

    #region Edge Cases for Floating-Point Issues

    [Fact]
    public void CoordinatesNearZero_EqualityOperator_ShouldHandleSignedZero()
    {
        // Arrange - Test signed zero and very small values
        var coord1 = new GeoDDCoordinate(0.0, 0.0);
        var coord2 = new GeoDDCoordinate(-0.0, -0.0); // Negative zero
        var coord3 = new GeoDDCoordinate(1e-16, 1e-16); // Extremely small values


        // Act
        var zeroComparison = coord1 == coord2;
        var nearZeroComparison = coord1 == coord3;


        // Assert
        zeroComparison.Should().BeTrue("Positive and negative zero should be equal");

        // For extremely small values, tolerance-based comparison should handle this correctly
        nearZeroComparison.Should().BeTrue("Values much smaller than tolerance should be treated as equal to zero");
    }

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
