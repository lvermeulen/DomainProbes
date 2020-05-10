using DomainProbes.Contexts;
using NSubstitute;
using Xunit;

namespace DomainProbes.Probes.Tests
{
    public class PriceDiscountDomainProbeShould
    {
        private readonly IDomainAnnouncer _announcer;
        private readonly PriceDiscountDomainProbe _probe;

        public PriceDiscountDomainProbeShould()
        {
            _announcer = Substitute.For<IDomainAnnouncer>();
            _probe = Substitute.For<PriceDiscountDomainProbe>(_announcer);
        }

        [Fact]
        public void PriceDiscountNotFound()
        {
            var context = new PriceDiscountNotFoundContext { PriceDiscount = 0.1M };
            _probe.PriceDiscountNotFound(context);
            _announcer.Received(1).Announce(context);
        }

        [Fact]
        public void PriceDiscountApplied()
        {
            var context = new PriceDiscountAppliedContext { OldPrice = 10, NewPrice = 9, PriceDiscount = 0.1M };
            _probe.PriceDiscountApplied(context);
            _announcer.Received(1).Announce(context);
        }
    }
}
