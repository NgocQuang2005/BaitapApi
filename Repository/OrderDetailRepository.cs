using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task Add(OrderDetail orderdetail)
        {
            await OrderDetailDAO.Instance.Add(orderdetail);
        }
        public async Task Update(OrderDetail orderdetail)
        {
            await OrderDetailDAO.Instance.Update(orderdetail);
        }
        public async Task Delete(int OrderId, int ProductId)
        {
            await OrderDetailDAO.Instance.Delete(OrderId, ProductId);
        }
        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            return await OrderDetailDAO.Instance.GetOrderDetailAll();
        }
        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int OrderId , int ProductId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderIdProductId(OrderId, ProductId);
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId)
        {
           return await OrderDetailDAO.Instance.GetOrderDetailByOrderId(OrderId);
        }
    }
}
