using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.GeoDDCoordinates
{
    public sealed class TryParseMethodTests
    {
        [Fact]
        public void ValidCoordinate_TryParse_TrueAndGeoDDCoordinate()
        {
            // Arrange
            var coordinate = "-12.51214,14.1272";


            // Act
            var act = GeoDDCoordinate.TryParse(coordinate, out var result);


            // Assert
            act.Should().BeTrue();
            result.Latitude.Should().Be(-12.51214);
            result.Longitude.Should().Be(14.1272);
        }

        [Fact]
        public void InvalidCoordinate_TryParse_FalseAndNull()
        {
            // Arrange
            var coordinate = "-12.51.214,14.1272";


            // Act
            var act = GeoDDCoordinate.TryParse(coordinate, out var result);


            // Assert
            act.Should().BeFalse();
            result.Should().BeNull();
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
            act.Should().BeTrue();
            result.Latitude.Should().Be(81.54);
            result.Longitude.Should().Be(-54.1272);
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
            act.Should().BeFalse();
            result.Should().BeNull();
        }
    }
}
