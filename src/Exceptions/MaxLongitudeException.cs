using System;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Exceptions;

[Serializable]
public class MaxLongitudeException : CoordinateException
{
    public MaxLongitudeException(double coordinate)
        : base($"The maximum longitude is {Constants.MAX_LONGITUDE}. Value '{coordinate}'") { }

    /// <summary>
    /// Initializes a new instance of the exception class with serialized data.
    /// </summary>
    /// <param name="info">The <see cref="SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
    /// <param name="context">The <see cref="StreamingContext"></see> that contains contextual information about the source or destination.</param>
    /// <exception cref="ArgumentNullException">The <paramref name="info">info</paramref> parameter is null.</exception>
    /// <exception cref="SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0).</exception>
    protected MaxLongitudeException(SerializationInfo info, StreamingContext context)
       : base(info, context)
    { }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        if(info == null)
        {
            throw new ArgumentNullException(nameof(info));
        }

        base.GetObjectData(info, context);
    }
}
