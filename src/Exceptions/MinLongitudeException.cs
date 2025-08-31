namespace PowerUtils.Geolocation.Exceptions;

public class MinLongitudeException : CoordinateException
{
    public MinLongitudeException(double coordinate)
        : base($"The minimum longitude is {Constants.MIN_LONGITUDE}. Value '{coordinate}'") { }
}
