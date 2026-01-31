-- Seed Users
INSERT INTO "Users" ("Id", "Name", "Email", "PhoneNumber", "FamilyType", "ExperienceLevel", "City", "IsDeleted", "CreatedAt", "UpdatedAt") VALUES
('550e8400-e29b-41d4-a716-446655440001', 'Ahmed Al Mansouri', 'ahmed@example.com', '+971-501234567', 'Family', 'Intermediate', 'Dubai', false, NOW(), NOW()),
('550e8400-e29b-41d4-a716-446655440002', 'Fatima Al Zahra', 'fatima@example.com', '+971-502345678', 'Single', 'Beginner', 'Abu Dhabi', false, NOW(), NOW()),
('550e8400-e29b-41d4-a716-446655440003', 'Mohammed Ali', 'mohammed@example.com', '+971-503456789', 'Family', 'Advanced', 'Sharjah', false, NOW(), NOW()),
('550e8400-e29b-41d4-a716-446655440004', 'Leila Hassan', 'leila@example.com', '+971-504567890', 'Single', 'Intermediate', 'Ajman', false, NOW(), NOW()),
('550e8400-e29b-41d4-a716-446655440005', 'Hassan Ibrahim', 'hassan@example.com', '+971-505678901', 'Family', 'Beginner', 'Ras Al Khaimah', false, NOW(), NOW());

-- Seed Vehicles  
INSERT INTO "Vehicles" ("Id", "UserId", "Make", "Model", "Year", "VIN", "LicensePlate", "Mileage", "FuelType", "TransmissionType", "BodyType", "Color", "IsDeleted", "CreatedAt", "UpdatedAt") VALUES
('650e8400-e29b-41d4-a716-446655440001', '550e8400-e29b-41d4-a716-446655440001', 'Toyota', 'Camry', 2020, 'JT2BF20K7M0000001', 'DXB-2020', 45000, 'Petrol', 'Automatic', 'Sedan', 'Silver', false, NOW(), NOW()),
('650e8400-e29b-41d4-a716-446655440002', '550e8400-e29b-41d4-a716-446655440002', 'BMW', '3 Series', 2021, 'WBA3A9C05M7B35643', 'ABU-2021', 32000, 'Diesel', 'Automatic', 'Sedan', 'Black', false, NOW(), NOW()),
('650e8400-e29b-41d4-a716-446655440003', '550e8400-e29b-41d4-a716-446655440003', 'Honda', 'Civic', 2019, '19XFC1F31KE001248', 'SHJ-2019', 67000, 'Petrol', 'Manual', 'Sedan', 'White', false, NOW(), NOW()),
('650e8400-e29b-41d4-a716-446655440004', '550e8400-e29b-41d4-a716-446655440004', 'Nissan', 'Altima', 2022, '1N4AL3AP4NC343047', 'AJM-2022', 15000, 'Petrol', 'Automatic', 'Sedan', 'Blue', false, NOW(), NOW()),
('650e8400-e29b-41d4-a716-446655440005', '550e8400-e29b-41d4-a716-446655440005', 'Ford', 'Ranger', 2018, '1FTYX04514FB09521', 'RAK-2018', 89000, 'Diesel', 'Automatic', 'Pickup', 'Grey', false, NOW(), NOW());

-- Seed Garages
INSERT INTO "Garages" ("Id", "Name", "Address", "City", "PhoneNumber", "Email", "RatingAverage", "TotalReviews", "IsDeleted", "CreatedAt", "UpdatedAt") VALUES
('750e8400-e29b-41d4-a716-446655440001', 'Al Fardan Auto Repair', 'Business Bay, Dubai', 'Dubai', '+971-43666999', 'info@alfardan.ae', 4.5, 127, false, NOW(), NOW()),
('750e8400-e29b-41d4-a716-446655440002', 'Emirates Automotive', 'Industrial Area, Abu Dhabi', 'Abu Dhabi', '+971-26551234', 'service@emiratesauto.ae', 4.7, 245, false, NOW(), NOW()),
('750e8400-e29b-41d4-a716-446655440003', 'Quick Fix Garage', 'Sharjah Market, Sharjah', 'Sharjah', '+971-65628888', 'contact@quickfix.ae', 4.2, 89, false, NOW(), NOW()),
('750e8400-e29b-41d4-a716-446655440004', 'Professional Auto Care', 'Ajman Free Zone', 'Ajman', '+971-76661234', 'support@proautocare.ae', 4.4, 156, false, NOW(), NOW()),
('750e8400-e29b-41d4-a716-446655440005', 'Master Mechanics', 'RAK Industrial', 'Ras Al Khaimah', '+971-77231234', 'help@mastermechanics.ae', 4.6, 198, false, NOW(), NOW());

-- Seed Services
INSERT INTO "Services" ("Id", "GarageId", "ServiceName", "ServiceType", "EstimatedDuration", "BasePrice", "IsAvailable", "IsDeleted", "CreatedAt", "UpdatedAt") VALUES
('850e8400-e29b-41d4-a716-446655440001', '750e8400-e29b-41d4-a716-446655440001', 'Oil Change', 'Maintenance', 30, 85.00, true, false, NOW(), NOW()),
('850e8400-e29b-41d4-a716-446655440002', '750e8400-e29b-41d4-a716-446655440001', 'Battery Replacement', 'Replacement', 45, 250.00, true, false, NOW(), NOW()),
('850e8400-e29b-41d4-a716-446655440003', '750e8400-e29b-41d4-a716-446655440002', 'Brake Service', 'Maintenance', 60, 350.00, true, false, NOW(), NOW()),
('850e8400-e29b-41d4-a716-446655440004', '750e8400-e29b-41d4-a716-446655440002', 'Tire Alignment', 'Maintenance', 45, 200.00, true, false, NOW(), NOW()),
('850e8400-e29b-41d4-a716-446655440005', '750e8400-e29b-41d4-a716-446655440003', 'Engine Diagnostic', 'Diagnostic', 90, 150.00, true, false, NOW(), NOW());

-- Seed Vehicle Issues
INSERT INTO "VehicleIssues" ("Id", "VehicleId", "IssueType", "IssueName", "Description", "Severity", "ReportedDate", "IsResolved", "IsDeleted", "CreatedAt", "UpdatedAt") VALUES
('950e8400-e29b-41d4-a716-446655440001', '650e8400-e29b-41d4-a716-446655440001', 'Engine', 'Engine Knocking', 'Unusual knocking sound from engine', 'Medium', NOW(), false, false, NOW(), NOW()),
('950e8400-e29b-41d4-a716-446655440002', '650e8400-e29b-41d4-a716-446655440002', 'Transmission', 'Transmission Slip', 'Transmission slipping in 3rd gear', 'High', NOW(), false, false, NOW(), NOW()),
('950e8400-e29b-41d4-a716-446655440003', '650e8400-e29b-41d4-a716-446655440003', 'Brakes', 'Brake Pads Worn', 'Front brake pads need replacement', 'Low', NOW(), false, false, NOW(), NOW()),
('950e8400-e29b-41d4-a716-446655440004', '650e8400-e29b-41d4-a716-446655440004', 'Electrical', 'Battery Drain', 'Battery drains quickly', 'Medium', NOW(), false, false, NOW(), NOW()),
('950e8400-e29b-41d4-a716-446655440005', '650e8400-e29b-41d4-a716-446655440005', 'Suspension', 'Suspension Noise', 'Noise from suspension when turning', 'Low', NOW(), false, false, NOW(), NOW());

SELECT COUNT(*) as total_users FROM "Users";
SELECT COUNT(*) as total_vehicles FROM "Vehicles";
SELECT COUNT(*) as total_garages FROM "Garages";
SELECT COUNT(*) as total_services FROM "Services";
SELECT COUNT(*) as total_issues FROM "VehicleIssues";
