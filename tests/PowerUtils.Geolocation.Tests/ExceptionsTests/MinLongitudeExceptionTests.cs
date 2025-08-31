using System;
using System.IO;
using System.Runtime.Serialization;
using AwesomeAssertions;
using PowerUtils.Geolocation.Exceptions;
using Xunit;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

public class MinLongitudeExceptionTests
{
    [Fact]
    public void MinLongitudeException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new MinLongitudeException(-1000);


        // Act
        Exception act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(MinLongitudeException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (MinLongitudeException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);
    }

    [Fact]
    public void NullInfo_GetObjectData_ArgumentNullException()
    {
        // Arrange
        var exception = new MinLongitudeException(1.12);


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }
}
