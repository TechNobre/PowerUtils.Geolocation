namespace PowerUtils.Geolocation.Exceptions;

public class InvalidCoordinateException : CoordinateException
{
    public InvalidCoordinateException(string coordinate)
        : base($"Coordinate '{coordinate}' is not formatted correctly") { }
}
