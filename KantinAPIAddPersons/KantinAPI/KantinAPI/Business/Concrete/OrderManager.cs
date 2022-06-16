using KantinAPI.Business.Abstract;
using KantinAPI.Data.Abstract;
using KantinAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KantinAPI.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IProductRepositroy _productRepositroy;
        public OrderManager(IOrderRepository orderRepository, IProductRepositroy productRepositroy)
        {
            _orderRepository = orderRepository;
            _productRepositroy = productRepositroy;
        }

        public async void AddToOrder(int userId, int productId, int quantity)
        {
            var order = await _orderRepository.GetByUserId(userId);
            if (order != null)
            {
                var index = order.OrderItems.FindIndex(i => i.ProductId == productId);
                var product = await _productRepositroy.GetById(productId);
                var p = new Product()
                {
                    Price = product.Price
                };

                if (index < 0)
                {

                    order.OrderItems.Add(new OrderItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        OrderId = order.Id,
                        Price= (double)p.Price * quantity
                        

                    });
                    //order.TotalPaye = cart.BasketItems.Sum(x => x.TotalPrice);
                }
                else
                {

                    order.OrderItems[index].Quantity += quantity;
                    order.OrderItems[index].Price += (double)p.Price * quantity;
                    //order.TotalPaye = cart.BasketItems.Sum(x => x.TotalPrice);
                }
                await _orderRepository.Update(order);
            }
        }

        public void ClearOrder(int orderId)
        {
            _orderRepository.ClearOrder(orderId);
        }

        public async Task<Order> Create(Order entity)
        {
            await _orderRepository.Create(entity);
            return entity;
        }

        public async Task<Order> Delete(Order entity)
        {
            await _orderRepository.Delete(entity);
            return entity;
        }

        public Task<bool> DeleteOrder(int orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public void DeleteFromOrder(int userId)
        {
            _orderRepository.DeleteFromOrder(userId);
        }

        public bool ExistOrder(int orderId)
        {
            return _orderRepository.ExistOrder(orderId);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> GetById(int id)
        {
            return await _orderRepository.GetById(id);
        }

        public  async Task<Order> GetByUserId(int UserId)
        {
            return await _orderRepository.GetByUserId(UserId);
        }

        public async Task<Order> Update(Order entity)
        {
            await _orderRepository.Update(entity);
            return entity;
        }
    }
}
