using System.ComponentModel.DataAnnotations;

namespace HttpService.Services.User.Models
{
    public class CreateUserCommandRequest
    {
        public string Name { get; set; }
        public string UserName { get; set; }

        [Required, StringLength(256), EmailAddress]
        public string Email { get; set; }
    }
}
