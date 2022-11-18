namespace DDD.Core.Entities
{
    public class InvoiceRow : BaseEntity
    {
        public InvoiceRow() : base() { }
        public InvoiceRow(string description, int number, decimal unitPrice) : this()
        {
            Description = description;
            Amount = number;
            PricePerUnit = unitPrice;
        }

        public string Description { get; set; } = null!;

        public int Amount { get; set; } = 1;

        public decimal PricePerUnit { get; set; }

        public decimal TotalPrice { get { return PricePerUnit * Amount; } }

    }
}