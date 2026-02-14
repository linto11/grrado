@echo off
echo GRRADO Microservices - Run Gateway
echo ====================================
echo.
echo Starting API Gateway on port 5100...
echo Ensure Docker infrastructure is running first:
echo   docker compose -f d:\_GRRADO\src\docker-compose.yml up -d
echo.
cd /d "d:\_GRRADO\src\app\server"
dotnet run --project gateway\ApiGateway\ApiGateway.csproj
pause
