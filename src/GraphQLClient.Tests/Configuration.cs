
using StructureMap;
using System;

namespace GraphQLClient.Tests
{
    public class StructureMapFixture : IDisposable
    {
        protected readonly IContainer Container;

        public StructureMapFixture()
        {
            Container = new Container();
            GraphQLClientLibrary.TypeRegistration.RegisterTypes(Container);
            TypeRegistration.RegisterTypes(Container);
        }

        public IContainer CreateContainer()
        {
            return Container.CreateChildContainer();
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}
