using DomainProbes.Contexts;

namespace DomainProbes.Probes
{
    public class PriceDiscountDomainProbe : IDomainProbe
    {
        private readonly IDomainAnnouncer _announcer;

        public PriceDiscountDomainProbe(IDomainAnnouncer announcer)
        {
            _announcer = announcer;
        }

        public void PriceDiscountNotFound(PriceDiscountNotFoundContext context)
        {
            _announcer.Announce(context);
        }

        public void PriceDiscountApplied(PriceDiscountAppliedContext context)
        {
            _announcer.Announce(context);
        }
    }
}
