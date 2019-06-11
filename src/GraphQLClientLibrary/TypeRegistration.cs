using GraphQLClientLibrary.Services;
using StructureMap;

namespace GraphQLClientLibrary
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
                cfg.ForSingletonOf<IGraphQLClientService>().Use<GraphQLClientService>();
            });
        }
    }
}
