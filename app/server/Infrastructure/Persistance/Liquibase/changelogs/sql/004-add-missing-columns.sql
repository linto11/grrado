-- Add missing columns to align with EF models
-- Task 003: PostgreSQL Schema Alignment

-- Add missing columns to users table
ALTER TABLE "Users"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "FamilyType" VARCHAR(50) DEFAULT '';

-- Add missing columns to vehicles table
ALTER TABLE "Vehicles"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to garages table
ALTER TABLE "Garages"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to services table
ALTER TABLE "Services"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to service_histories table
ALTER TABLE "ServiceHistories"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to vehicle_issues table
ALTER TABLE "VehicleIssues"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to diagnostic_rules table
ALTER TABLE "DiagnosticRules"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Add missing columns to image_diagnostics table
ALTER TABLE "ImageDiagnostics"
ADD COLUMN IF NOT EXISTS "DeletedAt" TIMESTAMP NULL,
ADD COLUMN IF NOT EXISTS "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
ADD COLUMN IF NOT EXISTS "CreatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "UpdatedBy" VARCHAR(255),
ADD COLUMN IF NOT EXISTS "DeletedBy" VARCHAR(255);

-- Create chatbot tables if they don't exist
CREATE TABLE IF NOT EXISTS "ChatbotConversations" (
    "Id" UUID PRIMARY KEY,
    "UserId" UUID NOT NULL,
    "Title" VARCHAR(255),
    "Mode" VARCHAR(50),
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
    "DeletedAt" TIMESTAMP NULL,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255),
    "DeletedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ChatbotMessages" (
    "Id" UUID PRIMARY KEY,
    "ConversationId" UUID NOT NULL,
    "UserMessage" TEXT,
    "BotResponse" TEXT,
    "MessageType" VARCHAR(50),
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
    "DeletedAt" TIMESTAMP NULL,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255),
    "DeletedBy" VARCHAR(255),
    FOREIGN KEY ("ConversationId") REFERENCES "ChatbotConversations"("Id") ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS "ChatbotKnowledgeBase" (
    "Id" UUID PRIMARY KEY,
    "Topic" VARCHAR(255),
    "Content" TEXT,
    "Category" VARCHAR(100),
    "Visibility" VARCHAR(50),
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
    "DeletedAt" TIMESTAMP NULL,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255),
    "DeletedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "AiImageAnalyses" (
    "Id" UUID PRIMARY KEY,
    "ImagePath" VARCHAR(512),
    "AnalysisResult" TEXT,
    "Confidence" NUMERIC,
    "Status" VARCHAR(50),
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
    "DeletedAt" TIMESTAMP NULL,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255),
    "DeletedBy" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "AiUsageLogs" (
    "Id" UUID PRIMARY KEY,
    "UserId" UUID NOT NULL,
    "Feature" VARCHAR(100),
    "TokensUsed" INTEGER,
    "Cost" NUMERIC,
    "CreatedAt" TIMESTAMP NOT NULL,
    "UpdatedAt" TIMESTAMP NOT NULL,
    "IsDeleted" BOOLEAN NOT NULL DEFAULT false,
    "DeletedAt" TIMESTAMP NULL,
    "CreatedBy" VARCHAR(255),
    "UpdatedBy" VARCHAR(255),
    "DeletedBy" VARCHAR(255)
);

-- Create audit logging tables
CREATE TABLE IF NOT EXISTS "AuditLogs" (
    "Id" SERIAL PRIMARY KEY,
    "EntityType" VARCHAR(255),
    "EntityId" VARCHAR(255),
    "Action" VARCHAR(50),
    "OldValues" TEXT,
    "NewValues" TEXT,
    "UserId" VARCHAR(255),
    "Timestamp" TIMESTAMP NOT NULL DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS "ErrorLogs" (
    "Id" SERIAL PRIMARY KEY,
    "Message" TEXT,
    "Exception" TEXT,
    "StackTrace" TEXT,
    "Level" VARCHAR(50),
    "Timestamp" TIMESTAMP NOT NULL DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS "RequestResponseLogs" (
    "Id" SERIAL PRIMARY KEY,
    "RequestPath" VARCHAR(512),
    "RequestMethod" VARCHAR(10),
    "RequestBody" TEXT,
    "ResponseStatusCode" INTEGER,
    "ResponseBody" TEXT,
    "Timestamp" TIMESTAMP NOT NULL DEFAULT NOW(),
    "UserId" VARCHAR(255),
    "CorrelationId" VARCHAR(255)
);

CREATE TABLE IF NOT EXISTS "ActivityLogs" (
    "Id" SERIAL PRIMARY KEY,
    "UserId" VARCHAR(255),
    "Activity" VARCHAR(255),
    "Details" TEXT,
    "Timestamp" TIMESTAMP NOT NULL DEFAULT NOW()
);

-- Create indexes for performance
CREATE INDEX IF NOT EXISTS "IX_Users_Email" ON "Users"("Email");
CREATE INDEX IF NOT EXISTS "IX_Users_IsDeleted" ON "Users"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_Vehicles_UserId" ON "Vehicles"("UserId");
CREATE INDEX IF NOT EXISTS "IX_Vehicles_IsDeleted" ON "Vehicles"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_Garages_City" ON "Garages"("City");
CREATE INDEX IF NOT EXISTS "IX_Garages_IsDeleted" ON "Garages"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_Services_GarageId" ON "Services"("GarageId");
CREATE INDEX IF NOT EXISTS "IX_Services_IsDeleted" ON "Services"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_ServiceHistories_VehicleId" ON "ServiceHistories"("VehicleId");
CREATE INDEX IF NOT EXISTS "IX_ServiceHistories_GarageId" ON "ServiceHistories"("GarageId");
CREATE INDEX IF NOT EXISTS "IX_ServiceHistories_IsDeleted" ON "ServiceHistories"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_VehicleIssues_Severity" ON "VehicleIssues"("Severity");
CREATE INDEX IF NOT EXISTS "IX_VehicleIssues_IsDeleted" ON "VehicleIssues"("IsDeleted");
CREATE INDEX IF NOT EXISTS "IX_DiagnosticRules_LogicType" ON "DiagnosticRules"("LogicType");
CREATE INDEX IF NOT EXISTS "IX_ImageDiagnostics_Urgency" ON "ImageDiagnostics"("Urgency");
CREATE INDEX IF NOT EXISTS "IX_ChatbotConversations_UserId" ON "ChatbotConversations"("UserId");
CREATE INDEX IF NOT EXISTS "IX_ChatbotMessages_ConversationId" ON "ChatbotMessages"("ConversationId");
CREATE INDEX IF NOT EXISTS "IX_AuditLogs_EntityType" ON "AuditLogs"("EntityType");
CREATE INDEX IF NOT EXISTS "IX_ErrorLogs_Timestamp" ON "ErrorLogs"("Timestamp");
