using System;
using System.IO;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class InvalidCoordinateExceptionTests
{
    [Fact(DisplayName = "Serialization and Deserialization InvalidCoordinateException - Should be equivalent")]
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

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
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
