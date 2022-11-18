using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.Core.Entities;
using DDD.Core;
using DDD.Core.Interfaces;

namespace DDD.Infrastructure
{
    public class InvoiceRepository : IInvoiceRepository
    {

        private readonly DddDbContext _context;

        public InvoiceRepository(DddDbContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<bool> AddInvoiceAsync(Invoice invoice)
        {
            if (invoice.InvoiceRows.Count == 0) return false;
            await _context.AddAsync(invoice);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Invoice?> GetInvoiceByIDAsync(string invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }

        public async Task<bool> UpdateInvoiceStatusAsync(string invoiceId, InvoiceStatus newStatus)
        {
            var invoice = await GetInvoiceByIDAsync(invoiceId);
            if (invoice == null) return false;  

            invoice.Status = newStatus;
            _context.Invoices.Update(invoice);

            return await _context.SaveChangesAsync() > 0;   

        }
    }
}

