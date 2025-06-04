using HttpService.Models.Common;

namespace HttpService.Services.Organization.Models
{
    public class QueryOrganizationResponse
    {
        public Pagination Pagination { get; set; }
        public List<OrganizationResponse> Result { get; set; }
    }
}
