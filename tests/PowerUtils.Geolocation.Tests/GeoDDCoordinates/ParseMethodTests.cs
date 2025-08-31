using System;
using FluentAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates
{

    public sealed class ParseMethodTests
    {
        [Fact]
        public void LatitudeLongitudeString_Parse_GeoDDCoordinate()
        {
            // Arrange
            var latitude = "81.54";
            var longitude = "-54.1272";


            // Act
            var act = GeoDDCoordinate.Parse(latitude, longitude);


            // Assert
            act.Latitude.Should().Be(81.54);
            act.Longitude.Should().Be(-54.1272);
        }

        [Fact]
        public void NullLatitude_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(null, "12.442"));


            // Assert
            act.Should().BeOfType<ArgumentNullException>()
                .Which.ParamName.Should().Be("ddPoint");
        }

        [Fact]
        public void NullLongitude_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse("12.442", null));


            // Assert
            act.Should().BeOfType<ArgumentNullException>()
                .Which.ParamName.Should().Be("ddPoint");
        }

        [Fact]
        public void NullCoordinate_Parse_ArgumentNullException()
        {
            // Arrange & Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(null));


            // Assert
            act.Should().BeOfType<ArgumentNullException>()
                .Which.ParamName.Should().Be("coordinate");
        }

        [Fact]
        public void DDCoordinateStringWithSpaces_Parse_GeoDDCoordinate()
        {
            // Arrange
            var coordinate = "81.54  , -54.1272";


            // Act
            var act = GeoDDCoordinate.Parse(coordinate);


            // Assert
            act.Latitude.Should().Be(81.54);
            act.Longitude.Should().Be(-54.1272);
        }

        [Fact]
        public void WithMoreTwoCommas_Parse_InvalidCoordinateException()
        {
            // Arrange
            var coordinate = "81.54  , -54.1272  , -54.1272";


            // Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


            // Assert
            act.Should().BeOfType<InvalidCoordinateException>();
        }

        [Fact]
        public void InvalidLatitude_Parse_InvalidCoordinateException()
        {
            // Arrange
            var coordinate = "81.54.1  , -54.1272";


            // Act
            var act = Record.Exception(() => GeoDDCoordinate.Parse(coordinate));


            // Assert
            act.Should().BeOfType<InvalidCoordinateException>();
        }
    }
}
