SELECT 'Users' as table_name, COUNT(*) as row_count FROM "Users"
UNION ALL
SELECT 'Vehicles', COUNT(*) FROM "Vehicles"
UNION ALL
SELECT 'Garages', COUNT(*) FROM "Garages"
UNION ALL
SELECT 'Services', COUNT(*) FROM "Services"
UNION ALL
SELECT 'VehicleIssues', COUNT(*) FROM "VehicleIssues"
ORDER BY table_name;
