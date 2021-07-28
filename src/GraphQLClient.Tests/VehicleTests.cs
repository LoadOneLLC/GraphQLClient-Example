using GraphQL.Common.Request;
using GraphQLClient.Tests.Services;
using GraphQLClientLibrary.Services;
using Shouldly;
using StructureMap;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace GraphQLClient.Tests
{
    [CollectionDefinition("VehicleCollection")]
    public class VehicleCollection : ICollectionFixture<StructureMapFixture>
    {
    }

    [Collection("VehicleCollection")]
    public class VehicleTests
    {
        private readonly IContainer _container;
        private readonly IConfigurationSettings _config;
        private readonly IGraphQLClientService _request;

        public VehicleTests(StructureMapFixture structureMapFixture)
        {
            _container = structureMapFixture.CreateContainer();
            _config = _container.GetInstance<IConfigurationSettings>();
            _request = _container.GetInstance<IGraphQLClientService>();
        }

        [Fact]
        public async Task GetVehicleAvailability_Via3rdPartyIntegration()
        {
            var bearerToken = await _request.GetBearerToken(_config.ClientId, _config.ClientSecret);

            var queryRequest = new GraphQLRequest()
            {
                Query = @"
	            {
                  vehicles {
                    vehicleNumber
                    type 
                    serviceStatus 
                    canCrossBorder
                    boxDimensions {
                      length
                      unit
                    }
                    payload {
                      value
                      unit
                    }    
                    liftGate
                    dockHigh    
                    isTeam
                    availability {
                      dateTime
                      geoPoint {
                        lat
                        lng
                      }
                    }
                    domicile
                    hazmat
                    temperatureControl
                    driver {
                      hoursOfServiceRemaining
                    }
                  }
                }"
            };

            var vehicles = await _request.QueryViaGraphQLClientIntegration(bearerToken, queryRequest);
            vehicles.Count.ShouldBeGreaterThan(0);
            foreach (var vehicle in vehicles)
            {
                Debug.WriteLine($"Number: {vehicle.vehicleNumber}, Service Status: {vehicle.serviceStatus}");
            }
        }

        [Fact]
        public async Task GetVehicleAvailability_Manually()
        {
            var bearerToken = await _request.GetBearerToken(_config.ClientId, _config.ClientSecret);

            var queryRequest = @"
            {
                vehicles {
                vehicleNumber
                type 
                serviceStatus 
                canCrossBorder
                boxDimensions {
                    length
                    unit
                }
                payload {
                    value
                    unit
                }    
                liftGate
                dockHigh    
                isTeam
                availability {
                    dateTime
                    geoPoint {
                    lat
                    lng
                    }
                }
                domicile
                hazmat
                temperatureControl
                    driver {
                        hoursOfServiceRemaining
                    }
                }
            }";

            var vehicles = await _request.QueryManually(bearerToken, queryRequest);
            vehicles.Count.ShouldBeGreaterThan(0);
            foreach (var vehicle in vehicles)
            {
                Debug.WriteLine($"Number: {vehicle.vehicleNumber}, Service Status: {vehicle.serviceStatus}");
            }
        }
    }
}
