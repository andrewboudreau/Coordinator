using System;

namespace Coordinator.Models
{
    public class Site
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime LastRegistered { get; set; }
    }
}
