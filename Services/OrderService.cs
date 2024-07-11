using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly    HttpClient _httpClient;
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Order>>("api/Order");
        }
        public async Task<Order> GetOrderById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Order>($"api/Order/{id}");
        }
        public async Task Create(Order Order)
        {
            await _httpClient.PostAsJsonAsync("api/Order", Order);
        }
        public  async Task Update(Order Order)
        {
            await _httpClient.PutAsJsonAsync($"api/Order/{Order.OrderId}", Order);
        }
        public async  Task  Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Order/{id}");
        }
    }
}
