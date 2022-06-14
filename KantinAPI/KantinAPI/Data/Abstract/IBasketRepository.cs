using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Abstract
{
   public interface IBasketRepository:IRepository<Basket>
    {
        bool ExistBasket(int basketId);
        Task<bool> DeleteBasket(int basketId);

        Task<Basket> GetByUserId(int UserId);

        void DeleteFromCart(int userId);
        void ClearCart(int cartId);
      

    }
}
