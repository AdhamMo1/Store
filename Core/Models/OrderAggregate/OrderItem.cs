using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
            
        }
        public OrderItem(ProductItemOrdered itemOrdered,int quintity,decimal price)
        {
            ItemOrderd = itemOrdered;
            Quintity = quintity;
            Price = price;
        }
        
        public ProductItemOrdered ItemOrderd { get; set; }
        public int ItemOrderdId { get; set; }
        public int Quintity { get; set; }
        public decimal Price { get; set; }
    }
}
