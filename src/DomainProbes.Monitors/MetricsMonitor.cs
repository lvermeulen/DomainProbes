namespace DomainProbes.Monitors
{
    public class MetricsMonitor : IDomainMonitor
    {
        private readonly IMetrics _metrics;

        public MetricsMonitor(IMetrics metrics)
        {
            _metrics = metrics;
        }

        public void Handle(IDomainContext context)
        {
            _metrics.Add(context);
        }
    }

    public interface IMetrics
    {
        void Add(object obj);
    }
}
