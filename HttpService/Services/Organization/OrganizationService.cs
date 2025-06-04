using Grpc.Core;
using GrpcService;
using HttpService.Models.Common;
using HttpService.Services.Organization.Models;

namespace HttpService.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly OrganizationServices.OrganizationServicesClient _client;

        public OrganizationService(OrganizationServices.OrganizationServicesClient client)
        {
            _client = client;
        }

        public ResponseId CreateOrganization(CreateOrganizationCommandRequest command)
        {
            try
            {
                var req = new CreateOrganizationRequest
                {
                    Name = command.Name,
                    Address = command.Address
                };

                var result = _client.CreateOrganization(req);
                return new ResponseId
                {
                    Id = result.OrganizationId
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public OrganizationResponse GetOrganization(int id)
        {
            var req = new GetOrganizationRequest
            {
                Id = id
            };

            var response = _client.GetOrganization(req);
            var result = new OrganizationResponse
            {
                Name = response.Name,
                Address = response.Address,
                CreatedAt = response.CreatedAt,
                UpdatedAt = response.UpdatedAt
            };
            return result;
        }

        public QueryOrganizationResponse QueryOrganizations(QueryOrganizationCommandRequest command)
        {
            var request = new QueryOrganizationsRequest
            {
                Page = command.Page,
                PageSize = command.PageSize,
                OrderBy = command.OrderBy,
                Direction = command.Direction,
                QueryString = command.QueryString
            };

            var response = _client.QueryOrganizations(request);
            var result = new QueryOrganizationResponse
            {
                Pagination = new Pagination(response.Page, response.PageSize, response.Total),
                Result = response.OrganizationList.Select(x => new OrganizationResponse
                {
                    Name = x.Name,
                    Address = x.Address,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList()
            };
            return result;
        }

        public void UpdateOrganization(int id, UpdateOrganizationCommandRequest command)
        {
            var request = new UpdateOrganizationRequest
            {
                Id = id,
                Name = command.Name,
                Address = command.Address
            };
            _client.UpdateOrganization(request);
        }

        public void DeleteOrganization(int id)
        {
            var request = new DeleteOrganizationRequest
            {
                Id = id
            };

            _client.DeleteOrganization(request);
        }
    }
}

