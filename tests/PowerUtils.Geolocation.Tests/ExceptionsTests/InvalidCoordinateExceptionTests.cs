using System;
using System.IO;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class InvalidCoordinateExceptionTests
{
    [Fact]
    public void InvalidCoordinateException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new InvalidCoordinateException("1..12");


        // Act
        Exception act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(InvalidCoordinateException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (InvalidCoordinateException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);
    }

    [Fact]
    public void NullInfo_GetObjectData_ArgumentNullException()
    {
        // Arrange
        var exception = new InvalidCoordinateException("1..12");


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }
}
