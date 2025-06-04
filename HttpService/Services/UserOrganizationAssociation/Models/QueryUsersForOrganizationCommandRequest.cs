﻿namespace HttpService.Services.UserOrganizationAssociation.Models
{
    public class QueryUsersForOrganizationCommandRequest
    {
        public int OrganizationId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? OrderBy { get; set; }
        public string? Direction { get; set; }
        public string? QueryString { get; set; }
    }
}
