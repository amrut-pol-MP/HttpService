using GrpcService;
using HttpService;
using HttpService.Services.Organization;
using HttpService.Services.User;

var builder = WebApplication.CreateBuilder(args);

// gRPC services
builder.Services.AddGrpcClient<OrganizationServices.OrganizationServicesClient>(o =>
{
    o.Address = new Uri("https://localhost:5117");
});
builder.Services.AddGrpcClient<UserServices.UserServicesClient>(o =>
{
    o.Address = new Uri("https://localhost:5117");
});

// Add services.
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IUserService, UserService>();

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
