using DDD.API.Models;
using DDD.Core.Entities;
using DDD.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly CustomerService _customerService;
        private readonly InvoiceService _invoiceService;

        public InvoiceController(CustomerService customerService, InvoiceService invoiceService)
        {
            _customerService = customerService;
            _invoiceService = invoiceService;
        }

        [HttpPost("add-invoice")]
        public async Task<ActionResult> AddInvoiceAsync(AddInvoiceDTO invDTO)
        {
            try
            {
                List<InvoiceRow> rows = invDTO.Rows
                    .Select(r => new InvoiceRow(r.Description, r.Number, r.PricePerUnit)).ToList();

                await _invoiceService.AddNewInvoiceAsync(invDTO.Date, invDTO.InvoiceNr, rows, invDTO.CustomerID);
                return base.Ok();
            }
            catch (Exception e)
            {
                return base.BadRequest(e.Message);
            }
        }

        [HttpPost("update-invoice-status")]
        public async Task<ActionResult> UpdateInvoiceStatusAsync(UpdateInvoiceStatusDTO invDTO)
        {
            try
            {
                await _invoiceService.UpdateInvoiceStatusAsync(invDTO.InvoiceID, invDTO.Status);
                return base.Ok();
            }
            catch (Exception e)
            {
                return base.BadRequest(e.Message);
            }
        }

    }
}
