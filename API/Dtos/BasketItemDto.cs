using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        [Required,Range(0.1,double.MaxValue,ErrorMessage ="Price must be at least 0,1 $")]
        public decimal Price { get; set; }
        [Required,Range(1,double.MaxValue,ErrorMessage ="Quintity must be at least 1")]
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}