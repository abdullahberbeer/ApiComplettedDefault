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

        Task<Basket> GetByPersonId(int personId);

        void DeleteFromCart(int personId);
        void ClearCart(int cartId);
      

    }
}
