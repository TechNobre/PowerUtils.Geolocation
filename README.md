# PowerUtils.Geolocation

![Logo](https://raw.githubusercontent.com/TechNobre/PowerUtils.Geolocation/main/assets/logo/logo_128x128.png)

***Library to work with geographic coordinates***

![Tests](https://github.com/TechNobre/PowerUtils.Geolocation/actions/workflows/test-project.yml/badge.svg)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.Geolocation&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.Geolocation)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=TechNobre_PowerUtils.Geolocation&metric=coverage)](https://sonarcloud.io/summary/new_code?id=TechNobre_PowerUtils.Geolocation)

[![NuGet](https://img.shields.io/nuget/v/PowerUtils.Geolocation.svg)](https://www.nuget.org/packages/PowerUtils.Geolocation)
[![Nuget](https://img.shields.io/nuget/dt/PowerUtils.Geolocation.svg)](https://www.nuget.org/packages/PowerUtils.Geolocation)
[![License: MIT](https://img.shields.io/github/license/TechNobre/PowerUtils.Geolocation.svg)](https://github.com/TechNobre/PowerUtils.Geolocation/blob/main/LICENSE)


- [Support](#support-to)
- [How to use](#how-to-use)
- [Dependencies](#dependencies)
- [Exceptions](#Exceptions)
- [Types](#Types)
  - [CardinalDirection](#Types.CardinalDirection)
  - [DistanceUnit](#Types.DistanceUnit)
  - [GeographicalOrientation](#Types.GeographicalOrientation)
- [Extensions](#Extensions)
  - [LengthConversionExtensions](#Extensions.LengthConversionExtensions)
    - [.FromKilometerToMeter()](#Extensions.FromKilometerToMeter)
    - [.FromKilometerToMile()](#Extensions.FromKilometerToMile)
    - [.FromKilometerTo()](#Extensions.FromKilometerTo)
    - [.FromMeterToKilometer()](#Extensions.FromMeterToKilometer)
    - [.FromMeterToMile()](#Extensions.FromMeterToMile)
    - [.FromMeterTo()](#Extensions.FromMeterTo)
    - [.FromMileToMeter()](#Extensions.FromMileToMeter)
    - [.FromMileToKilometer()](#Extensions.FromMileToKilometer)
    - [.FromMileTo()](#Extensions.FromMileTo)
  - [ConversionExtensions](#Extensions.ConversionExtensions)
    - [.GetGeographicalOrientation()](#Extensions.GetGeographicalOrientation)
    - [.ToRadian()](#Extensions.ToRadian)
    - [.ToDegree()](#Extensions.ToDegree)
    - [.ToDDPoint()](#Extensions.ToDDPoint)
- [Objects](#Objects)
  - [GeoDDCoordinate](#Objects.GeoDDCoordinate)
    - [Deconstruct](#Objects.GeoDDCoordinate.Deconstruct)
    - [Clone](#Objects.GeoDDCoordinate.Clone)
    - [Comparisons](#Objects.GeoDDCoordinate.Comparisons)
    - [Implicits](#Objects.GeoDDCoordinate.Implicits)
    - [Parse](#Objects.GeoDDCoordinate.Parse)
    - [Distance](#Objects.GeoDDCoordinate.Distance)
  - [GeoJSON](#Objects.GeoJSON)
    - [Implicits](#Objects.GeoJSON.Implicits)
- [Guard](#Guard)
  - [GuardGeolocation.Against.Latitude()](#GuardGeolocation.Against.Latitude)
  - [GuardGeolocation.Against.Longitude()](#GuardGeolocation.Against.Longitude)
- [Contribution](#contribution)
- [License](./LICENSE)
- [Changelog](./CHANGELOG.md)



## Support to <a name="support-to"></a>
- .NET 3.1 or more
- .NET Framework 4.6.2 or more
- .NET Standard 2.0 or more



## Dependencies <a name="dependencies"></a>

- Newtonsoft.Json [NuGet](https://www.nuget.org/packages/Newtonsoft.Json/) *(.NET Framework 4.6.2 | .NET Framework 4.8 | .NET Standard 2.0 | .NET Standard 2.1)*



## How to use <a name="how-to-use"></a>

### Install NuGet package
This package is available through Nuget Packages: https://www.nuget.org/packages/PowerUtils.Geolocation

**Nuget**
```bash
Install-Package PowerUtils.Geolocation
```

**.NET CLI**
```
dotnet add package PowerUtils.Geolocation
```



### Exceptions <a name="Exceptions"></a>
`namespace PowerUtils.Geolocation.Exceptions`

- `InvalidCoordinateException(coordinate);`
- `MinLatitudeException(coordinate);`
- `MaxLatitudeException(coordinate);`
- `MinLongitudeException(coordinate);`
- `MaxLongitudeException(coordinate);`



### Types <a name="Types"></a>
`namespace PowerUtils.Geolocation.Types`


#### CardinalDirection <a name="Types.CardinalDirection"></a>

```csharp
public enum CardinalDirection
{
    North,
    South,
    East,
    West,
}
```


#### DistanceUnit <a name="Types.DistanceUnit"></a>

```csharp
public enum DistanceUnit
{
    kilometer,
    Meter,
    Mile
}
```


#### GeographicalOrientation <a name="Types.GeographicalOrientation"></a>

```csharp
public enum GeographicalOrientation
{
    Latitude,
    Longitude
}
```




### Extensions <a name="Extensions"></a>
`namespace PowerUtils.Geolocation`


#### LengthConversionExtensions <a name="Extensions.LengthConversionExtensions"></a>


#### .FromKilometerToMeter() <a name="Extensions.FromKilometerToMeter"></a>
Convert kilometers to meters (int, uint, long, ulong, float, double, decimal)

```csharp
// result = 45_000
var result = 45.FromKilometerToMeter();
```


#### .FromKilometerToMile() <a name="Extensions.FromKilometerToMile"></a>
Convert kilometers to miles (float, double, decimal)

```csharp
// result = 137.472_122
var result = (221.24).FromKilometerToMile();
```


#### .FromKilometerTo() <a name="Extensions.FromKilometerTo"></a>
Converting (double, decimal, float) numbers in kilometers to a new unit

```csharp
// result = 20_000
var result = 20.FromKilometerTo(DistanceUnit.Meter);
```


#### .FromMeterToKilometer() <a name="Extensions.FromMeterToKilometer"></a>
Convert meters to kilometers (int, uint, long, ulong, float, double, decimal)

```csharp
// result = 45
var result = (45_000).FromMeterToKilometer();
```


#### .FromMeterToMile() <a name="Extensions.FromMeterToMile"></a>
Convert meters to kilometers (float, double, decimal)

```csharp
// result = 7.098204899547
var result = (11_423.457).FromMeterToMile();
```


#### .FromMeterTo() <a name="Extensions.FromMeterTo"></a>
Converting (double, decimal, float) numbers in meters to a new unit

```csharp
// result = 0.002
var result = 2.FromMeterTo(DistanceUnit.kilometer);
```


#### .FromMileToMeter() <a name="Extensions.FromMileToMeter"></a>
Convert miles to meters (float, double, decimal)

```csharp
// result = 356_050.3816
var result = (221.24).FromMileToMeter();
```


#### .FromMileToKilometer() <a name="Extensions.FromMileToKilometer"></a>
Convert miles to kilometers (float, double, decimal)

```csharp
// result = 356.05038160000004
var result = (221.24).FromMileToKilometer();
```


#### .FromMileTo() <a name="Extensions.FromMileTo"></a>
Converting (double, decimal, float) numbers in miles to a new unit

```csharp
// result = 32_18.68
var result = 2.FromMileTo(DistanceUnit.kilometer);
```



#### ConversionExtensions <a name="Extensions.ConversionExtensions"></a>


##### .GetGeographicalOrientation() <a name="Extensions.GetGeographicalOrientation"></a>
Get the geographical orientation from a specific cardinal direction

```csharp
// result = GeographicalOrientation.Longitude
var result = CardinalDirection.North.GetGeographicalOrientation();
```


##### .ToRadian() <a name="Extensions.ToRadian"></a>
Convert degree to radian (PI / 180)

```csharp
// result = 0.19198621771937624
var result = 11.ToRadian();
```


##### .ToDegree() <a name="Extensions.ToDegree"></a>
Convert radian to degree (180 / PI)

```csharp
// result = 11
var result = (0.19198621771937624).ToDegree();
```


##### .ToDegree() <a name="Extensions.ToDegree"></a>
Convert radian to degree (180 / PI)

```csharp
// result = 11
var result = (0.19198621771937624).ToDegree();
```


##### .ToDDPoint() <a name="Extensions.ToDDPoint"></a>
Convert decimal degree point (string) to decimal degree point (double)

```csharp
// result = -8.668_173
var result = "-8,668173".ToDDPoint();
```



### Objects <a name="Objects"></a>
`namespace PowerUtils.Geolocation`


#### GeoDDCoordinate <a name="Objects.GeoDDCoordinate"></a>
Decimal degree coordinate

```csharp
var coordinate = new GeoDDCoordinate(81.54, -54.1272);
(var latitude, var longitude) = coordinates;
```


##### Deconstruct <a name="Objects.GeoDDCoordinate.Deconstruct"></a>
Deconstruct GeoDDCoordinate to double latitude and double longitude

```csharp
(var latitude, var longitude) = coordinates;
```


##### .Clone() <a name="Objects.GeoDDCoordinate.Clone"></a>
Create a new object 'GeoDDCoordinate' with the same data

```csharp
(var newCoordinate = coordinates.Clone();
```


##### Comparisons <a name="Objects.GeoDDCoordinate.Comparisons"></a>

```csharp
GeoDDCoordinate left = new(1.54, 54.1272);
GeoDDCoordinate right = new(1.54, 54.1272);

// result1 = true
var result1 = left == right;

// result2 = false
var result2 = left != right;

// result3 = true
var result3 = left.Equals(right);
```


##### Implicits <a name="Objects.GeoDDCoordinate.Implicits"></a>

```csharp
var text1 = "-12.51214,14.1272";

var coordinate = (GeoDDCoordinate)text1;

var text2 = (string)coordinate;
```


##### Parse <a name="Objects.GeoDDCoordinate.Parse"></a>

```csharp
var coordinate1 = GeoDDCoordinate.Parse("12,152", "-8,12");
var coordinate2 = GeoDDCoordinate.Parse("81.54  , -54.1272");

var result3 = GeoDDCoordinate.TryParse("12,152", "-8,12", out var coordinate3);
var result4 = GeoDDCoordinate.TryParse("81.54  , -54.1272", out var coordinate4);
```


##### Distance <a name="Objects.GeoDDCoordinate.Distance"></a>

```csharp
// distance1 = 189143
var distance1 = GeoDDCoordinate.Distance(37.165611, -8.545786, 38.737545, -9.370047, 0);

// distance2 = 18542.719416538552
var distance2 = GeoDDCoordinate.PreciseDistance(37.068673, -7.939493, 37.098708, -8.145107);


GeoDDCoordinate left = new(37.068673, -7.939493);
GeoDDCoordinate right = new(37.098708, -8.145107);

// distance3 = 18543
var distance3 = left.Distance(right);
```



#### GeoJSON <a name="Objects.GeoJSON"></a>

```csharp
var coordinate = new GeoDDCoordinate(9.1, 12);

var result = new GeoJSON(coordinate);
```


##### Implicits <a name="Objects.GeoJSON.Implicits"></a>

```csharp
var coordinate = new GeoDDCoordinate(9.1, 12);

var geoJSON = (GeoJSON)coordinate;

var result = (GeoDDCoordinate)geoJSON;
```



### Guard <a name="Guard"></a>

```csharp
var latitude = GuardGeolocation.Against.Latitude(degree);

var longitude = GuardGeolocation.Against.Longitude(degree);
```


#### GuardGeolocation.Against.Latitude() <a name="GuardGeolocation.Against.Latitude"></a>
- Exception
  - MinLatitudeException
  - MaxLatitudeException


#### GuardGeolocation.Against.Longitude() <a name="GuardGeolocation.Against.Longitude"></a>
- Exception
  - MinLongitudeException
  - MaxLongitudeException





## Contribution<a name="contribution"></a>

If you have any questions, comments, or suggestions, please open an [issue](https://github.com/TechNobre/PowerUtils.Geolocation/issues/new/choose) or create a [pull request](https://github.com/TechNobre/PowerUtils.Geolocation/compare)