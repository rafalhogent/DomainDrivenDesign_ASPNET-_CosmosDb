using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DDD.Infrastructure;
using DDD.Core.Entities;
using DDD.Core.Interfaces;

namespace DDD.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DddDbContext _context;

        public CustomerRepository(DddDbContext context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            var result = await _context.Customers.Include(k => k.Contacts).ToListAsync();
            return result != null ? result : new List<Customer>();
        }

        public async Task<Customer> CreateCustomerAsync(Customer newCustomer)
        {
            await _context.AddAsync(newCustomer);
            if (await _context.SaveChangesAsync() > 0) return newCustomer;
            throw new Exception("Adding new customer failed");
        }

        public async Task<Customer?> GetCustomerByIdAsync(string klantId)
        {
            return await _context.Customers.FindAsync(klantId);
        }

        public async Task<bool> AddContactToCustomerAsync(string customerId, Contact contact)
        {
            var klant = await GetCustomerByIdAsync(customerId);
            if (klant != null)
            {
                klant.Contacts.Add(contact);
            }
            else return false;

            return await _context.SaveChangesAsync() > 0;
        }



    }
}
