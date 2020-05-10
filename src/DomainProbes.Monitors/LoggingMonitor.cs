namespace DomainProbes.Monitors
{
    public class LoggingMonitor : IDomainMonitor
    {
        private readonly ILogger _logger;

        public LoggingMonitor(ILogger logger)
        {
            _logger = logger;
        }

        public void Handle(IDomainContext context)
        {
            _logger.Log($"Logging {context.GetType()}");
        }
    }

    public interface ILogger
    {
        void Log(string s);
    }
}
