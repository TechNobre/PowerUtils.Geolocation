﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace PowerUtils.Geolocation.Tests.ExceptionsTests;

[Trait("Type", "Exceptions")]
public class MaxLatitudeExceptionTests
{
    [Fact(DisplayName = "Serialization and Deserialization MaxLatitudeException - Should be equivalent")]
    public void MaxLatitudeException_SerializeDeserialize_Equivalent()
    {
        // Arrange
        var exception = new MaxLatitudeException(1000);


        // Act
        Exception act;
        using(var memoryStream = new MemoryStream())
        {
            var dataContractSerializer = new DataContractSerializer(typeof(MaxLatitudeException));

            dataContractSerializer.WriteObject(memoryStream, exception);

            memoryStream.Seek(0, SeekOrigin.Begin);

            act = (MaxLatitudeException)dataContractSerializer.ReadObject(memoryStream);
        }


        // Assert
        act.Should()
            .BeEquivalentTo(exception);
    }

    [Fact(DisplayName = "Try call GetObjectData with null info - Should return an 'ArgumentNullException'")]
    public void GetObjectData_NullInfo_ArgumentNullException()
    {
        // Arrange
        var exception = new MaxLatitudeException(1.12);


        // Act
        var act = Record.Exception(() => exception.GetObjectData(null, new StreamingContext()));


        // Assert
        act.Should()
            .BeOfType<ArgumentNullException>();
    }
}