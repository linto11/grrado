using Infrastructure;
using Application;
using Abstractions.Configuration;
using Utility;
using API.Middleware;
using Serilog;
using Scalar.AspNetCore;

Console.WriteLine("=== API Starting ===");

try
{
    Console.WriteLine("Creating WebApplicationBuilder...");
    var builder = WebApplication.CreateBuilder(args);

    // Configure Serilog
    Console.WriteLine("Configuring Serilog...");
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .WriteTo.Console()
        .Enrich.FromLogContext()
        .CreateLogger();

    builder.Host.UseSerilog();

    // Load error codes
    Console.WriteLine("Loading error codes...");
    var errorCodePath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "docs", "01-requirements", "error-codes.json");
    builder.Configuration.AddJsonFile(errorCodePath, optional: true, reloadOnChange: true);
    builder.Services.Configure<ErrorCodeConfiguration>(builder.Configuration);

    // Add services
    builder.Services.AddOpenApi();
    builder.Services.AddControllers();
    builder.Services.AddAntiforgery();

    // Add CORS
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });

    // Add dependency injection
    Console.WriteLine("Adding Infrastructure DI...");
    builder.Services.AddInfrastructureDI(builder.Configuration);
    builder.Services.AddApplicationDI();
    builder.Services.AddUtilityServices();

    var app = builder.Build();

    // ============================================================
    // MIDDLEWARE PIPELINE - Order follows ASP.NET Core best practices
    // (12 rules for security and performance)
    // ============================================================

    // 1. Exception/Error Handling (outermost - catches everything)
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    // 2. HSTS (production only - strict transport security)
    if (!app.Environment.IsDevelopment())
    {
        app.UseHsts();
    }

    // 3. HTTPS Redirection (early - ensures secure transport)
    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }

    // 4. Static Files (short-circuits for static content before routing)
    app.UseStaticFiles();

    // 5. Correlation ID (early - tags all requests for tracing)
    app.UseMiddleware<CorrelationIdMiddleware>();

    // 6. Request/Response Logging (after correlation ID is set)
    app.UseMiddleware<RequestResponseLoggingMiddleware>();

    // 7. Routing (must come before CORS, auth, and endpoints)
    app.UseRouting();

    // 8. CORS (after routing, before auth - handles preflight requests)
    app.UseCors();

    // 9. Authentication (establishes identity before authorization)
    app.UseAuthentication();

    // 10. Authorization (checks permissions after identity is established)
    app.UseAuthorization();

    // 11. Antiforgery (validates CSRF tokens after auth)
    app.UseAntiforgery();

    // 12. Endpoints (terminal - executes matched route)
    if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
    {
        app.MapOpenApi();
        app.MapScalarApiReference();
    }

    app.MapControllers();

    Console.WriteLine("Starting app...");
    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Fatal error: {ex.Message}");
    Environment.Exit(1);
}
finally
{
    Log.CloseAndFlush();
}
