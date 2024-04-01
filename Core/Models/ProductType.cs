using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Core.Models
{
    public class ProductType : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [JsonIgnore]
        public IEnumerable<Product> products { get; set; }
    }
}