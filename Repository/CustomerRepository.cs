using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task Add(Customer customer)
        {
            await CustomerDAO.Instance.Add(customer);
        }
        public async Task Update(Customer customer)
        {
            await CustomerDAO.Instance.Update(customer);
        }
        public async Task Delete(int id)
        {
            await CustomerDAO.Instance.Delete(id);
        }
        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await CustomerDAO.Instance.GetCustomerAll();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await CustomerDAO.Instance.GetCustomerById(id);
        }
    }
}
