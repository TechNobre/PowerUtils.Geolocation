using System;
using PowerUtils.Geolocation.Exceptions;

#if NET462 || NET48 || NETSTANDARD2_0 || NETSTANDARD2_1
using Newtonsoft.Json;
#else
using System.Text.Json.Serialization;
#endif

namespace PowerUtils.Geolocation
{
    /// <summary>
    /// Decimal degree coordinate
    /// </summary>
    public class GeoDDCoordinate :
        IGeoCoordinate,
        IEquatable<GeoDDCoordinate>,
        ICloneable
    {
        public double Latitude => Coordinate[0];
        public double Longitude => Coordinate[1];

        [JsonIgnore]
        public double[] Coordinate { get; private set; }

        #region CONSTRUCTOR & DECONSTRUCT
        /// <summary>
        /// Create a GeoDDCoordinate
        /// </summary>
        /// <param name="latitude">Degree for latitude</param>
        /// <param name="longitude">Degree for longitude</param>
        /// <exception cref="MinLatitudeException">The <paramref name="latitude">latitude</paramref> has a latitude is small.</exception>
        /// <exception cref="MaxLatitudeException">The <paramref name="latitude">latitude</paramref> has a latitude is large.</exception>
        /// <exception cref="MinLongitudeException">The <paramref name="longitude">longitude</paramref> has a longitude is small.</exception>
        /// <exception cref="MaxLongitudeException">The <paramref name="longitude">longitude</paramref> has a longitude is large.</exception>
        public GeoDDCoordinate(double latitude, double longitude)
            => Coordinate = new double[]
            {
                GuardGeolocation.Against.Latitude(latitude),
                GuardGeolocation.Against.Longitude(longitude)
            };

        /// <summary>
        /// Deconstruct GeoDDCoordinate to double latitude and double longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public void Deconstruct(out double latitude, out double longitude)
        { // DONE
            latitude = Latitude;
            longitude = Longitude;
        }

        /// <summary>
        /// Create a new object 'GeoDDCoordinate' with the same data
        /// </summary>
        /// <returns></returns>
        public object Clone()
            => new GeoDDCoordinate(Latitude, Longitude);
        #endregion



        #region OVERRIDES
        public override string ToString()
            => $"{_formatString(Latitude)}, {_formatString(Longitude)}";

        public override int GetHashCode()
            => Latitude.GetHashCode() * Longitude.GetHashCode();
        #endregion



        #region COMPARISON
        public static bool operator ==(GeoDDCoordinate left, GeoDDCoordinate right)
        {
            if(right is null)
            {
                return false;
            }

            if(
                left.Latitude == right.Latitude
                &&
                left.Longitude == right.Longitude
            )
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(GeoDDCoordinate left, GeoDDCoordinate right)
            => !(left == right);

        public virtual bool Equals(GeoDDCoordinate other)
        {
            if(other is null)
            {
                return false;
            }

            return this == other;
        }

        public override bool Equals(object obj)
            => Equals(obj as GeoDDCoordinate);
        #endregion



        #region IMPLICIT OPERATOR
        public static implicit operator string(GeoDDCoordinate coordinate)
            => coordinate.ToString();

        public static implicit operator GeoDDCoordinate(string coordinate)
            => GeoDDCoordinate.Parse(coordinate);
        #endregion



        #region PARSES
        /// <summary>
        /// Create a GeoDDCoordinate from latitude and longitude strings
        /// </summary>
        /// <param name="latitude">Degree for latitude</param>
        /// <param name="longitude">Degree for longitude</param>
        /// <exception cref="ArgumentNullException">The <paramref name="latitude">latitude</paramref> parameter is null.</exception>
        /// <exception cref="ArgumentNullException">The <paramref name="longitude">longitude</paramref> parameter is null.</exception>
        /// <exception cref="InvalidCoordinateException">The <paramref name="latitude">latitude</paramref> is not formatted correctly.</exception>
        /// <exception cref="InvalidCoordinateException">The <paramref name="longitude">longitude</paramref> is not formatted correctly.</exception>
        /// <exception cref="MinLatitudeException">The <paramref name="latitude">latitude</paramref> has a latitude is small.</exception>
        /// <exception cref="MaxLatitudeException">The <paramref name="latitude">latitude</paramref> has a latitude is large.</exception>
        /// <exception cref="MinLongitudeException">The <paramref name="longitude">longitude</paramref> has a longitude is small.</exception>
        /// <exception cref="MaxLongitudeException">The <paramref name="longitude">longitude</paramref> has a longitude is large.</exception>
        /// <returns>GeoDDCoordinate</returns>
        public static GeoDDCoordinate Parse(string latitude, string longitude)
        {
            var dLatitude = GuardGeolocation.Against
                .Latitude(latitude.ToDDPoint());

            var dLongitude = GuardGeolocation.Against
                .Longitude(longitude.ToDDPoint());


            return new GeoDDCoordinate(dLatitude, dLongitude);
        }

        /// <summary>
        /// Create a GeoDDCoordinate from strings
        /// </summary>
        /// <param name="coordinate">GeoDDCoordinate</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The <paramref name="coordinate">coordinate</paramref> parameter is null.</exception>
        /// <exception cref="InvalidCoordinateException">The <paramref name="coordinate">coordinate</paramref> is not formatted correctly.</exception>
        public static GeoDDCoordinate Parse(string coordinate)
        {
            if(coordinate == null)
            {
                throw new ArgumentNullException(nameof(coordinate));
            }


            var aux = coordinate.Split(',');
            if(aux.Length == 2)
            {
                try
                {
                    var latitude = aux[0].ToDDPoint();
                    var longitude = aux[1].ToDDPoint();

                    return new GeoDDCoordinate(latitude, longitude);
                }
                catch
                {
                    throw new InvalidCoordinateException(coordinate);
                }
            }
            else
            {
                throw new InvalidCoordinateException(coordinate);
            }
        }

        /// <summary>
        /// Create a GeoDDCoordinate from latitude and longitude strings
        /// </summary>
        /// <param name="latitude">Degree for latitude</param>
        /// <param name="longitude">Degree for longitude</param>
        /// <param name="result">Object GeoDDCoordinate with result</param>
        /// <returns>True if parsed successfully</returns>
        public static bool TryParse(string latitude, string longitude, out GeoDDCoordinate result)
        {
            try
            {
                result = GeoDDCoordinate.Parse(latitude, longitude);

                return true;
            }
            catch
            {
                result = null;

                return false;
            }
        }

        /// <summary>
        /// Create a GeoDDCoordinate from strings
        /// </summary>
        /// <param name="coordinate">String coordinate to parse</param>
        /// <param name="result">Object GeoDDCoordinate with result</param>
        /// <returns>True if parsed successfully</returns>
        public static bool TryParse(string coordinate, out GeoDDCoordinate result)
        {
            try
            {
                result = GeoDDCoordinate.Parse(coordinate);

                return true;
            }
            catch
            {
                result = null;

                return false;
            }
        }
        #endregion



        #region DISTANCE METHODS
        /// <summary>
        /// Calculate Distance between two coordinates (Meter). Using the formula Haversine Formula.
        /// </summary>
        /// <param name="latitude1">Latitude 1</param>
        /// <param name="longitude1">Longitude 1</param>
        /// <param name="latitude2">Latitude 2</param>
        /// <param name="longitude2">Longitude 2</param>
        /// <param name="decimals">The number of decimal places in the return distance (Default: 0)</param>
        /// <returns>Distance in Meters</returns>
        public static double Distance(double latitude1, double longitude1, double latitude2, double longitude2, int decimals = 0)
            => Math.Round(PreciseDistance(
                    latitude1, longitude1,
                    latitude2, longitude2
                ), decimals);

        /// <summary>
        /// Calculate Distance between two coordinates (Meter) without round. Using the formula Haversine Formula.
        /// </summary>
        /// <param name="latitude1">Latitude 1</param>
        /// <param name="longitude1">Longitude 1</param>
        /// <param name="latitude2">Latitude 2</param>
        /// <param name="longitude2">Longitude 2</param>
        /// <returns>Distance in Meters</returns>
        public static double PreciseDistance(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var latitude1Radian = latitude1.ToRadian();
            var longitude1Radian = longitude1.ToRadian();
            var latitude2Radian = latitude2.ToRadian();
            var longitude2Radian = longitude2.ToRadian();

            var deltaLongitude = longitude2Radian - longitude1Radian;
            var deltaLatitude = latitude2Radian - latitude1Radian;

            // Intermediate result a.
            var step1 = Math.Pow(Math.Sin(deltaLatitude / 2.0), 2.0) +
                        Math.Cos(latitude1Radian) * Math.Cos(latitude2Radian) *
                        Math.Pow(Math.Sin(deltaLongitude / 2.0), 2.0);


            // Intermediate result c (great circle distance in Radians)
            var step2 = 2.0 * Math.Atan2(Math.Sqrt(step1), Math.Sqrt(1.0 - step1));


            return Constants.EARTH_RADIUS_METER * step2;
        }
        #endregion



        private static string _formatString(double degree)
            => degree.ToString().Replace(",", ".");
    }
}
