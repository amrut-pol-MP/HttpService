using HttpService.Models.Common;
using HttpService.Services.UserOrganizationAssociation.Models;

namespace HttpService.Services.UserOrganizationAssociation
{
    public interface IUserOrganizationAssociationService
    {
        ResponseId AssociateUserToOrganization(AssociateUserToOrganizationCommandRequest command);
        void DisassociateUserFromOrganization(DisassociateUserFromOrganizationCommandRequest command);
        QueryUsersForOrganizationsResponse QueryUsersForOrganization(QueryUsersForOrganizationCommandRequest command);
    }
}
