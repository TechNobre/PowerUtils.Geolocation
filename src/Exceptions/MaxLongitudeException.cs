namespace PowerUtils.Geolocation.Exceptions;

public class MaxLongitudeException : CoordinateException
{
    public MaxLongitudeException(double coordinate)
        : base($"The maximum longitude is {Constants.MAX_LONGITUDE}. Value '{coordinate}'") { }
}
