-- Setup script for PostgreSQL database
-- Run this as the postgres user

-- Create migration_user with password
CREATE USER migration_user WITH PASSWORD 'migration123';

-- Create the database
CREATE DATABASE vehicle_service_db 
  OWNER postgres 
  ENCODING 'UTF8' 
  TEMPLATE template0;

-- Connect to the new database and grant permissions
GRANT ALL PRIVILEGES ON DATABASE vehicle_service_db TO migration_user;
GRANT ALL PRIVILEGES ON SCHEMA public TO migration_user;

-- Create extension for UUID support
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

-- Set search_path
ALTER ROLE migration_user SET search_path TO public;

COMMIT;
