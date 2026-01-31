-- Seed Vehicles with actual columns
INSERT INTO "Vehicles" ("Id", "UserId", "Brand", "Model", "Color", "RegistrationNumber", "Year", "City", "Status", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('650e8400-e29b-41d4-a716-446655440001', '550e8400-e29b-41d4-a716-446655440001', 'Toyota', 'Camry', 'Silver', 'ABC-123', 2020, 'Dubai', 1, false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440002', '550e8400-e29b-41d4-a716-446655440002', 'BMW', '320i', 'Black', 'DEF-456', 2021, 'Abu Dhabi', 1, false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440003', 'Honda', 'Civic', 'White', 'GHI-789', 2019, 'Sharjah', 1, false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440004', 'Nissan', 'Altima', 'Blue', 'JKL-012', 2022, 'Ajman', 1, false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440005', '550e8400-e29b-41d4-a716-446655440005', 'Ford', 'F-150', 'Grey', 'MNO-345', 2018, 'Ras Al Khaimah', 1, false, NOW(), NOW(), 'system', 'system');

-- Seed Garages with actual columns
INSERT INTO "Garages" ("Id", "Name", "Email", "PhoneNumber", "City", "Address", "Status", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('750e8400-e29b-41d4-a716-446655440001', 'Al Fardan Auto Repair', 'info@alfardan.ae', '+971-43666999', 'Dubai', 'Business Bay', 1, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440002', 'Emirates Automotive', 'service@emiratesauto.ae', '+971-26551234', 'Abu Dhabi', 'Industrial Area', 1, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440003', 'Quick Fix Garage', 'contact@quickfix.ae', '+971-65628888', 'Sharjah', 'Sharjah Market', 1, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440004', 'Professional Auto Care', 'support@proautocare.ae', '+971-76661234', 'Ajman', 'Ajman Free Zone', 1, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440005', 'Master Mechanics', 'help@mastermechanics.ae', '+971-77231234', 'Ras Al Khaimah', 'RAK Industrial', 1, false, NOW(), NOW(), 'system', 'system');

-- Seed Services with actual columns
INSERT INTO "Services" ("Id", "GarageId", "Name", "Description", "EstimatedCost", "Status", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('850e8400-e29b-41d4-a716-446655440001', '750e8400-e29b-41d4-a716-446655440001', 'Oil Change', 'Regular oil and filter change', 85.00, 1, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440002', '750e8400-e29b-41d4-a716-446655440001', 'Battery Replacement', 'Replace vehicle battery', 250.00, 1, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440003', '750e8400-e29b-41d4-a716-446655440002', 'Brake Service', 'Brake pads and fluid inspection', 350.00, 1, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440004', '750e8400-e29b-41d4-a716-446655440002', 'Tire Alignment', 'Wheel alignment service', 200.00, 1, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440005', '750e8400-e29b-41d4-a716-446655440003', 'Engine Diagnostic', 'Full engine diagnostic scan', 150.00, 1, false, NOW(), NOW(), 'system', 'system');

-- Seed Diagnostic Rules with actual columns
INSERT INTO "DiagnosticRules" ("Id", "RuleCode", "RuleDescription", "Symptoms", "Status", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('a50e8400-e29b-41d4-a716-446655440001', 'DR001', 'Engine Oil Level Check', 'Low oil warning light', 1, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440002', 'DR002', 'Tire Pressure Check', 'Tire pressure warning', 1, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440003', 'DR003', 'Battery Health Check', 'Battery warning light', 1, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440004', 'DR004', 'Brake Pad Wear Check', 'Brake warning indicator', 1, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440005', 'DR005', 'Fluid Level Check', 'Fluid levels low', 1, false, NOW(), NOW(), 'system', 'system');

-- Display final counts
SELECT COUNT(*) as total_users FROM "Users";
SELECT COUNT(*) as total_vehicles FROM "Vehicles";
SELECT COUNT(*) as total_garages FROM "Garages";
SELECT COUNT(*) as total_services FROM "Services";
SELECT COUNT(*) as total_rules FROM "DiagnosticRules";
