using HttpService.Models.Common;

namespace HttpService.Services.User.Models
{
    public class QueryUserResponse
    {
        public Pagination Pagination { get; set; }
        public List<UserResponse> Result { get; set; }
    }
}
