using System;

namespace PowerUtils.Geolocation.Exceptions;

public abstract class CoordinateException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateException"></see> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected CoordinateException(string message)
        : base(message)
    { }
}
