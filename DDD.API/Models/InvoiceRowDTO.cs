namespace DDD.API.Models
{
    public class InvoiceRowDTO
    {
        public string Description { get; set; } = null!;

        public int Number { get; set; } = 1;

        public decimal PricePerUnit { get; set; }
    }
}
