
using JEPCO.Infrastructure.Extensions;
using JEPCO.Application.Extensions;
using JEPCO.Shared.Extensions;
using Hellang.Middleware.ProblemDetails;
using JEPCO.Application.Exceptions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add extension methods
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

app.UseAuthorization();

app.MapControllers();

app.Run();
