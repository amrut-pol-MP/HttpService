namespace HttpService.Services.User.Models
{
    public class UserResponse
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long CreatedAt { get; set; }
        public long? UpdatedAt { get; set; }
    }
}
