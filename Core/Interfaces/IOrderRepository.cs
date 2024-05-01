using Core.Models.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(string buyerEmail,int deliveryMethodId,string basketId,Address ShippToAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string Email);
        Task<Order> GetOrderByIdAsync(int id , string  buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
