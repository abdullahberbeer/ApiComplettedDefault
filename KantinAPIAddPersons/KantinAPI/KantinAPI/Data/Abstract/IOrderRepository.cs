using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Abstract
{
   public interface IOrderRepository:IRepository<Order>
    {
        bool ExistOrder(int orderId);
        Task<bool> DeleteOrder(int orderId);

        Task<Order> GetByUserId(int userId);

        void DeleteFromOrder(int userId);
        void ClearOrder(int orderId);
    }
}
