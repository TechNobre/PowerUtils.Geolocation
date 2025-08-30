using System;
using FluentAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates
{
    public class GeoDDCoordinateTests
    {
        [Fact]
        public void ValidLatitudeLongitude_Constructor_Create()
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

        [Fact]
        public void LatitudeLongitudeString_Parse_GeoDDCoordinate()
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

        [Fact]
        public void NullLatitude_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(null, "12.442"));


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>()
                .Which.ParamName.Should()
                    .Be("ddPoint");
        }

        [Fact]
        public void NullLongitude_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse("12.442", null));


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>()
                .Which.ParamName.Should()
                    .Be("ddPoint");
        }

        [Fact]
        public void SmallLatitude_CreateGeoDDCoordinate_MinLatitudeException()
        {
            // Arrange & Act
            var act = Record.Exception(() => new GeoDDCoordinate(-90.1, 12));


            // Assert
            act.Should()
                .BeOfType<MinLatitudeException>();
        }

        [Fact]
        public void LargeLatitude_CreateGeoDDCoordinate_MaxLatitudeException()
        {
            // Arrange & Act
            var act = Record.Exception(() => new GeoDDCoordinate(90.1, 12));


            // Assert
            act.Should()
                .BeOfType<MaxLatitudeException>();
        }

        [Fact]
        public void SmallLongitude_CreateGeoDDCoordinate_MinLongitudeException()
        {
            // Arrange & Act
            var act = Record.Exception(() => new GeoDDCoordinate(12, -180.1));


            // Assert
            act.Should()
                .BeOfType<MinLongitudeException>();
        }

        [Fact]
        public void LargeLongitude_CreateGeoDDCoordinate_MaxLongitudeException()
        {
            // Arrange & Act
            var act = Record.Exception(() => new GeoDDCoordinate(12, 180.1));


            // Assert
            act.Should()
                .BeOfType<MaxLongitudeException>();
        }

        [Fact]
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

        [Fact]
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

        [Fact]
        public void EqualsProperties_ComparisonHashCodes_True()
        {
            // Arrange
            var left = new GeoDDCoordinate(1.54, 54.1272);
            var right = new GeoDDCoordinate(1.54, 54.1272);


            // Act
            var act = left.GetHashCode() == right.GetHashCode();


            // Assert
            act.Should()
                .BeTrue();
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
            act.Should()
                .BeFalse();
        }

        [Fact]
        public void GeoDDCoordinate_CastToString_DotAsDecimalSeparator()
        {
            // Arrange
            var coordinates = new GeoDDCoordinate(1.54, 5.1272);


            // Act
            var act = (string)coordinates;


            // Assert
            act.Should()
                .Be("1.54, 5.1272");
        }

        [Fact]
        public void RightValueNull_EqualsMethod_False()
        {
            // Arrange
            var left = new GeoDDCoordinate(81.54, -54.1272);
            GeoDDCoordinate right = null;


            // Act
            var act = left.Equals(right);


            // Assert
            act.Should()
                .BeFalse();
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
            act.Should()
                .BeTrue();
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
            act.Should()
                .BeFalse();
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
            act.Should()
                .BeFalse();
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
            act.Should()
                .BeTrue();
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
            act.Should()
                .BeFalse();
        }

        [Fact]
        public void DifferentCoordinates_DifferenceOperator_True()
        {
            // Arrange
            var left = new GeoDDCoordinate(1.54, 54.1272);
            var right = new GeoDDCoordinate(81.54, -54.1272);


            // Act
            var act = left != right;


            // Assert
            act.Should()
                .BeTrue();
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
            act.Should()
                .BeFalse();
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
            act.Should()
                .BeTrue();
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
            act.Should()
                .BeFalse();
        }

        [Fact]
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


        [Fact]
        public void NullCoordinate_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(null));


            // Assert
            act.Should()
                .BeOfType<ArgumentNullException>()
                .Which.ParamName.Should()
                    .Be("coordinate");
        }

        [Fact]
        public void DDCoordinateStringWithSpaces_Parse_GeoDDCoordinate()
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

        [Fact]
        public void WithMoreTwoCommas_Parse_InvalidCoordinateException()
        {
            // Arrange
            var coordinate = "81.54  , -54.1272  , -54.1272";


            // Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


            // Assert
            act.Should()
                .BeOfType<InvalidCoordinateException>();
        }

        [Fact]
        public void InvalidLatitude_Parse_InvalidCoordinateException()
        {
            // Arrange
            var coordinate = "81.54.1  , -54.1272";


            // Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


            // Assert
            act.Should()
                .BeOfType<InvalidCoordinateException>();
        }

        [Fact]
        public void AnyString_Cast_GeoDDCoordinate()
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

        [Fact]
        public void ValidCoordinate_TryParse_TrueAndGeoDDCoordinate()
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

        [Fact]
        public void InvalidCoordinate_TryParse_FalseAndNull()
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

        [Fact]
        public void ValidLatitudeAndLongitude_TryParse_TrueAndGeoDDCoordinate()
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

        [Fact]
        public void InvalidLatitude_TryParse_FalseAndNull()
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
}
