using System;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Exceptions;

[Serializable]
public abstract class CoordinateException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CoordinateException"></see> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    protected CoordinateException(string message)
        : base(message)
    { }

    /// <summary>
    /// Initializes a new instance of the exception class with serialized data.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
    /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
    protected CoordinateException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    { }
}
