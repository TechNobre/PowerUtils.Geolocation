namespace PowerUtils.Geolocation.Exceptions;

public class MaxLatitudeException : CoordinateException
{
    public MaxLatitudeException(double coordinate)
        : base($"The maximum latitude is {Constants.MAX_LATITUDE}. Value '{coordinate}'") { }
}
