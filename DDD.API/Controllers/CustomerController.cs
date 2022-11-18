using Microsoft.AspNetCore.Mvc;
using DDD.Core.Entities;
using DDD.Core.Interfaces;
using DDD.Core.Services;
using DDD.API.Models;
using DDD.Core.Exceptions;

namespace DDD.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly InvoiceService _invoiceService;

        public CustomerController(CustomerService customerService, InvoiceService invoiceService)
        {
            _customerService = customerService;
            _invoiceService = invoiceService;
        }

        [HttpGet("Customers")]
        public async Task<ActionResult> GetAllCustomersAsync()
        {
            try
            {
                var res = await _customerService.GetAllCustomersAsync();
                return base.Ok(res);
            }
            catch (Exception)
            {
                return base.NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddCustomerAsync(CustomerCreateDTO newCustomerDTO)
        {
            try
            {
                Customer newCustomer = new Customer(newCustomerDTO.FirstName, newCustomerDTO.LastName);
                var newCust = await _customerService.AddNewCustomerAsync(newCustomer);
                return base.Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("add-contact")]
        public async Task<ActionResult> AddContactToCustomerAsync(AddContactToCustomerDTO addContactDTO)
        {
            try
            {
                Contact newContact = new(addContactDTO.Type, addContactDTO.Value);
                Contact res = await _customerService.AddContactToCustomerAsync(addContactDTO.CustomerID, newContact);
                return base.Ok();
            }
            catch (InvalidCustomerException e)
            {
                return base.BadRequest($"There is a problem with customer with id: {e.CustomerID}, {e.Message}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
