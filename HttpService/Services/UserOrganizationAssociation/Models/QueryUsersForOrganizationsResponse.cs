using HttpService.Models.Common;

namespace HttpService.Services.UserOrganizationAssociation.Models
{
    public class QueryUsersForOrganizationsResponse
    {
        public Pagination Pagination { get; set; }
        public List<UsersForOrganizationResponse> Result { get; set; }
    }
}
