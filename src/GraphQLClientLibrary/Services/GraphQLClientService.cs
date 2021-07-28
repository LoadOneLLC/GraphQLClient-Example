using GraphQL.Client;
using GraphQL.Common.Request;
using GraphQLClientLibrary.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLClientLibrary.Services
{
    public interface IGraphQLClientService
    {
        Task<string> GetBearerToken(string clientId, string secret);
        Task<List<Vehicle>> QueryViaGraphQLClientIntegration(string bearerToken, GraphQLRequest queryRequest);
        Task<List<Vehicle>> QueryManually(string bearerToken, string queryRequest);
    }

    public class GraphQLClientService : IGraphQLClientService
    {
        public GraphQLClientService()
        {
        }

        public async Task<string> GetBearerToken(string clientId, string secret)
        {
            HttpClient client = new HttpClient();
            string uri = "https://app.load1.com/api/auth/token";
            var authenticateRequest = new AuthTokenRequest
            {
                ClientID = clientId,
                ClientSecret = secret
            };
            var content = new StringContent(JsonConvert.SerializeObject(authenticateRequest), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
            var authTokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(await response.Content.ReadAsStringAsync());
            return authTokenResponse.AccessToken;
        }

        public async Task<List<Vehicle>> QueryViaGraphQLClientIntegration(string bearerToken, GraphQLRequest queryRequest)
        {          
            var graphQLClient = new GraphQLClient("https://app.load1.com/api/graphql/");
            graphQLClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            var graphQLResponse = await graphQLClient.PostAsync(queryRequest);

            if (graphQLResponse.Errors == null)
                return graphQLResponse.Data["vehicles"].ToObject<List<Vehicle>>();
            else
            {
                foreach (var error in graphQLResponse.Errors)
                {
                    Debug.WriteLine(error.Message);
                }
            }
            throw new Exception("errors found");
        }

        public async Task<List<Vehicle>> QueryManually(string bearerToken, string queryRequest)
        {           
            return await QueryRequest(bearerToken, queryRequest);
        }

        public async Task<List<Vehicle>> QueryRequest(string bearerToken, string query)//, VehicleQuery queryRequest)
        {
            HttpClient client = new HttpClient();
            string uri = "https://app.load1.com/api/graphql";
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearerToken}");
            var content = new StringContent(query, Encoding.UTF8, "application/graphql-query");
            var response = await client.PostAsync(uri, content);
            JObject jObj = JObject.Parse(await response.Content.ReadAsStringAsync());

            if (response.IsSuccessStatusCode)
                return ((JArray)jObj["data"]["vehicles"]).ToObject<List<Vehicle>>();
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errors = ((JArray)jObj["errors"]).ToObject<List<Error>>();
                foreach (var error in errors)
                {
                    Debug.WriteLine(error.message);
                }
            }
            throw new Exception("errors found");
        }

    }
}
