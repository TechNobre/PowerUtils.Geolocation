namespace PowerUtils.Geolocation.Tests;

[Trait("Type", "Guard")]
public class GuardTests
{
    [Fact(DisplayName = "Throw an 'MinLatitudeException' when the degree is small")]
    public void Latitude_Small_MinLatitudeException()
    {
        // Arrange
        var degree = -180.1;

        // Act
        var act = Record.Exception(() => GuardGeolocation.Against.Latitude(degree));


        // Assert
        act.Should()
            .BeOfType<MinLatitudeException>();
    }

    [Fact(DisplayName = "Throw an 'MaxLatitudeException' when the degree is large")]
    public void Latitude_Large_MaxLatitudeException()
    {
        // Arrange
        var degree = 180.1;

        // Act
        var act = Record.Exception(() => GuardGeolocation.Against.Latitude(degree));


        // Assert
        act.Should()
            .BeOfType<MaxLatitudeException>();
    }

    [Fact(DisplayName = "Validate latitude with valid degree - Should return the degree")]
    public void Latitude_Valid_NotException()
    {
        // Arrange
        var degree = 18.1;

        // Act
        var act = GuardGeolocation.Against.Latitude(degree);


        // Assert
        act.Should()
            .Be(degree);
    }



    [Fact(DisplayName = "Throw an 'MinLongitudeException' when the degree is small")]
    public void Longitude_Small_MinLongitudeException()
    {
        // Arrange
        var degree = -180.1;

        // Act
        var act = Record.Exception(() => GuardGeolocation.Against.Longitude(degree));


        // Assert
        act.Should()
            .BeOfType<MinLongitudeException>();
    }

    [Fact(DisplayName = "Throw an 'MaxLongitudeException' when the degree is large")]
    public void Longitude_Large_MaxLongitudeException()
    {
        // Arrange
        var degree = 180.1;

        // Act
        var act = Record.Exception(() => GuardGeolocation.Against.Longitude(degree));


        // Assert
        act.Should()
            .BeOfType<MaxLongitudeException>();
    }

    [Fact(DisplayName = "Validate longitude with valid degree - Should return the degree")]
    public void Longitude_Valid_NotException()
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
