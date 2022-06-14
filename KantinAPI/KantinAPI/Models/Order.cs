using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime OrderAdded { get; set; } = DateTime.Now;
        public List<OrderItem> OrderItems{ get; set; }
    }
}
