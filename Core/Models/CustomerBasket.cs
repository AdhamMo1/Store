using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CustomerBasket
    {
        public CustomerBasket()
        {
            
        }
        public CustomerBasket(string id)
        {
            Id = id;
        }
        [Key,Required]
        public string Id { get; set; }
        public IReadOnlyList<BasketItem> BasketItems { get; set; } = new List<BasketItem>();
    }
}
