using GrpcService;

namespace HttpService.Configuration
{
    public static class GrpcClientRegistrationExtensions
    {
        public static IServiceCollection AddGrpcClients(this IServiceCollection services, string baseAddress)
        {
            var uri = new Uri(baseAddress);

            services.AddGrpcClient<OrganizationServices.OrganizationServicesClient>(o => o.Address = uri);
            services.AddGrpcClient<UserServices.UserServicesClient>(o => o.Address = uri);
            services.AddGrpcClient<UserOrganizationAssociationServices.UserOrganizationAssociationServicesClient>(o => o.Address = uri);

            return services;
        }
    }
}
