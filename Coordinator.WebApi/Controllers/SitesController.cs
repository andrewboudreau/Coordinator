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
        /// Registers or updates a <see cref="Site"/> and returns a list of registered <see cref="Site">Sites</see>.
        /// </summary>
        /// <param name="site">The <see cref="Site"/> being registered</param>
        /// <returns>All registered <see cref="Site">Sites</see></returns>
        public IEnumerable<Site> Post(Site site)
        {
            return server.RegisterSite(site);
        }
        
        /// <summary>
        /// Returns a list of all registered <see cref="Site">Sites</see>.
        /// </summary>
        /// <returns>A collection of <see cref="Site">Sites</see></returns>
        public IEnumerable<Site> Get()
        {
            return server.GetSites();
        }
        
        /// <summary>
        /// Deletes a <see cref="Site"/>.
        /// </summary>
        /// <param name="id">Id of <see cref="Site"/> being deleted</param>
        public void Delete(string id)
        {
            server.Delete(id);
        }
    }
}
