-- Seed Users with actual columns
INSERT INTO "Users" ("Id", "Name", "Email", "PhoneNumber", "City", "Address", "Pincode", "UserType", "Status", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('550e8400-e29b-41d4-a716-446655440001', 'Ahmed Al Mansouri', 'ahmed@example.com', '+971-501234567', 'Dubai', 'Business Bay', '123456', 1, 1, false, NOW(), NOW(), 'system', 'system'),
('550e8400-e29b-41d4-a716-446655440002', 'Fatima Al Zahra', 'fatima@example.com', '+971-502345678', 'Abu Dhabi', 'Al Raha Beach', '654321', 1, 1, false, NOW(), NOW(), 'system', 'system'),
('550e8400-e29b-41d4-a716-446655440003', 'Mohammed Ali', 'mohammed@example.com', '+971-503456789', 'Sharjah', 'Al Nahda', '789012', 1, 1, false, NOW(), NOW(), 'system', 'system'),
('550e8400-e29b-41d4-a716-446655440004', 'Leila Hassan', 'leila@example.com', '+971-504567890', 'Ajman', 'Corniche', '345678', 1, 1, false, NOW(), NOW(), 'system', 'system'),
('550e8400-e29b-41d4-a716-446655440005', 'Hassan Ibrahim', 'hassan@example.com', '+971-505678901', 'Ras Al Khaimah', 'Old Souk', '901234', 1, 1, false, NOW(), NOW(), 'system', 'system');

-- Seed Vehicles with actual columns
INSERT INTO "Vehicles" ("Id", "UserId", "VIN", "LicensePlate", "Mileage", "FuelType", "TransmissionType", "Color", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('650e8400-e29b-41d4-a716-446655440001', '550e8400-e29b-41d4-a716-446655440001', 'JT2BF20K7M0000001', 'DXB-2020', 45000, 'Petrol', 'Automatic', 'Silver', false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440002', '550e8400-e29b-41d4-a716-446655440002', 'WBA3A9C05M7B35643', 'ABU-2021', 32000, 'Diesel', 'Automatic', 'Black', false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440003', '19XFC1F31KE001248', 'SHJ-2019', 67000, 'Petrol', 'Manual', 'White', false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440004', '1N4AL3AP4NC343047', 'AJM-2022', 15000, 'Petrol', 'Automatic', 'Blue', false, NOW(), NOW(), 'system', 'system'),
('650e8400-e29b-41d4-a716-446655440005', '550e8400-e29b-41d4-a716-446655440005', '1FTYX04514FB09521', 'RAK-2018', 89000, 'Diesel', 'Automatic', 'Grey', false, NOW(), NOW(), 'system', 'system');

-- Seed Garages with actual columns
INSERT INTO "Garages" ("Id", "Name", "Address", "City", "PhoneNumber", "Email", "Latitude", "Longitude", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('750e8400-e29b-41d4-a716-446655440001', 'Al Fardan Auto Repair', 'Business Bay', 'Dubai', '+971-43666999', 'info@alfardan.ae', 25.1972, 55.2744, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440002', 'Emirates Automotive', 'Industrial Area', 'Abu Dhabi', '+971-26551234', 'service@emiratesauto.ae', 24.3745, 54.4208, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440003', 'Quick Fix Garage', 'Sharjah Market', 'Sharjah', '+971-65628888', 'contact@quickfix.ae', 25.3548, 55.3969, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440004', 'Professional Auto Care', 'Ajman Free Zone', 'Ajman', '+971-76661234', 'support@proautocare.ae', 25.4084, 55.4521, false, NOW(), NOW(), 'system', 'system'),
('750e8400-e29b-41d4-a716-446655440005', 'Master Mechanics', 'RAK Industrial', 'Ras Al Khaimah', '+971-77231234', 'help@mastermechanics.ae', 25.7482, 55.9378, false, NOW(), NOW(), 'system', 'system');

-- Seed Services with actual columns
INSERT INTO "Services" ("Id", "GarageId", "ServiceName", "ServiceType", "EstimatedDuration", "BasePrice", "IsAvailable", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('850e8400-e29b-41d4-a716-446655440001', '750e8400-e29b-41d4-a716-446655440001', 'Oil Change', 'Maintenance', 30, 85.00, true, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440002', '750e8400-e29b-41d4-a716-446655440001', 'Battery Replacement', 'Replacement', 45, 250.00, true, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440003', '750e8400-e29b-41d4-a716-446655440002', 'Brake Service', 'Maintenance', 60, 350.00, true, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440004', '750e8400-e29b-41d4-a716-446655440002', 'Tire Alignment', 'Maintenance', 45, 200.00, true, false, NOW(), NOW(), 'system', 'system'),
('850e8400-e29b-41d4-a716-446655440005', '750e8400-e29b-41d4-a716-446655440003', 'Engine Diagnostic', 'Diagnostic', 90, 150.00, true, false, NOW(), NOW(), 'system', 'system');

-- Seed Diagnostic Rules with actual columns
INSERT INTO "DiagnosticRules" ("Id", "RuleCode", "RuleName", "Description", "IsActive", "IsDeleted", "CreatedAt", "UpdatedAt", "CreatedBy", "UpdatedBy") VALUES
('a50e8400-e29b-41d4-a716-446655440001', 'DR001', 'Engine Oil Level Check', 'Check engine oil level and condition', true, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440002', 'DR002', 'Tire Pressure Check', 'Check tire pressure and wear', true, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440003', 'DR003', 'Battery Health Check', 'Test battery voltage and capacity', true, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440004', 'DR004', 'Brake Pad Wear Check', 'Inspect brake pads for wear', true, false, NOW(), NOW(), 'system', 'system'),
('a50e8400-e29b-41d4-a716-446655440005', 'DR005', 'Fluid Level Check', 'Check all fluid levels', true, false, NOW(), NOW(), 'system', 'system');

-- Display counts
SELECT COUNT(*) as total_users FROM "Users";
SELECT COUNT(*) as total_vehicles FROM "Vehicles";
SELECT COUNT(*) as total_garages FROM "Garages";
SELECT COUNT(*) as total_services FROM "Services";
SELECT COUNT(*) as total_rules FROM "DiagnosticRules";
