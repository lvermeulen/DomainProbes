namespace DomainProbes
{
    public interface IDomainMonitor
    {
        void Handle(IDomainContext context);
    }
}
