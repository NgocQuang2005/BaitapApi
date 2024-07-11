using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly    HttpClient _httpClient;
        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDetail>>("api/OrderDetail");
        }


        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int OrderId  ,int ProductId)
        {
            return await _httpClient.GetFromJsonAsync<OrderDetail>($"api/OrderDetail/{OrderId}/{ProductId}");
        }


        public async Task Create(OrderDetail OrderDetail)
        {
            await _httpClient.PostAsJsonAsync("api/OrderDetail", OrderDetail);
        }



        public  async Task Update(OrderDetail OrderDetail)
        {
            await _httpClient.PutAsJsonAsync($"api/OrderDetail/{OrderDetail.OrderId}/{OrderDetail.ProductId}", OrderDetail);
        }



        public async  Task  Delete(int OrderId, int ProductId)
        {
            await _httpClient.DeleteAsync($"api/OrderDetail/{OrderId} / {ProductId}");
        }



        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<OrderDetail>>($"api/OrderDetail/{OrderId}");
        }
    }
}
