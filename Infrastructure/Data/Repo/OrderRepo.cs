using Core.Interfaces;
using Core.Models;
using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repo
{
    public class OrderRepo : IOrderRepository
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _unitOfWork;
        public OrderRepo(IBasketRepository basketRepo, IUnitOfWork unitOfWork)
        {
            _basketRepo = basketRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address ShippToAddress)
        {
            //1- Get the Basket
            var basket =await _basketRepo.GetBasketAsync(basketId);
            //2- Get items from product repo
            var items = new List<OrderItem>();
            foreach(var item in  basket.BasketItems)
            {
                var productItem =await _unitOfWork.Products.FindByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, item.Quantity, productItem.Price);
                items.Add(orderItem);
            }
            //3- Get delivery method
            var deliveryMethod =await _unitOfWork.Repository<DeliveryMethod>().FindByIdAsync(deliveryMethodId);
            //4- calc subTotal
            var subTotal = items.Sum(x=>  x.Price* x.Quintity);
            //5- Create Order
            var Order = new Order(buyerEmail,ShippToAddress,deliveryMethod,items,subTotal);
            //6- Save Order
            _unitOfWork.Repository<Order>().Add(Order);
            var result =await _unitOfWork.Complete();
            if (result <= 0)
            {
                return null;
            }
            //7- delete basket
            await _basketRepo.DeleteBasketAsync(basketId);
            //7- Return Order
            return Order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
