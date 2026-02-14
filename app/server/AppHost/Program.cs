using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Get the AppHost directory and compute solution root relative to it
var appHostDir = AppContext.BaseDirectory;
var solutionRoot = Path.GetFullPath(Path.Combine(appHostDir, "..", "..", ".."));
var serverRoot = Path.Combine(solutionRoot, "app", "server");

// Helper function to get project path
string GetProjectPath(string relativePath) => Path.Combine(serverRoot, relativePath);

// Services reference docker-compose infrastructure via environment variables/app configuration
// Docker-compose containers (postgres, redis, rabbitmq, keycloak) must be running:
//   docker-compose up -d

// Add API Gateway (entry point)
var gateway = builder.AddProject("gateway", GetProjectPath("gateway/ApiGateway/ApiGateway.csproj"))
    .WithHttpEndpoint(port: 5100, name: "http");

// Add all microservices
var userService = builder.AddProject("user-service", GetProjectPath("services/UserService/UserService.API/UserService.API.csproj"))
    .WithHttpEndpoint(port: 5101, name: "http");

var vehicleService = builder.AddProject("vehicle-service", GetProjectPath("services/VehicleService/VehicleService.API/VehicleService.API.csproj"))
    .WithHttpEndpoint(port: 5102, name: "http");

var garageService = builder.AddProject("garage-service", GetProjectPath("services/GarageService/GarageService.API/GarageService.API.csproj"))
    .WithHttpEndpoint(port: 5103, name: "http");

var serviceHistoryService = builder.AddProject("service-history-service", GetProjectPath("services/ServiceHistoryService/ServiceHistoryService.API/ServiceHistoryService.API.csproj"))
    .WithHttpEndpoint(port: 5104, name: "http");

var chatbotService = builder.AddProject("chatbot-service", GetProjectPath("services/ChatbotService/ChatbotService.API/ChatbotService.API.csproj"))
    .WithHttpEndpoint(port: 5105, name: "http");

var diagnosticsService = builder.AddProject("diagnostics-service", GetProjectPath("services/DiagnosticsService/DiagnosticsService.API/DiagnosticsService.API.csproj"))
    .WithHttpEndpoint(port: 5106, name: "http");

var loggingService = builder.AddProject("logging-service", GetProjectPath("services/LoggingService/LoggingService.API/LoggingService.API.csproj"))
    .WithHttpEndpoint(port: 5107, name: "http");

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
