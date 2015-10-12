using System;
using System.Collections.Generic;

using Coordinator.Models;

using RestSharp;

namespace Coordinator.Client
{
    public class CoordinatorClient
    {
        private readonly Uri baseUrl;

        public CoordinatorClient()
        {
            baseUrl = new Uri("http://coordinatorwebapi.azurewebsites.net/api/");
        }

        public IEnumerable<Site> RegisterSite(Site site)
        {
            var client = new RestClient(baseUrl);

            var request = new RestRequest
            {
                Resource = "Sites",
                RequestFormat = DataFormat.Json
            };

            var response = client.Execute<List<Site>>(request);

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
