using DomainProbes.Contexts;
using NSubstitute;
using Xunit;

namespace DomainProbes.Announcers.Tests
{
    public class ConsoleDomainAnnouncerShould
    {
        private readonly IDomainAnnouncer _announcer;

        public ConsoleDomainAnnouncerShould()
        {
            _announcer = new ConsoleDomainAnnouncer();
        }

        [Fact]
        public void Announce()
        {
            var monitor = Substitute.For<IDomainMonitor>();
            var context = new PriceDiscountNotFoundContext { PriceDiscount = 0.1M };
            _announcer.RegisterMonitor(monitor);
            _announcer.Announce(context);
            monitor.Received(1).Handle(context);
            _announcer.UnregisterMonitor(monitor);
        }

        [Fact]
        public void RegisterMonitor()
        {
            var monitor = Substitute.For<IDomainMonitor>();
            _announcer.RegisterMonitor(monitor);
            Assert.Equal(1, _announcer.Monitors.Count);
            Assert.Equal(monitor, _announcer.Monitors[0]);
            _announcer.UnregisterMonitor(monitor);
        }

        [Fact]
        public void UnregisterMonitor()
        {
            var monitor = Substitute.For<IDomainMonitor>();
            _announcer.RegisterMonitor(monitor);
            _announcer.UnregisterMonitor(monitor);
            Assert.Equal(0, _announcer.Monitors.Count);
        }
    }
}
