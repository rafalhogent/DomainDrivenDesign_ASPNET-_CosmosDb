using DDD.Core.Entities;

namespace DDD.API.Models
{
    public class UpdateInvoiceStatusDTO
    {
        public string InvoiceID { get; set; } = null!;
        public InvoiceStatus Status { get; set; }
    }
}
