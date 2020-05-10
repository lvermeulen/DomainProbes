using DomainProbes.Contexts;
using NSubstitute;
using Xunit;

namespace DomainProbes.Monitors.Tests
{
    public class LoggingMonitorShould
    {
        private readonly ILogger _logger;
        private readonly IDomainMonitor _monitor;

        public LoggingMonitorShould()
        {
            _logger = Substitute.For<ILogger>();
            _monitor = Substitute.For<LoggingMonitor>(_logger);
        }

        [Fact]
        public void Handle()
        {
            var context = new PriceDiscountNotFoundContext { PriceDiscount = 0.1M };
            _monitor.Handle(context);
            _logger.Received(1).Log(Arg.Any<string>());
        }
    }
}
