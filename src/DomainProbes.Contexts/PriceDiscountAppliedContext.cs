namespace DomainProbes.Contexts
{
    public class PriceDiscountAppliedContext : IDomainContext
    {
        public decimal OldPrice { get; set; }
        public decimal NewPrice { get; set; }
        public decimal PriceDiscount { get; set; }
    }
}
