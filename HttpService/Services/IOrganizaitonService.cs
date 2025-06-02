using HttpService.Models.Organization;
using Microsoft.AspNetCore.Http;

namespace HttpService.Services
{
    public interface IOrganizationService
    {
        ResponseId CreateOrganization(Models.Organization.CreateOrganizationCommandRequest command);
        OrganizationResponse GetOrganization(int id);
        QueryOrganizationResponse QueryOrganizations(QueryOrganizationCommandRequest command);
        void UpdateOrganization(int id, UpdateOrganizationCommandRequest command);
        void DeleteOrganization(int id);
    }

}
