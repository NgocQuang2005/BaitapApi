using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly    HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/Product");
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Product/{id}");
        }
        public async Task Create(Product Product)
        {
            await _httpClient.PostAsJsonAsync("api/Product", Product);
        }
        public  async Task Update(Product Product)
        {
            await _httpClient.PutAsJsonAsync($"api/Product/{Product.ProductId}", Product);
        }
        public async  Task  Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Product/{id}");
        }
    }
}
