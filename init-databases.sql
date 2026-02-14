-- GRRADO Microservices Database Initialization
-- Creates separate databases for each microservice (database-per-service pattern)
-- This script runs automatically on first PostgreSQL container startup

-- Microservice databases
CREATE DATABASE grrado_user_db;
CREATE DATABASE grrado_vehicle_db;
CREATE DATABASE grrado_garage_db;
CREATE DATABASE grrado_service_history_db;
CREATE DATABASE grrado_chatbot_db;
CREATE DATABASE grrado_diagnostics_db;
CREATE DATABASE grrado_logging_db;

-- Keycloak database (if not exists)
SELECT 'CREATE DATABASE keycloak_db' WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'keycloak_db')\gexec

-- Grant privileges
GRANT ALL PRIVILEGES ON DATABASE grrado_user_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_vehicle_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_garage_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_service_history_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_chatbot_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_diagnostics_db TO postgres;
GRANT ALL PRIVILEGES ON DATABASE grrado_logging_db TO postgres;
