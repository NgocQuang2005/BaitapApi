using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO : SingletonBase<ProductDAO>
    {
        public async Task<IEnumerable<Product>> GetProductAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == id);
            if (product == null) return null;
            return product;
        }
        public async Task Add(Product products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product products)
        {
            var existingItem = await GetProductById(products.ProductId);
            if (existingItem != null)
            {
                _context.Entry(existingItem).CurrentValues.SetValues(products);
            }
            else
            {
                _context.Products.Add(products);
            }
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
