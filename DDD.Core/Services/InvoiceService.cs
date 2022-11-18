using DDD.Core.Entities;
using DDD.Core.Exceptions;
using DDD.Core.Interfaces;

namespace DDD.Core.Services
{
    public class InvoiceService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public InvoiceService(ICustomerRepository customerRepo, IInvoiceRepository invoiceRepo)
        {
            _customerRepo = customerRepo;
            _invoiceRepo = invoiceRepo;
        }

        public async Task AddNewInvoiceAsync(DateTime date, string invoiceNr, List<InvoiceRow> rows, string customerID)
        {
            if (rows.Count == 0) throw new Exception($"Invalid invoice data. Number of rows is: {rows.Count}");
            var cust = await _customerRepo.GetCustomerByIdAsync(customerID);
            if (cust == null) throw new InvalidCustomerException(customerID, "Customer not found.");
            Invoice inv = new(date, invoiceNr, cust);
            inv.InvoiceRows = rows;
            if (!(await _invoiceRepo.AddInvoiceAsync(inv)))
                throw new Exception("Adding new Invoice failed");

        }

        public async Task UpdateInvoiceStatusAsync(string invoiceId, InvoiceStatus newStatus)
        {
            if (await _invoiceRepo.GetInvoiceByIDAsync(invoiceId) == null) throw new Exception("Invoice not found");
            if (!await _invoiceRepo.UpdateInvoiceStatusAsync(invoiceId, newStatus))
                throw new Exception("Update failed");
        }
    }
}
