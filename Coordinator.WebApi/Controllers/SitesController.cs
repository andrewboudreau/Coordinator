using System.Collections.Generic;
using System.Web.Http;
using Coordinator.Models;

namespace Coordinator.WebApi.Controllers
{
    public class SitesController : ApiController
    {
        private readonly CoordinatorServer server;

        /// <summary>
        /// Site Coordinator
        /// </summary>
        public SitesController(CoordinatorServer server)
        {
            this.server = server;
        }

        /// <summary>
        /// Get a list of registered sites.
        /// </summary>
        /// <param name="site"></param>
        /// <returns></returns>
        public IEnumerable<Site> Post(Site site)
        {
            return server.RegisterSite(site);
        }
        
        /// <summary>
        /// Returns all registered sites.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Site> Get()
        {
            return server.GetSites();
        }
        
        /// <summary>
        /// Deletes a registered site.
        /// </summary>
        /// <param name="id">Site Id</param>
        public void Delete(string id)
        {
            server.Delete(id);
        }
    }
}
