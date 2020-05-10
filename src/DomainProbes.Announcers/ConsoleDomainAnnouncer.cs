using System;
using System.Collections.Generic;

namespace DomainProbes.Announcers
{
    public class ConsoleDomainAnnouncer : IDomainAnnouncer
    {
        private readonly List<IDomainMonitor> _monitors = new List<IDomainMonitor>();
        public IReadOnlyList<IDomainMonitor> Monitors => _monitors;

        public void Announce(IDomainContext context)
        {
            Console.WriteLine($"Announcing {context.GetType()}");
            _monitors.ForEach(x => x.Handle(context));
        }

        public IDomainMonitor RegisterMonitor(IDomainMonitor monitor)
        {
            _monitors.Add(monitor);
            return monitor;
        }

        public IDomainMonitor UnregisterMonitor(IDomainMonitor monitor)
        {
            _monitors.Remove(monitor);
            return monitor;
        }
    }
}
