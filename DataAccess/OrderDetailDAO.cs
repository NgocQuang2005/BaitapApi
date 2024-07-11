using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId , int productId)
        {
            var orderdetail = await _context.OrderDetails.FirstOrDefaultAsync(c => c.OrderId == orderId && c.ProductId == productId);
            if (orderdetail == null) return null;
            return orderdetail;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int OrderId)
        {
            var orderdetails = await _context.OrderDetails.Where(c => c.OrderId == OrderId).ToListAsync();
            if (orderdetails == null) return null;
            return orderdetails;
        }
        public async Task Add(OrderDetail orderdetail)
        {
            _context.OrderDetails.Add(orderdetail);
            await _context.SaveChangesAsync();
        }
        public async Task Update(OrderDetail orderdetail)
        {
            var existingItem = await GetOrderDetailByOrderIdProductId(orderdetail.OrderId , orderdetail.ProductId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(orderdetail);
            }
            
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int orderId, int productId)
        {
            var orderdetail = await GetOrderDetailByOrderIdProductId(orderId, productId);
            if (orderdetail != null)
            {
                _context.OrderDetails.Remove(orderdetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
