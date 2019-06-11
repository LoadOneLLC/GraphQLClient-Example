using GraphQLClient.Tests.Services;
using StructureMap;

namespace GraphQLClient.Tests
{
    public static class TypeRegistration
    {
        public static void RegisterTypes(IContainer container)
        {
            container.Configure(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(TypeRegistration));
                    scanner.WithDefaultConventions();
                });
                cfg.ForSingletonOf<IConfigurationSettings>().Use<ConfigurationSettings>();
            });
        }
    }
}
