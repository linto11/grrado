using GRRADO.Shared.Infrastructure;
using GRRADO.Shared.Infrastructure.Middleware;
using LoggingService.Application;
using LoggingService.Infrastructure;
using Serilog;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo.Console().Enrich.FromLogContext().CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddSharedInfrastructure();
builder.Services.AddLoggingInfrastructure(builder.Configuration);
builder.Services.AddLoggingApplication();

var app = builder.Build();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseMiddleware<CorrelationIdMiddleware>();
app.UseRouting();
app.UseCors();
if (app.Environment.IsDevelopment()) { app.MapOpenApi(); app.MapScalarApiReference(); }
app.MapControllers();
await app.RunAsync();
