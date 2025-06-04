
using HttpService.Models.Common;
using HttpService.Services.User.Models;

namespace HttpService.Services.User
{
    public interface IUserService
    {
        ResponseId CreateUser(CreateUserCommandRequest command);
        UserResponse GetUser(int id);
        QueryUserResponse QueryUsers(QueryUserCommandRequest command);
        void UpdateUser(int id, UpdateUserCommandRequest command);
        void DeleteUser(int id);
    }
}
