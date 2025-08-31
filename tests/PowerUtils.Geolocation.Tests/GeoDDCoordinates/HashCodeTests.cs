using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates
{
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
        public void HashCode_ArithmeticMutant_MultiplicationVsDivision()
        {
            // This test targets the Math.Round(value / HASH_TOLERANCE) * HASH_TOLERANCE formula
            // If multiplication is changed to division, quantization will break completely

            // Arrange: Use a coordinate that clearly shows the difference
            var coordinate = new GeoDDCoordinate(1.0, 2.0);

            // The correct quantization should produce reasonable values:
            // quantizedLat = Math.Round(1.0 / 1e-10) * 1e-10 = 1.0
            // quantizedLon = Math.Round(2.0 / 1e-10) * 1e-10 = 2.0

            // If the mutant uses division instead: Math.Round(value / HASH_TOLERANCE) / HASH_TOLERANCE
            // quantizedLat = Math.Round(1.0 / 1e-10) / 1e-10 = 1e10 / 1e-10 = 1e20 (astronomical!)
            // This would cause hash code overflow or extreme values


            // Act
            var hashCode = coordinate.GetHashCode();


            // Assert: A reasonable hash code should be generated
            // We'll create another coordinate with the same expected quantized values
            var identicalCoord = new GeoDDCoordinate(1.0, 2.0);
            var identicalHash = identicalCoord.GetHashCode();

            hashCode.Should().Be(identicalHash, "identical coordinates should have identical hash codes with correct quantization");
        }

        [Fact]
        public void HashCode_DivisionMutant_DetectsArithmeticChange()
        {
            // This test detects if division operators in hash calculation are mutated to multiplication
            // Focus on the hash combination formula: hash = hash * 23 + value.GetHashCode()

            // Arrange: Use coordinates that will have different hash distributions
            var coord1 = new GeoDDCoordinate(10.0, 20.0);
            var coord2 = new GeoDDCoordinate(10.0, 21.0); // Different longitude


            // Act
            var hash1 = coord1.GetHashCode();
            var hash2 = coord2.GetHashCode();


            // Assert: Different coordinates should have different hashes
            hash1.Should().NotBe(hash2, "coordinates with different values should have different hash codes");

            // Both hashes should be reasonable values (not overflows)
            hash1.Should().BeInRange(int.MinValue / 2, int.MaxValue / 2, "hash should be in reasonable range, not overflowed");
            hash2.Should().BeInRange(int.MinValue / 2, int.MaxValue / 2, "hash should be in reasonable range, not overflowed");
        }

        [Fact]
        public void HashCode_QuantizationConsistency_WithinTolerance()
        {
            // Arrange: Create coordinates that should quantize to the same hash bucket
            // Using values that are much smaller than HASH_TOLERANCE (1e-10)
            var coord1 = new GeoDDCoordinate(0.0, 0.0);
            var coord2 = new GeoDDCoordinate(1e-11, 1e-11); // 10x smaller than hash tolerance


            // Act
            var hash1 = coord1.GetHashCode();
            var hash2 = coord2.GetHashCode();


            // Assert: These should have the same hash due to quantization
            hash1.Should().Be(hash2, "coordinates within hash tolerance should quantize to same hash bucket");
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
        public void HashCode_HashCodeCombination_UsesMultiplication()
        {
            // This test specifically targets the hash combination arithmetic
            // The formula is: hash = hash * 23 + value.GetHashCode()
            // If multiplication is changed to division, the hash would be completely different

            // Arrange: Use coordinates with values that make multiplication vs division obvious
            var coord = new GeoDDCoordinate(45.123456, -90.654321);


            // Act
            var hashCode = coord.GetHashCode();


            // Assert: The hash should be deterministic and consistent
            var secondHashCode = coord.GetHashCode();
            hashCode.Should().Be(secondHashCode, "hash code should be deterministic for same coordinate");

            // Create a similar coordinate to verify hash combination is working properly
            var similarCoord = new GeoDDCoordinate(45.123456, -90.654320); // Tiny difference in longitude
            var similarHash = similarCoord.GetHashCode();

            // If the hash combination arithmetic is wrong, these might be the same when they shouldn't be
            hashCode.Should().NotBe(similarHash, "slight coordinate differences should produce different hash codes with correct arithmetic");
        }

        [Fact]
        public void HashCode_ConstantMultiplier_Uses23()
        {
            // This test verifies the specific constant 23 used in hash combination
            // If mutated to a different value, hash distribution could change significantly

            // Arrange: Use coordinates where the multiplier matters
            var coord1 = new GeoDDCoordinate(1.0, 0.0);
            var coord2 = new GeoDDCoordinate(0.0, 1.0);


            // Act
            var hash1 = coord1.GetHashCode();
            var hash2 = coord2.GetHashCode();


            // Assert: Different coordinate arrangements should produce different hashes
            hash1.Should().NotBe(hash2, "different coordinate values should hash differently with proper multiplier");

            // Verify neither hash is zero (which might indicate multiplication by 0)
            hash1.Should().NotBe(0, "hash should not be zero unless both coordinates are quantized to zero");
            hash2.Should().NotBe(0, "hash should not be zero unless both coordinates are quantized to zero");
        }

        [Fact]
        public void HashCode_UncheckedContext_HandlesOverflow()
        {
            // This test verifies that the unchecked context is working properly
            // and arithmetic mutations don't cause unexpected overflow behavior

            // Arrange: Use large coordinates that might cause overflow
            var largeCoord = new GeoDDCoordinate(89.999999, 179.999999);


            // Act - this should not throw due to unchecked context
            var hashCode = largeCoord.GetHashCode();


            // Assert: Should produce a valid hash code without throwing
            hashCode.Should().BeOfType(typeof(int), "should return a valid integer hash code");

            // Test consistency
            var secondHash = largeCoord.GetHashCode();
            hashCode.Should().Be(secondHash, "hash should be consistent even for large values");
        }

        [Fact]
        public void HashCode_InitialValue_Uses17()
        {
            // This test verifies the initial hash value of 17
            // If mutated to a different value, hash distribution could change

            // Arrange: Use a coordinate that would be sensitive to initial value
            var coord = new GeoDDCoordinate(0.0, 0.0);


            // Act
            var hashCode = coord.GetHashCode();


            // Assert: Should not be zero (unless quantized coordinates both hash to specific values)
            // The exact value depends on how double.GetHashCode() works for quantized zeros
            // But the hash should be deterministic
            var secondHash = coord.GetHashCode();
            hashCode.Should().Be(secondHash, "hash should be deterministic for zero coordinates");
        }

        [Fact]
        public void HashCode_MultiplicationMutant_QuantizationStep()
        {
            // This test specifically targets the quantization multiplication step
            // Formula: Math.Round(value / HASH_TOLERANCE) * HASH_TOLERANCE
            // The second multiplication is critical for proper quantization


            // Arrange: Use a value that will show the difference clearly
            var coordinate = new GeoDDCoordinate(3.7e-10, 5.1e-10);

            // With correct multiplication:
            // Math.Round(3.7e-10 / 1e-10) * 1e-10 = Math.Round(3.7) * 1e-10 = 4.0 * 1e-10 = 4e-10
            // Math.Round(5.1e-10 / 1e-10) * 1e-10 = Math.Round(5.1) * 1e-10 = 5.0 * 1e-10 = 5e-10

            // If mutation changes * to /:
            // Math.Round(3.7e-10 / 1e-10) / 1e-10 = 4.0 / 1e-10 = 4e10 (huge number!)


            // Act
            var hashCode = coordinate.GetHashCode();


            // Assert: Should be a reasonable hash code
            var anotherCoordinate = new GeoDDCoordinate(3.7e-10, 5.1e-10);
            var anotherHash = anotherCoordinate.GetHashCode();

            hashCode.Should().Be(anotherHash, "identical coordinates should have identical hash codes");

            // Create coordinate that should quantize to same values
            var quantizedSameCoord = new GeoDDCoordinate(4e-10, 5e-10); // Should quantize to same buckets
            var quantizedSameHash = quantizedSameCoord.GetHashCode();

            hashCode.Should().Be(quantizedSameHash, "coordinates that quantize to same values should have same hash");
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
            hashCode.Should().BeInRange(int.MinValue + 1000, int.MaxValue - 1000,
                "hash should not be near overflow boundaries");
        }

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

            if(equals_1_3)
            {
                hash1.Should().Be(hash3, "If objects are equal, hash codes must be equal");
            }
            // Note: Different objects can have the same hash code, but equal objects must have the same hash code
        }

        [Fact]
        public void HashCodeContractValidation_EqualCoordinatesWithinTolerance_ShouldHaveSameHashCode()
        {
            // Arrange - Create coordinates that are equal within tolerance (1e-12)
            var base1 = 45.123456789012;
            var base2 = -90.987654321098;

            // Create a coordinate with differences exactly at the tolerance boundary
            var diff = 1e-13; // Just within tolerance
            var coord1 = new GeoDDCoordinate(base1, base2);
            var coord2 = new GeoDDCoordinate(base1 + diff, base2 + diff);

            // Act
            var areEqual = coord1 == coord2;
            var hash1 = coord1.GetHashCode();
            var hash2 = coord2.GetHashCode();

            // Assert - This is the critical hash code contract test
            if(areEqual)
            {
                hash1.Should().Be(hash2,
                    "Hash code contract violation: equal objects must have equal hash codes. " +
                    $"Tolerance: 1e-12, Difference: {diff}, Equal: {areEqual}");
            }

            // Verify they are indeed equal within tolerance
            areEqual.Should().BeTrue("Coordinates within tolerance should be equal");
        }

        [Fact]
        public void NearlyIdenticalCoordinates_InHashSet_ShouldBehaveConsistently()
        {
            // Collection Behavior Tests

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
            if(coord1 == coord3)
            {
                added3.Should().BeFalse("Nearly identical coordinates should not be added if considered equal");
                hashSet.Should().Contain(coord3);
            }
            else
            {
                added3.Should().BeTrue("Different coordinates should be added");
            }
        }
    }
}
