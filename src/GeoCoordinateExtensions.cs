namespace PowerUtils.Geolocation;

public static class GeoCoordinateExtensions
{
    /// <summary>
    /// Calculate Distance between two coordinates (Meter). Using the formula Haversine Formula.
    /// </summary>
    /// <param name="coordinate1">GeoDDCoordinate 1</param>
    /// <param name="coordinate2">GeoDDCoordinate 2</param>
    /// <param name="decimals">The number of decimal places in the return distance (Default: 0)</param>
    /// <returns>Distance in Meters</returns>
    public static double Distance(this GeoDDCoordinate coordinate1, GeoDDCoordinate coordinate2, int decimals = 0)
        => GeoDDCoordinate.Distance(
            coordinate1.Latitude, coordinate1.Longitude,
            coordinate2.Latitude, coordinate2.Longitude,
            decimals
        );
}
