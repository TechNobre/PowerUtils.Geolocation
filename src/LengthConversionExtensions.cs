using PowerUtils.Geolocation.Types;

namespace PowerUtils.Geolocation;

public static class LengthConversionExtensions
{
    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static int FromKilometerToMeter(this int length)
        => length * 1_000;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static uint FromKilometerToMeter(this uint length)
        => length * 1_000u;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static long FromKilometerToMeter(this long length)
        => length * 1_000L;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static ulong FromKilometerToMeter(this ulong length)
        => length * 1_000uL;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static float FromKilometerToMeter(this float length)
        => length * 1_000f;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static double FromKilometerToMeter(this double length)
        => length * 1_000d;

    /// <summary>
    /// Convert kilometers to meters
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in meters</returns>
    public static decimal FromKilometerToMeter(this decimal length)
        => length * 1_000m;

    /// <summary>
    /// Convert kilometers to miles
    /// </summary>
    /// <param name="length">Length in kilomiles</param>
    /// <returns>Length in miles</returns>
    public static float FromKilometerToMile(this float length)
        => length * 0.621_371f;

    /// <summary>
    /// Convert kilometers to miles
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in miles</returns>
    public static double FromKilometerToMile(this double length)
        => length * 0.621_371d;

    /// <summary>
    /// Convert kilometers to miles
    /// </summary>
    /// <param name="length">Length in kilometers</param>
    /// <returns>Length in miles</returns>
    public static decimal FromKilometerToMile(this decimal length)
        => length * 0.621_371m;

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
                return length.FromKilometerToMeter();
            case DistanceUnit.Mile:
                return length.FromKilometerToMile();
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
                return length.FromKilometerToMeter();
            case DistanceUnit.Mile:
                return length.FromKilometerToMile();
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
                return length.FromKilometerToMeter();
            case DistanceUnit.Mile:
                return length.FromKilometerToMile();
            case DistanceUnit.kilometer:
            default:
                return length;
        }
    }

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static int FromMeterToKilometer(this int length)
        => length / 1_000;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static uint FromMeterToKilometer(this uint length)
        => length / 1_000u;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static long FromMeterToKilometer(this long length)
        => length / 1_000L;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static ulong FromMeterToKilometer(this ulong length)
        => length / 1_000uL;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static float FromMeterToKilometer(this float length)
        => length / 1_000f;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static double FromMeterToKilometer(this double length)
        => length / 1_000d;

    /// <summary>
    /// Convert meters to kilometers
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in kilometers</returns>
    public static decimal FromMeterToKilometer(this decimal length)
        => length / 1_000m;

    /// <summary>
    /// Convert meters to miles
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in miles</returns>
    public static float FromMeterToMile(this float length)
        => length * 0.000_621_371f;

    /// <summary>
    /// Convert meters to miles
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in miles</returns>
    public static double FromMeterToMile(this double length)
        => length * 0.000_621_371d;

    /// <summary>
    /// Convert meters to miles
    /// </summary>
    /// <param name="length">Length in meters</param>
    /// <returns>Length in miles</returns>
    public static decimal FromMeterToMile(this decimal length)
        => length * 0.000_621_371m;

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
                return length.FromMeterToKilometer();
            case DistanceUnit.Mile:
                return length.FromMeterToMile();
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
                return length.FromMeterToKilometer();
            case DistanceUnit.Mile:
                return length.FromMeterToMile();
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
                return length.FromMeterToKilometer();
            case DistanceUnit.Mile:
                return length.FromMeterToMile();
            case DistanceUnit.Meter:
            default:
                return length;
        }
    }


    /// <summary>
    /// Convert miles to meters
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in meters</returns>
    public static float FromMileToMeter(this float length)
        => length * 1_609.34f;

    /// <summary>
    /// Convert miles to meters
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in meters</returns>
    public static double FromMileToMeter(this double length)
        => length * 1_609.34d;

    /// <summary>
    /// Convert miles to meters
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in meters</returns>
    public static decimal FromMileToMeter(this decimal length)
        => length * 1_609.34m;

    /// <summary>
    /// Convert miles to kilometers
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in kilometers</returns>
    public static float FromMileToKilometer(this float length)
        => length * 1.60_934f;

    /// <summary>
    /// Convert miles to kilometers
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in kilometers</returns>
    public static double FromMileToKilometer(this double length)
        => length * 1.60_934d;

    /// <summary>
    /// Convert miles to kilometers
    /// </summary>
    /// <param name="length">Length in miles</param>
    /// <returns>Length in kilometers</returns>
    public static decimal FromMileToKilometer(this decimal length)
        => length * 1.60_934m;

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
                return length.FromMileToKilometer();
            case DistanceUnit.Meter:
                return length.FromMileToMeter();
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
                return length.FromMileToKilometer();
            case DistanceUnit.Meter:
                return length.FromMileToMeter();
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
                return length.FromMileToKilometer();
            case DistanceUnit.Meter:
                return length.FromMileToMeter();
            case DistanceUnit.Mile:
            default:
                return length;
        }
    }
}
