using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Coordinator.Models;

using RestSharp;

namespace Coordinator.Client
{
    public class CoordinatorClient
    {
        private readonly Uri baseUrl;

        private const string DefaultUrl = "http://coordinatorwebapi.azurewebsites.net/api/";

        public CoordinatorClient()
        {
            string configurationUrl = ConfigurationManager.AppSettings["CoordinatorUrl"];
            baseUrl = !string.IsNullOrEmpty(configurationUrl) ? new Uri(configurationUrl) : new Uri(DefaultUrl);
        }

        public async Task<IEnumerable<Site>> RegisterSiteAsync(Site site)
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest
            {
                Resource = "Sites",
                Method = Method.POST,
                RequestFormat = DataFormat.Json,
            };

            request.AddBody(site);

            var response = await client.ExecuteTaskAsync<List<Site>>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var ex = new ApplicationException(message, response.ErrorException);
                throw ex;
            }

            return response.Data;
        }

        public async Task<IEnumerable<Site>> GetSites()
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest
            {
                Resource = "Sites",
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            var response = await client.ExecuteTaskAsync<List<Site>>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var ex = new ApplicationException(message, response.ErrorException);
                throw ex;
            }

            return response.Data;
        }
    }
}
