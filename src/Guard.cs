using PowerUtils.Geolocation.Exceptions;

namespace PowerUtils.Geolocation;

public interface IGuardClauseGeolocation { }

public class GuardGeolocation : IGuardClauseGeolocation
{
    public static IGuardClauseGeolocation Against { get; } = new GuardGeolocation();

    private GuardGeolocation() { }
}



/// <summary>
/// Guard clause for latitude
/// </summary>
public static class GuardGeolocationClauseExtensions
{
    /// <summary>
    /// Throws an <see cref="MinLatitudeException" /> or <see cref="MaxLatitudeException" /> if <paramref name="degree"/> is out of range.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="degree">Latitude in degree</param>
    /// <exception cref="MinLatitudeException">The <paramref name="degree">degree</paramref> has a latitude is small.</exception>
    /// <exception cref="MaxLatitudeException">The <paramref name="degree">degree</paramref> has a latitude is large.</exception>
    /// <returns>Degree</returns>
    public static double Latitude(this IGuardClauseGeolocation _, double degree)
    {
        if(degree < Constants.MIN_LATITUDE)
        {
            throw new MinLatitudeException(degree);
        }

        if(degree > Constants.MAX_LATITUDE)
        {
            throw new MaxLatitudeException(degree);
        }

        return degree;
    }

    /// <summary>
    /// Throws an <see cref="MinLongitudeException" /> or <see cref="MaxLongitudeException" /> if <paramref name="degree"/> is out of range.
    /// </summary>
    /// <param name="_"></param>
    /// <param name="degree">Longitude in degree</param>
    /// <exception cref="MinLongitudeException">The <paramref name="degree">degree</paramref> has a longitude is small.</exception>
    /// <exception cref="MaxLongitudeException">The <paramref name="degree">degree</paramref> has a longitude is large.</exception>
    /// <returns>Degree</returns>
    public static double Longitude(this IGuardClauseGeolocation _, double degree)
    {
        if(degree < Constants.MIN_LONGITUDE)
        {
            throw new MinLongitudeException(degree);
        }

        if(degree > Constants.MAX_LONGITUDE)
        {
            throw new MaxLongitudeException(degree);
        }

        return degree;
    }
}
