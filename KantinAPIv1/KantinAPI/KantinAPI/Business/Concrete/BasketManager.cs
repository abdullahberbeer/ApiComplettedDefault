using KantinAPI.Business.Abstract;
using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Business.Concrete
{
    public class BasketManager : IBasketService
    {
        private IBasketRepository _basketRepository;
        private IProductRepositroy _productRepositroy;
        public BasketManager(IBasketRepository basketRepository, IProductRepositroy productRepositroy)
        {
            _basketRepository = basketRepository;
            _productRepositroy = productRepositroy;
        }

        public async void AddToCart(int personId, int productId, int quantity)
        {
            var cart = await _basketRepository.GetByPersonId(personId);
            if (cart != null)
            {
                var index = cart.BasketItems.FindIndex(i => i.ProductId == productId);
                var product = await _productRepositroy.GetById(productId);
                var p = new Product()
                {
                    Price = product.Price
                };

                if (index<0)
                {
                    
                    cart.BasketItems.Add(new BasketItem()
                    {
                        ProductId = productId,
                        Adet = quantity,
                        BasketId = cart.Id,
                        TotalPrice=(double)p.Price*quantity
                        
                    });
                    cart.TotalPaye = cart.BasketItems.Sum(x => x.TotalPrice);
                }
                else
                {
                    
                    cart.BasketItems[index].Adet += quantity;
                    cart.BasketItems[index].TotalPrice +=(double)p.Price * quantity;
                    cart.TotalPaye = cart.BasketItems.Sum(x => x.TotalPrice);
                }
               await _basketRepository.Update(cart);
            }
        }

        public void ClearCart(int cartId)
        {
            _basketRepository.ClearCart(cartId);
        }

        public async Task<Basket> Create(Basket entity)
        {
            await _basketRepository.Create(entity);
            return entity;
        }

        public async Task<Basket> Delete(Basket entity)
        {
            await _basketRepository.Delete(entity);
            return entity;
        }

        public Task<bool> DeleteBasket(int basketId)
        {
            return _basketRepository.DeleteBasket(basketId);
        }

        public void DeleteFromCart(int personId)
        {
          
            
                _basketRepository.DeleteFromCart(personId);
            
        }

        public bool ExistBasket(int basketId)
        {
            return _basketRepository.ExistBasket(basketId);
        }

        public async Task<List<Basket>> GetAll()
        {
            return await _basketRepository.GetAll();
        }

        public async Task<Basket> GetById(int id)
        {
            return await _basketRepository.GetById(id);
        }

        public async Task<Basket> GetByPersonId(int personId)
        {
           return await _basketRepository.GetByPersonId(personId);
            
        }

        public async Task<Basket> Update(Basket entity)
        {
            await _basketRepository.Update(entity);
            return entity;
        }
    }
}
