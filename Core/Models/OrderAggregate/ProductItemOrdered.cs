using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.OrderAggregate
{
    
    public class ProductItemOrdered : BaseEntity
    {
        public ProductItemOrdered()
        {
            
        }
        public ProductItemOrdered(int productItemId ,string productName , string productUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            ProductUrl = productUrl;
        }
        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
    }
}
