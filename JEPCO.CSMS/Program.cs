
using JEPCO.Infrastructure.Extensions;
using JEPCO.Application.Extensions;
using JEPCO.Shared.Extensions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add extension methods
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.RegisterApplicationServices(builder.Configuration);
builder.Services.RegisterSharedServices(builder.Configuration);






var app = builder.Build();

// add shared middlewares
app.AddSharedMiddlewares();


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
