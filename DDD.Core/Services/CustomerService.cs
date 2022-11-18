using DDD.Core.Entities;
using DDD.Core.Exceptions;
using DDD.Core.Interfaces;

namespace DDD.Core.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public CustomerService(ICustomerRepository customerRepo, IInvoiceRepository invoiceRepo)
        {
            _customerRepo = customerRepo;
            _invoiceRepo = invoiceRepo;
        }
        public async Task<Customer?> GetCustomerByIDAsync(string customerID)
        {
            return await _customerRepo.GetCustomerByIdAsync(customerID);
        }

        public async Task<Contact> AddContactToCustomerAsync(string customerID, Contact newContact)
        {
            if (await GetCustomerByIDAsync(customerID) == null)
                throw new InvalidCustomerException(customerID, "The customer does not exist");
            if (await _customerRepo.AddContactToCustomerAsync(customerID, newContact) == true)
            {
                return newContact;
            }
            else
            {
                throw new Exception("Adding new contact failed");
            }
        }

        public async Task<Customer> AddNewCustomerAsync(Customer newCustomer)
        {
            return await _customerRepo.CreateCustomerAsync(newCustomer);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepo.GetAllCustomersAsync();
        }
    }
}
