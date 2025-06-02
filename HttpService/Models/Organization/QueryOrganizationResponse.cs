using HttpService.Models.Common;

namespace HttpService.Models.Organization
{
    public class QueryOrganizationResponse
    {
        public Pagination Pagination { get; set; }
        public List<OrganizationResponse> Result { get; set; }
    }
}
