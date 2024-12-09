using ChartsAPI.Data;
using ChartsAPI.Models;
using ChartsAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductService>();
builder.Services.AddDbContext<ProductContext>();

builder.Services.AddScoped<FootballerService>();
builder.Services.AddDbContext<FootballerContext>();

// Add services to the container
builder.Services.AddSingleton<ConnectionService>();



// Viewleri dinamik olarak burda güncelledik prosedüler ise dbcontext sýnýflarýnda güncellenid iki farklý kullaným gösterildi
builder.Services.AddDbContext<CarSalesContext>((serviceProvider, options) =>
{
    var connectionService = serviceProvider.GetRequiredService<ConnectionService>();
    var connection = connectionService.GetConnection();
    var connectionString = $"Server={connection.ServerName};Database={connection.DatabaseName};Trusted_Connection={connection.TrustedConnection};";
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<BookStoreContext>((serviceProvider, options) =>
{
    var connectionService = serviceProvider.GetRequiredService<ConnectionService>();
    var connection = connectionService.GetConnection();
    var connectionString = $"Server={connection.ServerName};Database={connection.DatabaseName};Trusted_Connection={connection.TrustedConnection};";
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<MovieStoreContext>((serviceProvider, options) =>
{
    var connectionService = serviceProvider.GetRequiredService<ConnectionService>();
    var connection = connectionService.GetConnection();
    var connectionString = $"Server={connection.ServerName};Database={connection.DatabaseName};Trusted_Connection={connection.TrustedConnection};";
    options.UseSqlServer(connectionString);
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the app
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAllOrigins");
app.UseAuthorization();
app.MapControllers();

// Run the application
app.Run();
