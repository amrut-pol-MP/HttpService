namespace HttpService.Models.Organization
{
    public class OrganizationResponse
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public long CreatedAt { get; set; }
        public long? UpdatedAt { get; set; }
    }
}
