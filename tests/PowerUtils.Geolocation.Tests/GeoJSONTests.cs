namespace PowerUtils.Geolocation.Tests;

[Trait("Category", "GeoJSON")]
public class GeoJSONTests
{
    [Fact(DisplayName = "Construct GeoJSON from GeoDDCoordinate")]
    public void Construct_FromGeoDDCoordinate_GeoJSON()
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


    [Fact(DisplayName = "Cast from 'GeoDDCoordinate' to 'GeoJSON'")]
    public void ImplicitOperator_GeoDDCoordinate_GeoJSON()
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

    [Fact(DisplayName = "Cast from 'GeoJSON' to 'GeoDDCoordinate'")]
    public void ImplicitOperator_GeoJSON_GeoDDCoordinate()
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
