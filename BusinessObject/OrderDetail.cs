using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [PrimaryKey(nameof(OrderId) , nameof(ProductId))] 
    public class OrderDetail
    {
        
        public int OrderId { get; set; }
        [Key]
        public int ProductId { get; set; }
        public int UnitInStock { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
