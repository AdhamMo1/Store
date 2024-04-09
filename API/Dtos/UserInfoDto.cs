namespace API.Dtos
{
    public class UserInfoDto
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Token { get; set; }
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
