using HttpService.Configuration;
using HttpService.Services.Organization;
using HttpService.Services.User;
using HttpService.Services.UserOrganizationAssociation;

var builder = WebApplication.CreateBuilder(args);

// gRPC services
builder.Services.AddGrpcClients(builder.Configuration["GrpcServices:ServiceUrl"]);

// Add services.
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserOrganizationAssociationService, UserOrganizationAssociationService>();

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
