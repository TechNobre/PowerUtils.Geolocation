using FluentAssertions;
using Xunit;

namespace PowerUtils.Geolocation.Tests
{
    public class GeoCoordinateExtensionsTests
    {
        [Theory]
        [InlineData(37.165611, -8.545786, 38.737545, -9.370047, 189143)]
        [InlineData(37.129265, -8.591591, 37.121451, -8.564714, 2536)]
        [InlineData(37.068673, -7.939493, 37.098708, -8.145107, 18543)]
        [InlineData(38.8976, -77.0366, 39.9496, -75.1503, 199832)]
        [InlineData(-38.8976, -77.0366, 39.9496, -75.1503, 8769606)]
        public void DDCoordinates_Distance_ZeroDecimalPlaces(double latitude1, double longitude1, double latitude2, double longitude2, double distance)
        {
            // Arrange
            var left = new GeoDDCoordinate(latitude1, longitude1);
            var right = new GeoDDCoordinate(latitude2, longitude2);


            // Act
            var act = left.Distance(right);


            // Assert
            act.Should()
                .Be(distance);
        }

        [Theory]
        [InlineData(37.165611, -8.545786, 38.737545, -9.370047, 189142.70429223822)]
        [InlineData(37.129265, -8.591591, 37.121451, -8.564714, 2536.3488457288508)]
        [InlineData(37.068673, -7.939493, 37.098708, -8.145107, 18542.719416538552)]
        public void Calculates_PreciseDistance_Distance(double latitude1, double longitude1, double latitude2, double longitude2, double distance)
        {
            // Arrange & Act
            var act = GeoDDCoordinate.PreciseDistance(latitude1, longitude1, latitude2, longitude2);


            // Assert
            act.Should()
                .Be(distance);
        }
    }
}
