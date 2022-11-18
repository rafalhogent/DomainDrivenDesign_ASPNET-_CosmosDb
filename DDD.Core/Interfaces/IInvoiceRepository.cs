using DDD.Core.Entities;

namespace DDD.Core.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<bool> AddInvoiceAsync(Invoice invoice);
        Task<Invoice?> GetInvoiceByIDAsync(string invoiceId);
        Task<bool> UpdateInvoiceStatusAsync(string invoiceIdId, InvoiceStatus newStatus);
    }
}