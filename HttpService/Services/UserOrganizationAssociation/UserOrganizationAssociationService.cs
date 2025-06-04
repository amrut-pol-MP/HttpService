using GrpcService;
using HttpService.Models.Common;
using HttpService.Services.UserOrganizationAssociation.Models;

namespace HttpService.Services.UserOrganizationAssociation
{
    public class UserOrganizationAssociationService : IUserOrganizationAssociationService
    {
        private readonly UserOrganizationAssociationServices.UserOrganizationAssociationServicesClient _client;

        public UserOrganizationAssociationService(UserOrganizationAssociationServices.UserOrganizationAssociationServicesClient client)
        {
            _client = client;
        }

        public ResponseId AssociateUserToOrganization(AssociateUserToOrganizationCommandRequest command)
        {
            try
            {
                var req = new AssociateUserToOrganizationRequest
                {
                    OrganizationId = command.OrganizationId,
                    UserId = command.UserId
                };

                var result = _client.AssociateUserToOrganization(req);
                return new ResponseId
                {
                    Id = result.UserToOrganizationAssociationId
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DisassociateUserFromOrganization(DisassociateUserFromOrganizationCommandRequest command)
        {
            var request = new DisassociateUserFromOrganizationRequest
            {
                OrganizationId = command.OrganizationId,
                UserId = command.UserId
            };
            _client.DisassociateUserFromOrganization(request);
        }

        public QueryUsersForOrganizationsResponse QueryUsersForOrganization(QueryUsersForOrganizationCommandRequest command)
        {
            var request = new QueryUsersForOrganizationRequest
            {
                OrganizationId = command.OrganizationId,
                Page = command.Page,
                PageSize = command.PageSize,
                OrderBy = command.OrderBy,
                Direction = command.Direction,
                QueryString = command.QueryString
            };

            var response = _client.QueryUsersForOrganization(request);
            var result = new QueryUsersForOrganizationsResponse
            {
                Pagination = new Pagination(response.Page, response.PageSize, response.Total),
                Result = response.Users.Select(x => new UsersForOrganizationResponse
                {
                    Id=x.Id,
                    Name = x.Name,
                    UserName = x.Username,
                    Email = x.Email,
                    CreatedAt = x.CreatedAt
                }).ToList()
            };
            return result;
        }
    }
}
