using System.Collections.Generic;

namespace DomainProbes
{
    public interface IDomainAnnouncer
    {
        void Announce(IDomainContext context);

        IReadOnlyList<IDomainMonitor> Monitors { get; }
        IDomainMonitor RegisterMonitor(IDomainMonitor monitor);
        IDomainMonitor UnregisterMonitor(IDomainMonitor monitor);
    }
}
