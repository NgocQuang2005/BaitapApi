using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetOrderById(int id);
        Task Create(Order Order);
        Task Update(Order Order);
        Task Delete(int id);
    }
}
