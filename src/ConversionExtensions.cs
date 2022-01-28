using System;
using System.Text;
using PowerUtils.Geolocation.Exceptions;
using PowerUtils.Geolocation.Types;

namespace PowerUtils.Geolocation
{
    public static class ConversionExtensions
    {
        /// <summary>
        /// Convert kilometers to a new unit
        /// </summary>
        /// <param name="length">Length in kilometers</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static double FromKilometerTo(this double length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.Meter:
                    return length * 1_000;
                case DistanceUnit.Mile:
                    return length * 0.621_371;
                case DistanceUnit.kilometer:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert kilometers to a new unit
        /// </summary>
        /// <param name="length">Length in kilometers</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static decimal FromKilometerTo(this decimal length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.Meter:
                    return length * 1_000;
                case DistanceUnit.Mile:
                    return length * 0.621_371m;
                case DistanceUnit.kilometer:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert kilometers to a new unit
        /// </summary>
        /// <param name="length">Length in kilometers</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static float FromKilometerTo(this float length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.Meter:
                    return length * 1_000;
                case DistanceUnit.Mile:
                    return length * 0.621_371f;
                case DistanceUnit.kilometer:
                default:
                    return length;
            }
        }



        /// <summary>
        /// Convert meters to a new unit
        /// </summary>
        /// <param name="length">Length in meters</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static double FromMeterTo(this double length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length * 0.001;
                case DistanceUnit.Mile:
                    return length * 0.000_621_371;
                case DistanceUnit.Meter:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert meters to a new unit
        /// </summary>
        /// <param name="length">Length in meters</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static decimal FromMeterTo(this decimal length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length / 1_000;
                case DistanceUnit.Mile:
                    return length * 0.000_621_371m;
                case DistanceUnit.Meter:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert meters to a new unit
        /// </summary>
        /// <param name="length">Length in meters</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static float FromMeterTo(this float length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length / 1_000;
                case DistanceUnit.Mile:
                    return length * 0.000_621_371f;
                case DistanceUnit.Meter:
                default:
                    return length;
            }
        }



        /// <summary>
        /// Convert miles to a new unit
        /// </summary>
        /// <param name="length">Length in miles</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static double FromMileTo(this double length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length * 1.60_934;
                case DistanceUnit.Meter:
                    return length * 1_609.34;
                case DistanceUnit.Mile:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert miles to a new unit
        /// </summary>
        /// <param name="length">Length in miles</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static decimal FromMileTo(this decimal length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length * 1.60_934m;
                case DistanceUnit.Meter:
                    return length * 1_609.34m;
                case DistanceUnit.Mile:
                default:
                    return length;
            }
        }

        /// <summary>
        /// Convert miles to a new unit
        /// </summary>
        /// <param name="length">Length in miles</param>
        /// <param name="unit">New unit</param>
        /// <returns>New length</returns>
        public static float FromMileTo(this float length, DistanceUnit unit)
        {
            switch(unit)
            {
                case DistanceUnit.kilometer:
                    return length * 1.60_934f;
                case DistanceUnit.Meter:
                    return length * 1_609.34f;
                case DistanceUnit.Mile:
                default:
                    return length;
            }
        }



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
}
