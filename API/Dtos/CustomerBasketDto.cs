using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class CustomerBasketDto
    {
        [Key, Required]
        public string Id { get; set; }
        public IList<BasketItemDto> BasketItems { get; set; } = new List<BasketItemDto>();
    }
}
