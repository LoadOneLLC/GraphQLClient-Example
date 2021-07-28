using System.Collections.Generic;

namespace GraphQLClientLibrary.Models
{
    public class Location
    {
        public int line { get; set; }
        public int column { get; set; }
    }

    public class Extensions
    {
        public string code { get; set; }
    }

    public class Error
    {
        public string message { get; set; }
        public List<Location> locations { get; set; }
        public Extensions extensions { get; set; }
    }
}
