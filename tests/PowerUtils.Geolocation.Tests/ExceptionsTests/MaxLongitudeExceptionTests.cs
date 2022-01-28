using System;
using System.IO;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class MaxLongitudeExceptionTests
{
    [Fact(DisplayName = "Serialization and Deserialization MaxLongitudeException - Should be equivalent")]
    public void MaxLongitudeException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new MaxLongitudeException(1000);


        // Act
        Exception act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(MaxLongitudeException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (MaxLongitudeException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);
    }

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new MaxLongitudeException(1.12);


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }
}
