using System.ComponentModel;

namespace API.Dtos
{
    public class UpdateUserDto
    {
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }
    }
}
