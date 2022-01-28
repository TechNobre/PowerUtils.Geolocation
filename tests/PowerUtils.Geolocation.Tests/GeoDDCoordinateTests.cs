using System;

namespace PowerUtils.Geolocation.Tests;

[Trait("Category", "GeoDDCoordinate")]
public class GeoDDCoordinateTests
{
    [Fact(DisplayName = "Create the GeoDDCoordinate - Should create object")]
    public void Constructor_ValidLatitudeLongitude_Create()
    {
        // Arrange
        var latitude = 81.54;
        var longitude = -54.1272;


        // Act
        var act = new GeoDDCoordinate(
            latitude,
            longitude
        );


        // Assert
        act.Latitude
            .Should()
                .Be(latitude);

        act.Longitude
            .Should()
                .Be(longitude);
    }

    [Fact(DisplayName = "Parse latitude longitude from strings - Should create object")]
    public void Parse_LatitudeLongitudeString_GeoDDCoordinate()
    {
        // Arrange
        var latitude = "81.54";
        var longitude = "-54.1272";


        // Act
        var act = GeoDDCoordinate.Parse(latitude, longitude);


        // Assert
        act.Latitude
            .Should()
                .Be(81.54);

        act.Longitude
            .Should()
                .Be(-54.1272);
    }

    [Fact(DisplayName = "Parse DD coordinate from strings with null latitude - Should return an 'ArgumentNullException'")]
    public void Parse_NullLatitude_ArgumentNullException()
    {
        // Arrange & Act
        var act = Record.Exception(() => GeoDDCoordinate.Parse(null, "12.442"));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>()
            .Which.ParamName.Should()
                .Be("ddPoint");
    }

    [Fact(DisplayName = "Parse DD coordinate from strings with null longitude - Should return an 'ArgumentNullException'")]
    public void Parse_NullLongitude_ArgumentNullException()
    {
        // Arrange & Act
        var act = Record.Exception(() => GeoDDCoordinate.Parse("12.442", null));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>()
            .Which.ParamName.Should()
                .Be("ddPoint");
    }

    [Fact(DisplayName = "Try a GeoDDCoordinate with a small latitude - Should return a 'MinLatitudeException'")]
    public void Latitude_Small_MinLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(-90.1, 12));


        // Assert
        act.Should()
            .BeOfType<MinLatitudeException>();
    }

    [Fact(DisplayName = "Try a GeoDDCoordinate with a large latitude - Should return a 'MaxLatitudeException'")]
    public void Latitude_Large_MaxLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(90.1, 12));


        // Assert
        act.Should()
            .BeOfType<MaxLatitudeException>();
    }

    [Fact(DisplayName = "Try a GeoDDCoordinate with a small longitude - Should return a 'MinLongitudeException'")]
    public void Longitude_Small_MinLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(12, -180.1));


        // Assert
        act.Should()
            .BeOfType<MinLongitudeException>();
    }

    [Fact(DisplayName = "Try a GeoDDCoordinate with a large longitude - Should return a 'MaxLongitudeException'")]
    public void Longitude_Large_MaxLatitudeException()
    {
        // Arrange & Act
        var act = Record.Exception(() => new GeoDDCoordinate(12, 180.1));


        // Assert
        act.Should()
            .BeOfType<MaxLongitudeException>();
    }

    [Fact(DisplayName = "Desconstruct a GeoDDCoordinate object - Should return the latitude and longitude")]
    public void GeoDDCoordinate_Deconstruct_LatitudeAndLongitude()
    {
        // Arrange
        var latitude = 81.54;
        var longitude = -54.1272;

        var coordinates = new GeoDDCoordinate(latitude, longitude);


        // Act
        (var actLatitude, var actLongitude) = coordinates;


        // Assert
        actLatitude.Should()
            .Be(latitude);

        actLongitude.Should()
            .Be(longitude);
    }

    [Fact(DisplayName = "Get coordinate from method toString() - Should return a string with dot as decimal separator")]
    public void Coordinate_ToString_DotAsDecimalSeparator()
    {
        // Arrange
        var coordinate = GeoDDCoordinate.Parse("12,152", "-8,12");


        // Act
        var act = coordinate.ToString();


        // Assert
        act.Should()
            .Be("12.152, -8.12");
    }

    [Fact(DisplayName = "Comparison of the hash codes, equals properties - Should return true")]
    public void ComparisonHashCodes_EqualsProperties_True()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(1.54, 54.1272);


        // Act
        var act = left.GetHashCode() == right.GetHashCode();


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Comparison of the hash codes, differents properties - Should return false")]
    public void ComparisonHashCodes_DifferentsProperties_False()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 5.1272);
        GeoDDCoordinate right = new(-1.54, 54.1272);


        // Act
        var act = left.GetHashCode() == right.GetHashCode();


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Cast a GeoDDCoordinate with implicit operator - Should return a string with dot as decimal separator")]
    public void ImplicitOperator_CastToString_DotAsDecimalSeparator()
    {
        // Arrange
        var coordinates = new GeoDDCoordinate(1.54, 5.1272);


        // Act
        var act = (string)coordinates;


        // Assert
        act.Should()
            .Be("1.54, 5.1272");
    }

    [Fact(DisplayName = "Equals method, other null - Should return false")]
    public void EqualsMethod_OtherNull_False()
    {
        // Arrange
        GeoDDCoordinate left = new(81.54, -54.1272);
        GeoDDCoordinate right = null;


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equals method, left and reight equals - Should return true")]
    public void EqualsMethod_LeftRightEquals_True()
    {
        // Arrange
        GeoDDCoordinate left = new(81.54, -54.1272);
        GeoDDCoordinate right = new(81.54, -54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equals method, left and reight differents - Should return false")]
    public void EqualsMethod_LeftRightDifferents_False()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(81.54, -54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equality operator, different coordinates - Should return false")]
    public void EqualityOperator_DifferentCoordinates_False()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(81.54, -54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }


    [Fact(DisplayName = "Equality operator, equals coordinates - Should return true")]
    public void EqualityOperator_EqualsCoordinates_True()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(1.54, 54.1272);


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equality operator, right null - Should return false")]
    public void EqualityOperator_RightNull_False()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = null;


        // Act
        var act = left == right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Difference operator, different coordinates - Should return true")]
    public void DifferenceOperator_DifferentCoordinates_True()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(81.54, -54.1272);


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeTrue();
    }


    [Fact(DisplayName = "Difference operator, equals coordinates - Should return false")]
    public void DifferenceOperator_EqualsCoordinates_False()
    {
        // Arrange
        GeoDDCoordinate left = new(1.54, 54.1272);
        GeoDDCoordinate right = new(1.54, 54.1272);


        // Act
        var act = left != right;


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Equals method, with object type but the same values - Should return true")]
    public void EqualsMethod_ObjectTypeEquals_True()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        object right = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeTrue();
    }

    [Fact(DisplayName = "Equals method, with object type but the different values - Should return false")]
    public void EqualsMethod_ObjectTypeDifferents_False()
    {
        // Arrange
        var left = new GeoDDCoordinate(1.54, 54.1272);
        object right = new GeoDDCoordinate(-1.54, 4.1272);


        // Act
        var act = left.Equals(right);


        // Assert
        act.Should()
            .BeFalse();
    }

    [Fact(DisplayName = "Clone the GeoDDCoordinate - Should return equals object")]
    public void GeoDDCoordinate_Clone_EqualsObject()
    {
        // Arrange
        var coordinate = new GeoDDCoordinate(1.54, 54.1272);


        // Act
        var act = coordinate.Clone() as GeoDDCoordinate;


        // Assert
        act.Latitude.Should()
            .Be(coordinate.Latitude);
        act.Longitude.Should()
            .Be(coordinate.Longitude);
    }


    [Fact(DisplayName = "Parse DD coordinate from strings with null latitude - Should return an 'ArgumentNullException'")]
    public void Parse_NullCoordinate_ArgumentNullException()
    {
        // Arrange & Act
        var act = Record.Exception(() => GeoDDCoordinate.Parse(null));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>()
            .Which.ParamName.Should()
                .Be("coordinate");
    }

    [Fact(DisplayName = "Parse DD coordinate from strings with spaces - Should create object")]
    public void Parse_DDCoordinateStringWithSpaces_GeoDDCoordinate()
    {
        // Arrange
        var coordinate = "81.54  , -54.1272";


        // Act
        var act = GeoDDCoordinate.Parse(coordinate);


        // Assert
        act.Latitude
            .Should()
                .Be(81.54);

        act.Longitude
            .Should()
                .Be(-54.1272);
    }

    [Fact(DisplayName = "Try parse a coordinate with more two commas - Should return 'InvalidCoordinateException'")]
    public void Parse_WithMoreTwoCommas_InvalidCoordinateException()
    {
        // Arrange
        var coordinate = "81.54  , -54.1272  , -54.1272";


        // Act
        var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


        // Assert
        act.Should()
            .BeOfType<InvalidCoordinateException>();
    }

    [Fact(DisplayName = "Try parse a coordinate with invalid latitude - Should return 'InvalidCoordinateException'")]
    public void Parse_InvalidLatitude_InvalidCoordinateException()
    {
        // Arrange
        var coordinate = "81.54.1  , -54.1272";


        // Act
        var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


        // Assert
        act.Should()
            .BeOfType<InvalidCoordinateException>();
    }

    [Fact(DisplayName = "Cast a string to GeoDDCoordinate - Should return a object GeoDDCoordinate")]
    public void Cast_FromString_GeoDDCoordinate()
    {
        // Arrange
        var coordinate = "-12.51214,14.1272";


        // Act
        var act = (GeoDDCoordinate)coordinate;


        // Assert
        act.Latitude
            .Should()
                .Be(-12.51214);

        act.Longitude
            .Should()
                .Be(14.1272);
    }

    [Fact(DisplayName = "Parse an Coordinate string - Should return a GeoDDCoordinate and bool")]
    public void TryParse_ValidCoordinate_TrueAndGeoDDCoordinate()
    {
        // Arrange
        var coordinate = "-12.51214,14.1272";


        // Act
        var act = GeoDDCoordinate.TryParse(coordinate, out var result);


        // Assert
        act.Should()
            .BeTrue();

        result.Latitude
            .Should()
                .Be(-12.51214);

        result.Longitude
            .Should()
                .Be(14.1272);
    }

    [Fact(DisplayName = "Try parse an Coordinate string with invalid coordinate - Should return null and bool")]
    public void TryParse_InvalidCoordinate_FalseAndNull()
    {
        // Arrange
        var coordinate = "-12.51.214,14.1272";


        // Act
        var act = GeoDDCoordinate.TryParse(coordinate, out var result);


        // Assert
        act.Should()
            .BeFalse();

        result.Should()
            .BeNull();
    }

    [Fact(DisplayName = "Parse an Coordinate string - Should return a GeoDDCoordinate and bool")]
    public void TryParse_ValidLatitudeAndLongitude_TrueAndGeoDDCoordinate()
    {
        // Arrange
        var latitude = "81.54";
        var longitude = "-54.1272";


        // Act
        var act = GeoDDCoordinate.TryParse(latitude, longitude, out var result);


        // Assert
        act.Should()
            .BeTrue();

        result.Latitude
            .Should()
                .Be(81.54);

        result.Longitude
            .Should()
                .Be(-54.1272);
    }

    [Fact(DisplayName = "Try parse an Coordinate string with invalid latitude - Should return null and bool")]
    public void TryParse_InvalidLatitude_FalseAndNull()
    {
        // Arrange
        var latitude = "81.54.1";
        var longitude = "-54.1272";


        // Act
        var act = GeoDDCoordinate.TryParse(latitude, longitude, out var result);


        // Assert
        act.Should()
            .BeFalse();

        result.Should()
            .BeNull();
    }
}
