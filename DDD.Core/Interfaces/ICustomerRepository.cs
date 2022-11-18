using DDD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> CreateCustomerAsync(Customer nieuweKlant);
        Task<bool> AddContactToCustomerAsync(string klantId, Contact contact);
        Task<Customer?> GetCustomerByIdAsync(string klantId);
    }
}
