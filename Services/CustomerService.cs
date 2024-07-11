using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly    HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Customer>>("api/Customer");
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Customer>($"api/Customer/{id}");
        }
        public async Task Create(Customer Customer)
        {
            await _httpClient.PostAsJsonAsync("api/Customer", Customer);
        }
        public  async Task Update(Customer Customer)
        {
            await _httpClient.PutAsJsonAsync($"api/Customer/{Customer.CustomerId}", Customer);
        }
        public async  Task  Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Customer/{id}");
        }
    }
}
