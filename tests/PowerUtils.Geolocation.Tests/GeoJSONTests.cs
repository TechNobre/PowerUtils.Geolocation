namespace PowerUtils.Geolocation.Tests;

public class GeoJSONTests
{
    [Fact]
    public void GeoDDCoordinate_Construct_GeoJSON()
    {
        // Arrange
        var coordinate = new GeoDDCoordinate(9.1, 12);


        // Act
        var act = new GeoJSON(coordinate);


        // Assert
        act.Type.Should()
            .Be("Point");
        act.Coordinate[0].Should()
            .Be(coordinate.Longitude);
        act.Coordinate[1].Should()
            .Be(coordinate.Latitude);
    }


    [Fact]
    public void GeoDDCoordinate_ImplicitOperator_GeoJSON()
    {
        // Arrange
        var coordinate = new GeoDDCoordinate(9.1, 12);


        // Act
        var act = (GeoJSON)coordinate;


        // Assert
        act.Type.Should()
            .Be("Point");
        act.Coordinate[0].Should()
            .Be(coordinate.Longitude);
        act.Coordinate[1].Should()
            .Be(coordinate.Latitude);
    }

    [Fact]
    public void GeoJSON_ImplicitOperator_GeoDDCoordinate()
    {
        // Arrange
        var coordinate = new GeoDDCoordinate(9.1, 12);
        var geoJSON = (GeoJSON)coordinate;


        // Act
        var act = (GeoDDCoordinate)geoJSON;


        // Assert
        act.Latitude.Should()
            .Be(geoJSON.Coordinate[1]);
        act.Longitude.Should()
            .Be(geoJSON.Coordinate[0]);
    }
}
