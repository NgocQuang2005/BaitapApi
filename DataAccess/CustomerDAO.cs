using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        public async Task<IEnumerable<Customer>> GetCustomerAll()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null) return null;
            return customer;
        }
        public async Task Add(Customer customers)
        {
            _context.Customers.Add(customers);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Customer customers)
        {
            var existingItem = await GetCustomerById(customers.CustomerId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(customers);
            }
            else
            {
                _context.Customers.Add(customers);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var customer = await GetCustomerById(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}
