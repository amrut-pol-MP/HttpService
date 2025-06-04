using GrpcService;
using HttpService.Models.Common;
using HttpService.Services.User.Models;

namespace HttpService.Services.User
{
    public class UserService : IUserService
    {
        private readonly UserServices.UserServicesClient _client;

        public UserService(UserServices.UserServicesClient client)
        {
            _client = client;
        }
        public ResponseId CreateUser(CreateUserCommandRequest command)
        {
            try
            {
                var req = new CreateUserRequest
                {
                    Name = command.Name,
                    UserName = command.UserName,
                    Email = command.Email
                };

                var result = _client.CreateUser(req);
                return new ResponseId
                {
                    Id = result.UserId
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public UserResponse GetUser(int id)
        {
            var req = new GetUserRequest
            {
                Id = id
            };

            var response = _client.GetUser(req);
            var result = new UserResponse
            {
                Name = response.Name,
                UserName = response.Username,
                Email = response.Email,
                CreatedAt = response.CreatedAt,
                UpdatedAt = response.UpdatedAt
            };
            return result;
        }

        public QueryUserResponse QueryUsers(QueryUserCommandRequest command)
        {
            var request = new QueryUsersRequest
            {
                Page = command.Page,
                PageSize = command.PageSize,
                OrderBy = command.OrderBy,
                Direction = command.Direction,
                QueryString = command.QueryString
            };

            var response = _client.QueryUsers(request);
            var result = new QueryUserResponse
            {
                Pagination = new Pagination(response.Page, response.PageSize, response.Total),
                Result = response.Users.Select(x => new UserResponse
                {
                    Name = x.Name,
                    UserName = x.Username,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList()
            };
            return result;
        }

        public void UpdateUser(int id, UpdateUserCommandRequest command)
        {
            var request = new UpdateUserRequest
            {
                Id = id,
                Name = command.Name,
                Username = command.UserName,
                Email = command.Email
            };
            _client.UpdateUser(request);
        }

        public void DeleteUser(int id)
        {
            var request = new DeleteUserRequest
            {
                Id = id
            };

            _client.DeleteUser(request);
        }
    }
}
