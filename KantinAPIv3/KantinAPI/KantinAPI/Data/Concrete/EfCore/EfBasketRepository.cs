using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Concrete.EfCore
{
    public class EfBasketRepository : EfCoreGenericRepository<Basket>, IBasketRepository
    {
        public EfBasketRepository(KantinContext context) : base(context)
        {

        }

        private KantinContext KantinContext
        {
            get { return context as KantinContext; }
        }

        public void ClearCart(int cartId)
        {
            var cmd = @"delete from BasketItems where Id=@p0";
            KantinContext.Database.ExecuteSqlRaw(cmd, cartId);
        }

        public async Task<Basket> DeleteBasket(int basketId)
        {
            var basket = KantinContext.Baskets.FirstOrDefault(x => x.Id == basketId);
            if (basket != null)
            {
                basket.TotalPaye = 0;
                await Update(basket);
                DeleteFromCart(basket.PersonId);
                return basket;
            }
            else
            {
                return null;
            }
        }

        public void DeleteFromCart(int personId)
        {
            var person = KantinContext.Baskets.Include(p => p.BasketItems).FirstOrDefaultAsync(x=>x.PersonId== personId);
            var model = new Basket()
            { 
                BasketItems = person.Result.BasketItems
            };
              
            KantinContext.BasketItems.RemoveRange(model.BasketItems);
           
            KantinContext.SaveChanges();
            
            

            
            
        }

        public bool ExistBasket(int basketId)
        {
            var basket = KantinContext.Baskets.Any(x => x.Id == basketId);
            if (basket)
            {
                return true;
            }

            return false;
        }

        public async Task<Basket> GetByPersonId(int personId)
        {
            return await KantinContext.Baskets.Include(i => i.BasketItems).ThenInclude(i => i.Product).FirstOrDefaultAsync(i => i.PersonId == personId);
        }

    

        public async override Task<Basket> Update(Basket entity)
            {
            KantinContext.Baskets.Update(entity);
           await  KantinContext.SaveChangesAsync();
            return entity;
            }
    }
}
