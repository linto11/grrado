-- Vehicle Service Database Schema
-- This file contains all table definitions

-- Users table
CREATE TABLE IF NOT EXISTS "Users" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Name" VARCHAR(255) NOT NULL,
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "PhoneNumber" VARCHAR(20),
    "City" VARCHAR(100),
    "Address" VARCHAR(500),
    "Pincode" VARCHAR(10),
    "UserType" INTEGER NOT NULL,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_Users_Name_Email" ON "Users"("Name", "Email");

-- Vehicles table
CREATE TABLE IF NOT EXISTS "Vehicles" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID NOT NULL REFERENCES "Users"("Id"),
    "Brand" VARCHAR(100) NOT NULL,
    "Model" VARCHAR(100) NOT NULL,
    "Color" VARCHAR(50),
    "RegistrationNumber" VARCHAR(50) NOT NULL UNIQUE,
    "Year" INTEGER,
    "City" VARCHAR(100),
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_Vehicles_Brand_Model_City" ON "Vehicles"("Brand", "Model", "City");
CREATE INDEX IF NOT EXISTS "IX_Vehicles_UserId" ON "Vehicles"("UserId");

-- Garages table
CREATE TABLE IF NOT EXISTS "Garages" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Name" VARCHAR(255) NOT NULL,
    "Email" VARCHAR(255) NOT NULL UNIQUE,
    "PhoneNumber" VARCHAR(20),
    "City" VARCHAR(100) NOT NULL,
    "Address" VARCHAR(500),
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_Garages_City" ON "Garages"("City");

-- Services table
CREATE TABLE IF NOT EXISTS "Services" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "GarageId" UUID NOT NULL REFERENCES "Garages"("Id"),
    "Name" VARCHAR(255) NOT NULL,
    "Description" TEXT,
    "EstimatedCost" DECIMAL(18,2),
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_Services_GarageId" ON "Services"("GarageId");

-- VehicleIssues table
CREATE TABLE IF NOT EXISTS "VehicleIssues" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "VehicleId" UUID NOT NULL REFERENCES "Vehicles"("Id"),
    "IssueName" VARCHAR(255) NOT NULL,
    "Description" TEXT,
    "Severity" INTEGER,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_VehicleIssues_VehicleId" ON "VehicleIssues"("VehicleId");

-- DiagnosticRules table
CREATE TABLE IF NOT EXISTS "DiagnosticRules" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "RuleCode" VARCHAR(100) NOT NULL UNIQUE,
    "RuleDescription" TEXT,
    "Symptoms" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

-- ServiceHistories table
CREATE TABLE IF NOT EXISTS "ServiceHistories" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "VehicleId" UUID NOT NULL REFERENCES "Vehicles"("Id"),
    "ServiceId" UUID REFERENCES "Services"("Id"),
    "ServiceDate" TIMESTAMP,
    "Cost" DECIMAL(18,2),
    "Notes" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE INDEX IF NOT EXISTS "IX_ServiceHistories_VehicleId" ON "ServiceHistories"("VehicleId");

-- ImageDiagnostics table
CREATE TABLE IF NOT EXISTS "ImageDiagnostics" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "VehicleIssueId" UUID REFERENCES "VehicleIssues"("Id"),
    "ImageUrl" VARCHAR(500),
    "AnalysisResult" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

-- Chatbot entities
CREATE TABLE IF NOT EXISTS "ChatbotConversations" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID REFERENCES "Users"("Id"),
    "Title" VARCHAR(255),
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ChatbotMessages" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ConversationId" UUID NOT NULL REFERENCES "ChatbotConversations"("Id"),
    "Role" VARCHAR(50),
    "Content" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ChatbotKnowledgeBase" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "Topic" VARCHAR(255),
    "Content" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "AiImageAnalyses" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ImageUrl" VARCHAR(500),
    "AnalysisResult" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "AiUsageLogs" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID REFERENCES "Users"("Id"),
    "ApiName" VARCHAR(255),
    "TokensUsed" INTEGER,
    "Cost" DECIMAL(18,2),
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

-- Error message table for API responses
CREATE TABLE IF NOT EXISTS "ErrorMessages" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ErrorCode" VARCHAR(50) NOT NULL UNIQUE,
    "Message" VARCHAR(500) NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

-- Logging tables
CREATE TABLE IF NOT EXISTS "AuditLogs" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID,
    "Action" VARCHAR(255),
    "EntityType" VARCHAR(255),
    "EntityId" UUID,
    "OldValues" TEXT,
    "NewValues" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ErrorLogs" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "ErrorCode" VARCHAR(50),
    "Message" TEXT,
    "StackTrace" TEXT,
    "UserId" UUID,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "RequestResponseLogs" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "RequestMethod" VARCHAR(10),
    "RequestPath" VARCHAR(500),
    "RequestBody" TEXT,
    "ResponseStatusCode" INTEGER,
    "ResponseBody" TEXT,
    "UserId" UUID,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ActivityLogs" (
    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
    "UserId" UUID,
    "Activity" VARCHAR(255),
    "Details" TEXT,
    "Status" INTEGER NOT NULL DEFAULT 0,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT FALSE,
    "CreatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "UpdatedAt" TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255)
);
