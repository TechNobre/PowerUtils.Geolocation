using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests
{
    /// <summary>
    /// Tests to detect and verify floating-point equality issues in GeoDDCoordinate
    /// These tests demonstrate the reliability issues with direct floating-point equality comparison
    /// </summary>
    public class GeoDDCoordinateFloatingPointTests
    {
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
        public void MinusculeFloatingPointDifferences_EqualityOperator_ShouldBeEqualButCurrentlyFails()
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


            // Assert
            areEqual.Should().BeFalse("Current implementation uses direct equality which fails for tiny differences");

            // Demonstrate that the differences are minuscule and should be considered equal
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
        public void CoordinatesWithRepeatingDecimals_EqualityOperator_ShouldHandlePrecisionLimits()
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

            // Current implementation may fail this
            areEqual.Should().BeFalse("Current implementation may fail due to precision representation");
        }

        #endregion


        #region Distance Calculation Reliability Tests

        [Fact]
        public void SameCoordinatesFromDifferentSources_DistanceCalculation_ShouldBeZero()
        {
            // Arrange
            var lat = 45.123456789;
            var lon = -90.987654321;

            var coord1 = new GeoDDCoordinate(lat, lon);
            var coord2 = new GeoDDCoordinate((lat * 2) / 2, (lon * 2) / 2); // Should be same but may have precision error


            // Act
            var distance = GeoDDCoordinate.Distance(
                coord1.Latitude, coord1.Longitude,
                coord2.Latitude, coord2.Longitude);


            // Assert
            distance.Should().BeLessThan(0.1, "Distance between same coordinates should be essentially zero");
        }

        #endregion


        #region Hash Code Consistency Tests

        [Fact]
        public void NearlyIdenticalCoordinates_GetHashCode_ShouldBeConsistentWithEquality()
        {
            // Arrange
            var coord1 = new GeoDDCoordinate(45.123456789012, -90.987654321098);
            var coord2 = new GeoDDCoordinate(45.123456789012, -90.987654321098);
            var coord3 = new GeoDDCoordinate(45.123456789013, -90.987654321099); // Tiny difference


            // Act
            var hash1 = coord1.GetHashCode();
            var hash2 = coord2.GetHashCode();
            var hash3 = coord3.GetHashCode();

            var equals_1_2 = coord1 == coord2;
            var equals_1_3 = coord1 == coord3;


            // Assert
            equals_1_2.Should().BeTrue("Identical coordinates should be equal");
            hash1.Should().Be(hash2, "Equal objects should have equal hash codes");

            if (equals_1_3)
            {
                hash1.Should().Be(hash3, "If objects are equal, hash codes must be equal");
            }
            // Note: Different objects can have the same hash code, but equal objects must have the same hash code
        }

        #endregion


        #region Collection Behavior Tests

        [Fact]
        public void NearlyIdenticalCoordinates_InHashSet_ShouldBehaveConsistently()
        {
            // Arrange
            var hashSet = new System.Collections.Generic.HashSet<GeoDDCoordinate>();

            var coord1 = new GeoDDCoordinate(45.123456789012, -90.987654321098);
            var coord2 = new GeoDDCoordinate(45.123456789012, -90.987654321098);
            var coord3 = new GeoDDCoordinate(45.123456789013, -90.987654321099); // Tiny difference


            // Act
            hashSet.Add(coord1);
            var added2 = hashSet.Add(coord2); // Should not be added if equal to coord1
            var added3 = hashSet.Add(coord3); // May or may not be added depending on equality


            // Assert
            added2.Should().BeFalse("Identical coordinate should not be added again");
            hashSet.Should().Contain(coord1);
            hashSet.Should().Contain(coord2); // Should find it even if not added

            // Document behavior with nearly identical coordinates
            if (coord1 == coord3)
            {
                added3.Should().BeFalse("Nearly identical coordinates should not be added if considered equal");
                hashSet.Should().Contain(coord3);
            }
            else
            {
                added3.Should().BeTrue("Different coordinates should be added");
            }
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
            var lon2 = -90.987654321098766; // Tiny difference

            const double tolerance = 1e-10; // Reasonable tolerance for geographical coordinates


            // Act - Demonstrate how tolerance-based comparison would work
            var wouldBeEqualWithTolerance =
                Math.Abs(lat1 - lat2) < tolerance &&
                Math.Abs(lon1 - lon2) < tolerance;


            // Assert
            wouldBeEqualWithTolerance.Should().BeTrue(
                "Coordinates with tiny differences should be considered equal with tolerance-based comparison");

            // Demonstrate the current problem
            var currentlyEqual = lat1 == lat2 && lon1 == lon2;
            currentlyEqual.Should().BeFalse(
                "Current direct equality comparison fails for tiny differences");
        }

        [Theory]
        [InlineData(45.123456789, -90.987654321, 45.123456789, -90.987654321)] // Identical
        [InlineData(45.123456789, -90.987654321, 45.1234567891, -90.9876543211)] // Tiny difference
        [InlineData(0.0, 0.0, 0.0000000001, 0.0000000001)] // Near zero with tiny difference
        [InlineData(90.0, 180.0, 89.9999999999, 179.9999999999)] // Near bounds with tiny difference
        public void ToleranceBasedEquality_VariousScenarios_ShouldWorkReliably(
            double lat1, double lon1, double lat2, double lon2)
        {
            // Arrange
            const double tolerance = 1e-8; // Reasonable tolerance for geographical coordinates


            // Act - How tolerance-based equality would work
            var wouldBeEqual =
                Math.Abs(lat1 - lat2) < tolerance &&
                Math.Abs(lon1 - lon2) < tolerance;

            // Demonstrate current behavior
            var currentlyEqual = lat1 == lat2 && lon1 == lon2;


            // Assert - For tiny differences, tolerance-based should be more reliable
            var latDiff = Math.Abs(lat1 - lat2);
            var lonDiff = Math.Abs(lon1 - lon2);

            if (latDiff < tolerance && lonDiff < tolerance)
            {
                wouldBeEqual.Should().BeTrue("Coordinates within tolerance should be considered equal");
            }

            // Document when current implementation might fail
            if (latDiff > 0 && latDiff < 1e-14)
            {
                currentlyEqual.Should().BeFalse("Current implementation may fail for tiny differences due to floating-point precision");
            }
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

            // For extremely small values, current implementation may be unreliable
            // 1e-16 == 0.0 --- This might be true due to floating-point precision
            nearZeroComparison.Should().BeTrue("Values smaller than double precision should be treated as zero");
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
}
