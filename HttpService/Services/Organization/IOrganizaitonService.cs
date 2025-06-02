using HttpService.Models.Organization;
using Microsoft.AspNetCore.Http;

namespace HttpService.Services.Organization
{
    public interface IOrganizationService
    {
        ResponseId CreateOrganization(CreateOrganizationCommandRequest command);
        OrganizationResponse GetOrganization(int id);
        QueryOrganizationResponse QueryOrganizations(QueryOrganizationCommandRequest command);
        void UpdateOrganization(int id, UpdateOrganizationCommandRequest command);
        void DeleteOrganization(int id);
    }

}
