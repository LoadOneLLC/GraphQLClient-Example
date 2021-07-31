using System;

namespace GraphQLClientLibrary.Models
{
    public class BoxDimensions
    {
        public int length { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public DimUnitOfMeasureType unit { get; set; }
    }

    public class DoorDimensions
    {        
        public int width { get; set; }
        public int height { get; set; }
        public DimUnitOfMeasureType unit { get; set; }
    }

    public enum DimUnitOfMeasureType
    {
        IN = 0,
        FT = 1
    }

    public class Payload
    {
        public int value { get; set; }
        public WeightUnitOfMeasureType unit { get; set; }
    }

    public enum WeightUnitOfMeasureType
    {
        LBS,
        KG
    }

    public class GeoPoint
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Availability
    {
        public DateTime dateTime { get; set; }
        public GeoPoint geoPoint { get; set; }
    }

    public class Driver
    {
        public double? hoursOfServiceRemaining { get; set; }
    }

    public class Vehicle
    {
        public string vehicleNumber { get; set; }
        public string type { get; set; }
        public string serviceStatus { get; set; }
        public bool canCrossBorder { get; set; }
        public BoxDimensions boxDimensions { get; set; }
        public DoorDimensions doorDimensions { get; set; }
        public Payload payload { get; set; }
        public bool liftGate { get; set; }
        public bool dockHigh { get; set; }
        public bool team { get; set; }
        public Availability availability { get; set; }
        public string domicile { get; set; }
        public bool hazmat { get; set; }
        public bool temperatureControl { get; set; }
        public Driver driver { get; set; }
    }
}
