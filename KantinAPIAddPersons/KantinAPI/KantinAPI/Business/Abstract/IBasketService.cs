using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Business.Abstract
{
   public interface IBasketService
    {
        Task<List<Basket>> GetAll();
        Task<Basket> GetById(int id);
        Task<Basket> Create(Basket entity);
        Task<Basket> Update(Basket entity);
        Task<Basket> Delete(Basket entity);
        bool ExistBasket(int basketId);
        Task<bool> DeleteBasket(int basketId);
        Task<Basket> GetByUserId(int UserId);
        void AddToCart(int userId, int productId, int quantity);
        void DeleteFromCart(int userId);
        void ClearCart(int cartId);

    }
}
