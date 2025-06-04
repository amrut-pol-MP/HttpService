namespace HttpService.Services.UserOrganizationAssociation.Models
{
    public class AssociateUserToOrganizationCommandRequest
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
    }
}
