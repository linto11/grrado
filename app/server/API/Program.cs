using Infrastructure.Persistance.DBContext;
using Infrastructure.Persistance;
using Infrastructure;
using Application;
using Application.Common.Configuration;
using Utility;
using Serilog;
using API.Middleware;
using Scalar.AspNetCore;

await RunAsync();

async Task RunAsync()
{
Console.WriteLine("=== API Starting ===");

try
{
Console.WriteLine("Creating WebApplicationBuilder...");
var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("WebApplicationBuilder created successfully");

// Configure Serilog as the primary logger
Console.WriteLine("Configuring Serilog...");
try
{
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console()
        .Enrich.FromLogContext()
        .CreateLogger();
    Console.WriteLine("Serilog configured successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Serilog configuration error: {ex.Message}");
}

builder.Host.UseSerilog();

// Load error code configuration from JSON
Console.WriteLine("Loading error codes...");
var errorCodePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "docs", "01-requirements", "error-codes.json");
try
{
    builder.Configuration.AddJsonFile(errorCodePath, optional: false, reloadOnChange: true);
    builder.Services.Configure<ErrorCodeConfiguration>(builder.Configuration);
    Console.WriteLine("Error codes loaded successfully");
}
catch (Exception ex)
{
    Console.WriteLine($"Error code loading failed: {ex.Message}");
}

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add layer-specific dependency injection
try
{
    Console.WriteLine("Adding Infrastructure DI...");
    builder.Services.AddInfrastructureDI(builder.Configuration);
    Console.WriteLine("Infrastructure DI added");
}
catch (Exception ex)
{
    Console.WriteLine($"Infrastructure DI error: {ex.Message}");
    Console.WriteLine("Continuing without Infrastructure DI");
}

try
{
    builder.Services.AddApplicationDI();
}
catch (Exception ex)
{
    Console.WriteLine($"Warning: Application DI failed: {ex.Message}");
}

try
{
    builder.Services.AddUtilityServices();
}
catch (Exception ex)
{
    Console.WriteLine($"Warning: Utility DI failed: {ex.Message}");
}

var app = builder.Build();

// Seed data on startup
try
{
    Console.WriteLine("Attempting to seed database...");
    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<VehicleServiceDbContext>();
        var seedingService = scope.ServiceProvider.GetRequiredService<IDataSeedingService>();
        
        try
        {
            await seedingService.SeedDataAsync(dbContext);
            Console.WriteLine("Database seeding completed successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Warning: Error seeding data: {ex.Message}");
            Log.Warning("Error seeding data: {Exception}", ex.Message);
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Warning: Could not initialize seeding: {ex.Message}");
}

// Configure the HTTP request pipeline.
// Enable Scalar - Modern API documentation with beautiful UI
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Disable HTTPS redirection for local development - we're using HTTP on port 5000
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

// Enable CORS
app.UseCors("AllowAll");

// CorrelationId middleware to trace requests across layers
app.UseMiddleware<CorrelationIdMiddleware>();

// Request/Response logging middleware
app.UseMiddleware<RequestResponseLoggingMiddleware>();

// Exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Map controllers
app.MapControllers();

Console.WriteLine("Starting app...");
app.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"Fatal error: {ex}");
    Console.WriteLine($"Message: {ex.Message}");
    Console.WriteLine($"StackTrace: {ex.StackTrace}");
    Environment.Exit(1);
}
}
