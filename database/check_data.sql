-- Проверка данных в БД
SELECT 'masters' as table_name, COUNT(*) as count FROM masters
UNION ALL SELECT 'services', COUNT(*) FROM services
UNION ALL SELECT 'parts', COUNT(*) FROM parts
UNION ALL SELECT 'clients', COUNT(*) FROM clients
UNION ALL SELECT 'cars', COUNT(*) FROM cars
UNION ALL SELECT 'orders', COUNT(*) FROM orders
UNION ALL SELECT 'checks', COUNT(*) FROM checks;
