namespace HttpService.Services.UserOrganizationAssociation.Models
{
    public class DisassociateUserFromOrganizationCommandRequest
    {
        public int OrganizationId { get; set; }
        public int UserId { get; set; }
    }
}
