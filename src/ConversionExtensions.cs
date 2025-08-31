using System;
using System.Text;
using PowerUtils.Geolocation.Exceptions;
using PowerUtils.Geolocation.Types;

namespace PowerUtils.Geolocation;

public static class ConversionExtensions
{
    /// <summary>
    /// Get the geographical orientation from a specific cardinal direction
    /// </summary>
    /// <param name="cardinalDirection">Cardinal direction</param>
    /// <returns>Geographical orientation</returns>
    public static GeographicalOrientation GetGeographicalOrientation(this CardinalDirection cardinalDirection)
    {
        if(cardinalDirection == CardinalDirection.North || cardinalDirection == CardinalDirection.South)
        {
            return GeographicalOrientation.Longitude;
        }

        return GeographicalOrientation.Latitude;
    }



    /// <summary>
    /// Convert degree to radian (PI / 180)
    /// </summary>
    /// <param name="degree">Degrees</param>
    /// <returns>Radian</returns>
    public static double ToRadian(this double degree)
        => degree * (Math.PI / 180);

    /// <summary>
    /// Convert radian to degree (180 / PI)
    /// </summary>
    /// <param name="radian"></param>
    /// <returns>Degree</returns>
    public static double ToDegree(this double radian)
        => radian * (180 / Math.PI);



    /// <summary>
    /// Convert decimal degree point (string) to decimal degree point (double)
    /// </summary>
    /// <param name="ddPoint">Decimal degree point (string)</param>
    /// <returns>Decimal degree point (double)</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="ddPoint">ddPoint</paramref> parameter is null.</exception>
    /// <exception cref="InvalidCoordinateException">The <paramref name="ddPoint">ddPoint</paramref> is not formatted correctly.</exception>
    public static double ToDDPoint(this string ddPoint)
    {
        if(ddPoint == null)
        {
            throw new ArgumentNullException(nameof(ddPoint), "The value cannot be null");
        }

        var aux = ddPoint.Split(new char[] { '.', ',' });

        try
        {
            if(aux.Length == 1)
            {
                return double.Parse(aux[0].Replace(" ", ""));
            }

            if(aux.Length == 2)
            {
                var sb = new StringBuilder();
                sb.Append(aux[0].Replace(" ", ""));
                sb.Append(System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                sb.Append(aux[1]);

                return double.Parse(sb.ToString());
            }

            throw new InvalidCoordinateException(ddPoint);
        }
        catch
        {
            throw new InvalidCoordinateException(ddPoint);
        }
    }
}
