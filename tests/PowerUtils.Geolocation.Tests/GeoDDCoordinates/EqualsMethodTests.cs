using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates;

public sealed class EqualsMethodTests
{
    [Fact]
    public void RightValueNull_EqualsMethod_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(81.54, -54.1272);
        GeoDDCoordinate right = null;


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void LeftAndRightEquals_EqualsMethod_True()
    {
        // Arrange
        var left = new GeoDDCoordinate(81.54, -54.1272);
        var right = new GeoDDCoordinate(81.54, -54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should().BeTrue();
    }

    [Fact]
    public void LeftAndRightDifferents_EqualsMethod_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        var right = new GeoDDCoordinate(81.54, -54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should().BeFalse();
    }

    [Fact]
    public void ObjectTypeEquals_EqualsMethod_True()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        object right = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should().BeTrue();
    }

    [Fact]
    public void ObjectTypeDifferents_EqualsMethod_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        object right = new GeoDDCoordinate(-1.54, 4.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should().BeFalse();
    }
}
