namespace PowerUtils.Geolocation
{
    /// <summary>
    /// GeoJSON
    /// </summary>
    public class GeoJSON : IGeoCoordinate
    {
        public const string TYPE = "Point";

        public string Type => TYPE;


        public double[] Coordinate { get; private set; }


        public GeoJSON(GeoDDCoordinate coordinate)
            => Coordinate = new double[] { coordinate.Longitude, coordinate.Latitude };



        #region IMPLICIT OPERATOR
        public static implicit operator GeoJSON(GeoDDCoordinate coordinate)
            => new GeoJSON(coordinate);


        public static implicit operator GeoDDCoordinate(GeoJSON coordinate)
            => new GeoDDCoordinate(coordinate.Coordinate[1], coordinate.Coordinate[0]);
        #endregion
    }
}
