using System.ComponentModel.DataAnnotations;

namespace HttpService.Services.Organization.Models
{
    public class QueryOrganizationCommandRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Direction { get; set; }
        public string? QueryString { get; set; }
    }
}
