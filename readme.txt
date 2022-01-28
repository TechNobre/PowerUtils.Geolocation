 -------------------------------------------------------------------------
 --------------------------- UtilsLocalization ---------------------------
 ------------------------------------------------------------------------- 


 ***** NAMESPACE *****
    * TechNobre.Libraries.Localization;


***** TYPES *****
    * EnumCardinalDirection:
        * Unknown = 0,
        * North = 1,
        * South = 2,
        * East = 3,
        * West = 4

    * EnumDistanceUnit:
        * Kilometer = 0,
        * Meter = 1

    * EnumGeographicalOrientation:
        * Unknown = 0,
        * Latitude = 1,
        * Longitude = 2


***** HELPERS *****
    * double DDCoordinate.CalculateDistance(DDCoordinate beginLatitude, DDCoordinate beginLongitude, DDCoordinate endLatitude, DDCoordinate endLongitude, EnumDistanceUnit distanceUnit = EnumDistanceUnit.Kilometer);
    * double DMSCoordinate.CalculateDistance(DMSCoordinate beginLatitude, DMSCoordinate beginLongitude, DMSCoordinate endLatitude, DMSCoordinate endLongitude, EnumDistanceUnit distanceUnit = EnumDistanceUnit.Kilometer);


***** CLASSES *****
    * Coordinate:
    
    * Coordinates:

    * DDCoordinate : Coordinate
        * Properties:
            * EnumGeographicalOrientation GeographicalOrientation;
            * double DecimalDegrees;
        * Constructor:
            * DDCoordinate();
            * DDCoordinate(EnumGeographicalOrientation? geographicalOrientation = null);
            * DDCoordinate(double ddCoordinate, EnumGeographicalOrientation? geographicalOrientation = null);
            * DDCoordinate(string ddCoordinate, EnumGeographicalOrientation? geographicalOrientation = null);
        * Methods:
            ToString();
            ToDMS();

    * DDCoordinates : Coordinates
        * Properties:
            * DDCoordinate Latitude;
            * DDCoordinate Longitude;
        * Constructor:
            * DDCoordinates();
        * Methods:
            ToString();
            ToDMS();

    * DMSCoordinate : Coordinate
        * Properties:
            * EnumCardinalDirection CardinalDirection;
            * int Degrees;
            * int Minutes;
            * double Seconds;
        * Constructor:
            * DMSCoordinate();
            * DMSCoordinate(string dmsCoordinate);
        * Methods:
            ToString();
            ToDD();

    * DMSCoordinates : Coordinates
        * Properties:
            * DMSCoordinate Latitude;
            * DMSCoordinate Longitude;
        * Constructor:
            * DMSCoordinates();
            * DMSCoordinates(string dmsCoordinates);
        * Methods:
            ToString();
            ToDD();


***** CHANGES LOG *****
    * Update: 2018/11/15 | Version: 1.0.0 | Author: Nelson Nobre
        * First version;
    * Update: 2020/04/12 | Version: 2.0.0 | Author: Nelson Nobre
        * Update the package to support .NET Standard and .NET Framework;