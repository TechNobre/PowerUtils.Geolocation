using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates
{
    public sealed class OperatorDifferenceTests
    {
        [Fact]
        public void DifferentCoordinates_DifferenceOperator_True()
        {
            // Arrange
            var left = new GeoDDCoordinate(1.54, 54.1272);
            var right = new GeoDDCoordinate(81.54, -54.1272);


            // Act
            var act = left != right;


            // Assert
            act.Should().BeTrue();
        }


        [Fact]
        public void EqualsCoordinates_DifferenceOperator_False()
        {
            // Arrange
            var left = new GeoDDCoordinate(1.54, 54.1272);
            var right = new GeoDDCoordinate(1.54, 54.1272);


            // Act
            var act = left != right;


            // Assert
            act.Should().BeFalse();
        }
    }
}
