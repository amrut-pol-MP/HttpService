namespace HttpService.Services.UserOrganizationAssociation.Models
{
    public class UsersForOrganizationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public long CreatedAt { get; set; }
    }
}
