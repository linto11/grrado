using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

// Services reference docker-compose infrastructure via environment variables/app configuration
// Docker-compose containers (postgres, redis, rabbitmq, keycloak) must be running:
//   docker-compose up -d

// Add API Gateway (entry point)
var gateway = builder.AddProject("gateway", "../gateway/ApiGateway/ApiGateway.csproj")
    .WithHttpEndpoint(port: 5100, name: "http");

// Add all microservices
var userService = builder.AddProject("user-service", "../services/UserService/UserService.API/UserService.API.csproj")
    .WithHttpEndpoint(port: 5101, name: "http");

var vehicleService = builder.AddProject("vehicle-service", "../services/VehicleService/VehicleService.API/VehicleService.API.csproj")
    .WithHttpEndpoint(port: 5102, name: "http");

var garageService = builder.AddProject("garage-service", "../services/GarageService/GarageService.API/GarageService.API.csproj")
    .WithHttpEndpoint(port: 5103, name: "http");

var serviceHistoryService = builder.AddProject("service-history-service", "../services/ServiceHistoryService/ServiceHistoryService.API/ServiceHistoryService.API.csproj")
    .WithHttpEndpoint(port: 5104, name: "http");

var chatbotService = builder.AddProject("chatbot-service", "../services/ChatbotService/ChatbotService.API/ChatbotService.API.csproj")
    .WithHttpEndpoint(port: 5105, name: "http");

var diagnosticsService = builder.AddProject("diagnostics-service", "../services/DiagnosticsService/DiagnosticsService.API/DiagnosticsService.API.csproj")
    .WithHttpEndpoint(port: 5106, name: "http");

var loggingService = builder.AddProject("logging-service", "../services/LoggingService/LoggingService.API/LoggingService.API.csproj")
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
