namespace HttpService.Services.User.Models
{
    public class UpdateUserCommandRequest
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
