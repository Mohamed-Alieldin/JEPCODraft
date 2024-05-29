
using JEPCO.Infrastructure.Extensions;
using JEPCO.Application.Extensions;
using JEPCO.Shared.Extensions;
using Hellang.Middleware.ProblemDetails;
using JEPCO.Application.Exceptions;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.Extensions.Configuration;
using Keycloak.AuthServices.Common;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add Keycloak services
builder.Services.AddKeycloakWebApiAuthentication(builder.Configuration);
builder.Services.AddAuthorization()
    .AddKeycloakAuthorization(options => {
        //options.EnableRolesMapping = RolesClaimTransformationSource.Realm;
       // options.RoleClaimType = KeycloakConstants.RoleClaimType;
    })
    .AddAuthorizationBuilder()
    //.AddPolicy(
    //    "AdminPolicy",
    //    policy => policy.RequireRealmRoles("Realm_Admin"))
    //.AddPolicy("", policy => policy.RequireResourceRoles("Admin"))
    ;

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("AdminAndUser", builder =>
//    {
//        builder
//               .RequireRealmRoles("Realm_Admin") // Realm role is fetched from token
//               .RequireResourceRoles("Admin"); // Resource/Client role is fetched from token
//    });
//});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add shared extension methods
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.RegisterApplicationServices(builder.Configuration);
builder.Services.RegisterSharedServices(builder.Configuration);


// apply problem details class for exceptions
// only include exception details in dev or stag Envs
builder.Services.AddProblemDetails(opt => {
    opt.IncludeExceptionDetails = (ctx, ex) => builder.Environment.IsDevelopment() || builder.Environment.IsStaging();
    opt.Map<CustomException>(exception => new Microsoft.AspNetCore.Mvc.ProblemDetails()
    {
        Title = exception.Title,
        Status = exception.Status,
        Detail = exception.Detail,
        Type = exception.Type,
    });
});





var app = builder.Build();

// migrate db to the latest version
JEPCO.Infrastructure.Extensions.StartupExtension.MigrateDatabaseToLatestVersion(app.Services);

// add shared middlewares
app.AddSharedMiddlewares();

// user problem details class middleware
app.UseProblemDetails();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration.GetValue<string>("AllowedHosts").Split(";"));
});

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
