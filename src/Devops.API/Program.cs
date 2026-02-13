using Devops.API;
using Devops.Application;
using Devops.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ProductService>();
var app = builder.Build();

if (args.Contains("--migrate"))
{
    await MigrationRunner.RunMigrationAsync(app.Services);
    return;
}

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();