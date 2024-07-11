using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        Task<OrderDetail> GetOrderDetailByOrderIdProductId(int OrderId, int ProductId);
        Task Create(OrderDetail orderDetail);
        Task Update(OrderDetail orderDetail);
        Task Delete(int OrderId, int ProductId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId);
    }
}
