using Grpc.Net.Client;
using HttpService;
using HttpService.Services.Organization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<OrganizationServices.OrganizationServicesClient>(o =>
{
    o.Address = new Uri("https://localhost:5117"); // gRPC endpoint
});

// Add services.
builder.Services.AddScoped<IOrganizationService, OrganizationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
