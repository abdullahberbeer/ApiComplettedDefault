﻿using KantinAPI.Models;
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
        Task<Basket> DeleteBasket(int personId);
        Task<Basket> GetByPersonId(int personId);
        void AddToCart(int personId, int productId, int quantity);
        void DeleteFromCart(int personId);
        void ClearCart(int cartId);

    }
}
