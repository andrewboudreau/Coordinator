using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Coordinator.Models;

namespace Coordinator.WebApi
{
    public class CoordinatorServer
    {
        private static ConcurrentDictionary<string, Site> Sites { get; } = new ConcurrentDictionary<string, Site>();

        public IEnumerable<Site> RegisterSite(Site site)
        {
            Sites.AddOrUpdate(site.Id, site, ((key, oldValue) => { oldValue.LastRegistered = DateTime.UtcNow; return oldValue; }));
            return Sites.Values;
        }

        public IEnumerable<Site> GetSites()
        {
            return Sites.Values;
        }

        public void Delete(string id)
        {
            Site site;
            Sites.TryRemove(id, out site);
        }
    }
}
