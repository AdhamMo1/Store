using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    public class Order : BaseEntity
    {
        public Order() { }
        public Order(string buyerEmail,Address shippToAddress, DeliveryMethod deliveryMethod, List<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShippToAddress = shippToAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }= DateTimeOffset.Now;
        public Address ShippToAddress { get; set; }
        [ForeignKey("ShippToAddress")]
        public int ShippToAddressId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal SubTotal { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string? PaymentIntentId { get; set; }
        public decimal GetTotal()
        {
            return SubTotal + DeliveryMethod.Price;
        }

    }
}
