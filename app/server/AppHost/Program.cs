using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Services reference docker-compose infrastructure via environment variables/app configuration
// Docker-compose containers (postgres, redis, rabbitmq, keycloak) must be running:
//   docker-compose up -d

// Resolve project paths relative to AppHost project directory
// Binary location: app/server/AppHost/bin/Debug/net10.0
// Need to navigate: net10.0 -> Debug -> bin -> AppHost -> app/server
var appHostDir = AppContext.BaseDirectory;
var serverDir = Path.GetFullPath(Path.Combine(appHostDir, "..", "..", "..", ".."));
string GetProjectPath(string relativePath) => Path.Combine(serverDir, relativePath);

// Add API Gateway (entry point)
var gateway = builder.AddProject("gateway", GetProjectPath("gateway/ApiGateway/ApiGateway.csproj"))
    .WithHttpEndpoint(port: 5100, name: "gateway-http");

// Add all microservices
var userService = builder.AddProject("user-service", GetProjectPath("services/UserService/UserService.API/UserService.API.csproj"))
    .WithHttpEndpoint(port: 5101, name: "user-http");

var vehicleService = builder.AddProject("vehicle-service", GetProjectPath("services/VehicleService/VehicleService.API/VehicleService.API.csproj"))
    .WithHttpEndpoint(port: 5102, name: "vehicle-http");

var garageService = builder.AddProject("garage-service", GetProjectPath("services/GarageService/GarageService.API/GarageService.API.csproj"))
    .WithHttpEndpoint(port: 5103, name: "garage-http");

var serviceHistoryService = builder.AddProject("service-history-service", GetProjectPath("services/ServiceHistoryService/ServiceHistoryService.API/ServiceHistoryService.API.csproj"))
    .WithHttpEndpoint(port: 5104, name: "servicehistory-http");

var chatbotService = builder.AddProject("chatbot-service", GetProjectPath("services/ChatbotService/ChatbotService.API/ChatbotService.API.csproj"))
    .WithHttpEndpoint(port: 5105, name: "chatbot-http");

var diagnosticsService = builder.AddProject("diagnostics-service", GetProjectPath("services/DiagnosticsService/DiagnosticsService.API/DiagnosticsService.API.csproj"))
    .WithHttpEndpoint(port: 5106, name: "diagnostics-http");

var loggingService = builder.AddProject("logging-service", GetProjectPath("services/LoggingService/LoggingService.API/LoggingService.API.csproj"))
    .WithHttpEndpoint(port: 5107, name: "logging-http");

// Configure gateway to reference all services for service discovery
gateway
    .WithReference(userService)
    .WithReference(vehicleService)
    .WithReference(garageService)
    .WithReference(serviceHistoryService)
    .WithReference(chatbotService)
    .WithReference(diagnosticsService)
    .WithReference(loggingService);

var app = builder.Build();

await app.RunAsync();
