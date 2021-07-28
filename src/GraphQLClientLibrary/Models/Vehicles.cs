using System;

namespace GraphQLClientLibrary.Models
{
    public class BoxDimensions
    {
        public int length { get; set; }
        public string unit { get; set; }
    }

    public class Payload
    {
        public int value { get; set; }
        public string unit { get; set; }
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
        public Payload payload { get; set; }
        public bool liftGate { get; set; }
        public bool dockHigh { get; set; }
        public bool isTeam { get; set; }
        public Availability availability { get; set; }
        public string domicile { get; set; }
        public bool hazmat { get; set; }
        public bool temperatureControl { get; set; }
        public Driver driver { get; set; }
    }
}
