namespace PowerUtils.Geolocation;

public static class Constants
{
    public const double MAX_LATITUDE = 90;
    public const double MIN_LATITUDE = MAX_LATITUDE * -1;

    public const double MAX_LONGITUDE = 180;
    public const double MIN_LONGITUDE = MAX_LONGITUDE * -1;


    // https://cloud.google.com/blog/products/maps-platform/how-calculate-distances-map-maps-javascript-api
    // https://en.wikipedia.org/wiki/Earth_radius
    // It is the radius of a spherical Earth
    public const double EARTH_RADIUS_KILOMETER = 6371.071;
    public const double EARTH_RADIUS_METER = 6371071;
}
