using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLClient.Tests.Services
{
    public interface IConfigurationSettings
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }

    public class ConfigurationSettings : IConfigurationSettings
    {
        public string ClientId => "xxxxxx";
        public string ClientSecret => "xxxxxxxxxxxxxxxx";       
    }   
}
