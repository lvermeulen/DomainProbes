using DomainProbes.Contexts;
using NSubstitute;
using Xunit;

namespace DomainProbes.Monitors.Tests
{
    public class MetricsMonitorShould
    {
        private readonly IMetrics _metrics;
        private readonly IDomainMonitor _monitor;

        public MetricsMonitorShould()
        {
            _metrics = Substitute.For<IMetrics>();
            _monitor = Substitute.For<MetricsMonitor>(_metrics);
        }

        [Fact]
        public void Handle()
        {
            var context = new PriceDiscountNotFoundContext { PriceDiscount = 0.1M };
            _monitor.Handle(context);
            _metrics.Received(1).Add(context);
        }
    }
}
