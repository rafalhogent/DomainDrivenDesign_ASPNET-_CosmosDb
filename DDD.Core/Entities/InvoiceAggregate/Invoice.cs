using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DDD.Core.Entities
{
    public enum InvoiceStatus
    {
        Created, Sent, Confirmed, Paid
    }

    public class Invoice : BaseEntity
    {
        public Invoice() { }
        public Invoice(DateTime date, string invoiceNr, Customer customer)
        {
            Date = date;
            InvoiceNr = invoiceNr;
            Customer = customer;
        }

        public DateTime Date { get; set; } = DateTime.Now;

        public string InvoiceNr { get; set; } = null!;

        public InvoiceStatus Status { get; set; }

        public Customer Customer { get; set; } = null!;

        public ICollection<InvoiceRow> InvoiceRows { get; set; } = new List<InvoiceRow>();

        public decimal TotalAmount
        {
            get { return InvoiceRows.Select(x => x.TotalPrice).Sum(); }
        }

    }
}
