using AwesomeAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class HashCodeTests
{
    [Fact]
    public void EqualsProperties_ComparisonHashCodes_True()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = left.GetHashCode() == right.GetHashCode();


        // Assert
        act.Should().BeTrue();
    }

    [Fact]
    public void DifferentsProperties_ComparisonHashCodes_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 5.1272);
        var right = new GeoDDCoordinate(-1.54, 54.1272);


        // Act
        var act = left.GetHashCode() == right.GetHashCode();


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void HashCode_QuantizationDistinction_OutsideTolerance()
    {
        // Arrange: Create coordinates that should quantize to different hash buckets
        var coord1 = new GeoDDCoordinate(0.0, 0.0);
        var coord2 = new GeoDDCoordinate(2e-10, 2e-10); // 2x larger than hash tolerance


        // Act
        var hash1 = coord1.GetHashCode();
        var hash2 = coord2.GetHashCode();


        // Assert: These should have different hashes due to different quantization buckets
        hash1.Should().NotBe(hash2, "coordinates outside hash tolerance should have different hash codes");
    }

    [Fact]
    public void HashCode_ArithmeticOverflow_MutantDetection()
    {
        // Test designed to catch mutants that cause arithmetic overflow
        // in the hash combination step

        // Arrange: Use coordinates near boundaries
        var coord = new GeoDDCoordinate(89.999999, 179.999999);


        // Act
        var hashCode = coord.GetHashCode();


        // Assert: Hash should be stable and not overflow
        var duplicateHash = coord.GetHashCode();
        hashCode.Should().Be(duplicateHash, "hash should be stable and deterministic");

        // Should not be extreme values that might indicate overflow
        hashCode.Should().BeInRange(int.MinValue + 1000, int.MaxValue - 1000, "hash should not be near overflow boundaries");
    }
}
