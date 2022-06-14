using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Business.Abstract
{
   public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<Order> Create(Order entity);
        Task<Order> Update(Order entity);
        Task<Order> Delete(Order entity);
        bool ExistOrder(int orderId);
        Task<bool> DeleteOrder(int orderId);
        Task<Order> GetByUserId(int UserId);
        void AddToOrder(int userId, int productId, int quantity);
        void DeleteFromOrder(int userId);
        void ClearOrder(int orderId);
    }
}
