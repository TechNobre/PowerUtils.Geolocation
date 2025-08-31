namespace PowerUtils.Geolocation.Exceptions;

public class MinLatitudeException : CoordinateException
{
    public MinLatitudeException(double coordinate)
        : base($"The minimum latitude is {Constants.MIN_LATITUDE}. Value '{coordinate}'") { }
}
