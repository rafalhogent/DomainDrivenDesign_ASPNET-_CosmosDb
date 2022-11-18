namespace DDD.API.Models
{
    public class AddInvoiceDTO
    {
        public string InvoiceNr { get; set; } = null!;
        public string CustomerID { get; set; } = null!;

        public DateTime Date { get; set; }

        public ICollection<InvoiceRowDTO> Rows { get; set; } = new List<InvoiceRowDTO>();
    }
}
