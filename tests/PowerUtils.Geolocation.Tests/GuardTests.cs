using FluentAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests
{
    public class GuardTests
    {
        [Fact]
        public void Small_AgainstLatitude_MinLatitudeException()
        {
            // Arrange
            var degree = -180.1;

            // Act
            var act = Record.Exception(() => GuardGeolocation.Against.Latitude(degree));


            // Assert
            act.Should()
                .BeOfType<MinLatitudeException>();
        }

        [Fact]
        public void Large_AgainstLatitude_MaxLatitudeException()
        {
            // Arrange
            var degree = 180.1;

            // Act
            var act = Record.Exception(() => GuardGeolocation.Against.Latitude(degree));


            // Assert
            act.Should()
                .BeOfType<MaxLatitudeException>();
        }

        [Fact]
        public void Valid_AgainstLatitude_NotException()
        {
            // Arrange
            var degree = 18.1;

            // Act
            var act = GuardGeolocation.Against.Latitude(degree);


            // Assert
            act.Should()
                .Be(degree);
        }

        [Fact]
        public void SmallLongitude_AgainstLongitude_MinLongitudeException()
        {
            // Arrange
            var degree = -180.1;

            // Act
            var act = Record.Exception(() => GuardGeolocation.Against.Longitude(degree));


            // Assert
            act.Should()
                .BeOfType<MinLongitudeException>();
        }

        [Fact]
        public void LargeLongitude_AgainstLongitude_MaxLongitudeException()
        {
            // Arrange
            var degree = 180.1;

            // Act
            var act = Record.Exception(() => GuardGeolocation.Against.Longitude(degree));


            // Assert
            act.Should()
                .BeOfType<MaxLongitudeException>();
        }

        [Fact]
        public void ValidLongitude_AgainstLongitude_NotException()
        {
            // Arrange
            var degree = 18.1;

            // Act
            var act = GuardGeolocation.Against.Longitude(degree);


            // Assert
            act.Should()
                .Be(degree);
        }
    }
}
