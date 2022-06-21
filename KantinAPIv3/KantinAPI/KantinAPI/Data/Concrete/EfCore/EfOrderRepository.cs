using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Data.Concrete.EfCore
{
    public class EfOrderRepository:EfCoreGenericRepository<Order>,IOrderRepository
    {
        public EfOrderRepository(KantinContext context) : base(context)
        {

        }

        private KantinContext KantinContext
        {
            get { return context as KantinContext; }
        }

        public void ClearOrder(int orderId)
        {
            var cmd = @"delete from OrderItems where Id=@p0";
            KantinContext.Database.ExecuteSqlRaw(cmd, orderId);
        }

        public void DeleteFromOrder(int personId)
        {
            var person = KantinContext.Orders.Include(p => p.OrderItems).FirstOrDefaultAsync(x => x.PersonId == personId);
            var model = new Order()
            {
                OrderItems = person.Result.OrderItems
            };
            KantinContext.OrderItems.RemoveRange(model.OrderItems);
            KantinContext.SaveChanges();

        }

        public async Task<Order> DeleteOrder(int orderId)
        {
            var order = KantinContext.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order != null)
            {
                order.IsActive = false;
                await Update(order);
                
                return order;
            }
            else
            {
                return null;
            }
        }

        public bool ExistOrder(int orderId)
        {
            var order = KantinContext.Orders.Any(x => x.Id == orderId);
            if (order)
            {
                return true;
            }

            return false;
        }

        public async Task<Order> GetByPersonId(int personId)
        {
            return await KantinContext.Orders.Include(i => i.OrderItems).ThenInclude(i => i.Product).FirstOrDefaultAsync(i => i.PersonId == personId);
        }
        public async override Task<Order> Update(Order entity)
        {
            KantinContext.Orders.Update(entity);
            await KantinContext.SaveChangesAsync();
            return entity;
        }
    }
}
