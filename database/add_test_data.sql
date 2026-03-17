-- Скрипт добавления тестовых данных
-- Выполнять ПОСЛЕ init.sql

-- ============================================================================
-- КЛИЕНТЫ (если ещё не добавлены)
-- ============================================================================
INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Иванов', 'Сергей', 'Иванович', '+7 (901) 100-10-10', 'ivanov@mail.ru', 'г. Москва, ул. Ленина, д. 1', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Иванов' AND first_name = 'Сергей');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Смирнов', 'Александр', 'Петрович', '+7 (901) 200-20-20', 'smirnov@yandex.ru', 'г. Москва, ул. Мира, д. 2', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Смирнов' AND first_name = 'Александр');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Кузнецов', 'Владимир', 'Александрович', '+7 (901) 300-30-30', 'kuznetsov@gmail.com', 'г. Москва, пр. Победы, д. 3', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Кузнецов' AND first_name = 'Владимир');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Попов', 'Михаил', 'Владимирович', '+7 (901) 400-40-40', 'popov@mail.ru', 'г. Москва, ул. Гагарина, д. 4', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Попов' AND first_name = 'Михаил');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Васильев', 'Евгений', 'Николаевич', '+7 (901) 500-50-50', 'vasiliev@yandex.ru', 'г. Москва, ул. Кирова, д. 5', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Васильев' AND first_name = 'Евгений');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Михайлов', 'Дмитрий', 'Сергеевич', '+7 (901) 600-60-60', 'mikhailov@gmail.com', 'г. Москва, ул. Чехова, д. 6', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Михайлов' AND first_name = 'Дмитрий');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Новиков', 'Андрей', 'Иванович', '+7 (901) 700-70-70', 'novikov@mail.ru', 'г. Москва, ул. Пушкина, д. 7', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Новиков' AND first_name = 'Андрей');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'individual', 'Фёдоров', 'Алексей', 'Петрович', '+7 (901) 800-80-80', 'fedorov@yandex.ru', 'г. Москва, ул. Лермонтова, д. 8', NULL, true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE last_name = 'Фёдоров' AND first_name = 'Алексей');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'legal', 'ООО "АвтоТранс"', 'Генеральный', 'Директоров', '+7 (902) 100-00-01', 'info@avtotrans.ru', 'г. Москва, ул. Промышленная, д. 10', '7701234567', true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE inn = '7701234567');

INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn, is_active)
SELECT 'legal', 'ИП "ТаксиПлюс"', 'Таксистов', 'Водительский', '+7 (902) 200-00-02', 'taxi@plus.ru', 'г. Москва, ул. Транспортная, д. 20', '7709876543', true
WHERE NOT EXISTS (SELECT 1 FROM clients WHERE inn = '7709876543');

-- ============================================================================
-- АВТОМОБИЛИ (если ещё не добавлены)
-- ============================================================================
INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 1, 'Toyota', 'Camry', 'А001АА 777', 2020, 'Чёрный', 'JTDBR32E000000001'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'JTDBR32E000000001');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 2, 'Hyundai', 'Solaris', 'В002ВВ 777', 2019, 'Серебристый', 'XWEGNC4EAB0000002'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'XWEGNC4EAB0000002');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 3, 'Kia', 'Rio', 'С003СС 777', 2021, 'Белый', 'XWECN81ABLM000003'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'XWECN81ABLM000003');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 4, 'Volkswagen', 'Polo', 'Е004ЕЕ 777', 2018, 'Синий', 'XWEC216GKJ0000004'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'XWEC216GKJ0000004');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 5, 'Skoda', 'Octavia', 'К005КК 777', 2022, 'Серый', 'XWEC21NE8NM000005'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'XWEC21NE8NM000005');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 6, 'Renault', 'Duster', 'М006ММ 777', 2020, 'Оранжевый', 'X7PAR15ABLM000006'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'X7PAR15ABLM000006');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 7, 'Nissan', 'Qashqai', 'Н007НН 777', 2019, 'Красный', 'X7LHRAAJ8LW000007'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'X7LHRAAJ8LW000007');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 8, 'Mazda', 'CX-5', 'О008ОО 777', 2021, 'Белый', 'JM3KFBHA8M0000008'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'JM3KFBHA8M0000008');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 9, 'Ford', 'Focus', 'Р009РР 777', 2017, 'Чёрный', 'X9FAXXGBMA0000009'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'X9FAXXGBMA0000009');

INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
SELECT 10, 'Lada', 'Vesta', 'Т010ТТ 777', 2023, 'Синий', 'XWACG11L8M0000010'
WHERE NOT EXISTS (SELECT 1 FROM cars WHERE vin_number = 'XWACG11L8M0000010');

-- ============================================================================
-- ЗАЯВКИ (если ещё не добавлены)
-- ============================================================================

-- Будущие заявки (статус: pending/Ожидает) - 4 шт
INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-001', 1, 1, 1, NOW() + INTERVAL '2 days', 'pending', 2, NULL, NOW(), NOW()
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-001');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-002', 2, 2, 2, NOW() + INTERVAL '3 days', 'pending', 2, NULL, NOW(), NOW()
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-002');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-003', 3, 3, 3, NOW() + INTERVAL '5 days', 'pending', 2, NULL, NOW(), NOW()
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-003');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-004', 4, 4, 4, NOW() + INTERVAL '7 days', 'pending', 2, NULL, NOW(), NOW()
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-004');

-- Отменённые заявки (статус: cancelled/Отменена) - 2 шт
INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-005', 5, 5, 5, NOW() - INTERVAL '10 days', 'cancelled', 2, NULL, NOW() - INTERVAL '15 days', NOW() - INTERVAL '10 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-005');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-006', 6, 6, 1, NOW() - INTERVAL '5 days', 'cancelled', 2, NULL, NOW() - INTERVAL '10 days', NOW() - INTERVAL '5 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-006');

-- Выполненные заявки (статус: completed/Выполнена) - 14 шт
INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-007', 7, 7, 2, NOW() - INTERVAL '25 days', 'completed', 2, 5500, NOW() - INTERVAL '30 days', NOW() - INTERVAL '25 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-007');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-008', 8, 8, 3, NOW() - INTERVAL '23 days', 'completed', 2, 8200, NOW() - INTERVAL '28 days', NOW() - INTERVAL '23 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-008');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-009', 9, 9, 4, NOW() - INTERVAL '20 days', 'completed', 2, 3700, NOW() - INTERVAL '25 days', NOW() - INTERVAL '20 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-009');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-010', 10, 10, 5, NOW() - INTERVAL '18 days', 'completed', 2, 12500, NOW() - INTERVAL '23 days', NOW() - INTERVAL '18 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-010');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-011', 1, 2, 1, NOW() - INTERVAL '15 days', 'completed', 2, 4200, NOW() - INTERVAL '20 days', NOW() - INTERVAL '15 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-011');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-012', 2, 3, 2, NOW() - INTERVAL '12 days', 'completed', 2, 6800, NOW() - INTERVAL '17 days', NOW() - INTERVAL '12 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-012');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-013', 3, 4, 3, NOW() - INTERVAL '10 days', 'completed', 2, 2900, NOW() - INTERVAL '15 days', NOW() - INTERVAL '10 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-013');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-014', 4, 5, 4, NOW() - INTERVAL '8 days', 'completed', 2, 9500, NOW() - INTERVAL '13 days', NOW() - INTERVAL '8 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-014');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-015', 5, 6, 5, NOW() - INTERVAL '6 days', 'completed', 2, 3200, NOW() - INTERVAL '11 days', NOW() - INTERVAL '6 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-015');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-016', 6, 7, 1, NOW() - INTERVAL '4 days', 'completed', 2, 7100, NOW() - INTERVAL '9 days', NOW() - INTERVAL '4 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-016');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-017', 7, 8, 2, NOW() - INTERVAL '3 days', 'completed', 2, 4800, NOW() - INTERVAL '8 days', NOW() - INTERVAL '3 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-017');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-018', 8, 9, 3, NOW() - INTERVAL '2 days', 'completed', 2, 5600, NOW() - INTERVAL '7 days', NOW() - INTERVAL '2 days'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-018');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-019', 9, 10, 4, NOW() - INTERVAL '1 day', 'completed', 2, 3100, NOW() - INTERVAL '6 days', NOW() - INTERVAL '1 day'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-019');

INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
SELECT 'ORD-2026-020', 10, 1, 5, NOW() - INTERVAL '12 hours', 'completed', 2, 8900, NOW() - INTERVAL '5 days', NOW() - INTERVAL '12 hours'
WHERE NOT EXISTS (SELECT 1 FROM orders WHERE order_number = 'ORD-2026-020');

-- ============================================================================
-- ЧЕКИ (для выполненных заявок)
-- ============================================================================
INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 7, 'CHK-007', 'Новиков Андрей Иванович', 'Nissan Qashqai Н007НН 777', 4500, 1700, 6200, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 7);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 8, 'CHK-008', 'Фёдоров Алексей Петрович', 'Mazda CX-5 О008ОО 777', 9500, 4300, 13800, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 8);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 9, 'CHK-009', 'Иванов Сергей Иванович', 'Ford Focus Р009РР 777', 3200, 2500, 5700, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 9);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 10, 'CHK-010', 'Смирнов Александр Петрович', 'Lada Vesta Т010ТТ 777', 9500, 6300, 15800, 'Морозов Евгений Александрович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 10);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 11, 'CHK-011', 'Кузнецов Владимир Александрович', 'Hyundai Solaris В002ВВ 777', 4200, 4800, 9000, 'Петров Иван Петрович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 11);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 12, 'CHK-012', 'Попов Михаил Владимирович', 'Kia Rio С003СС 777', 6000, 4300, 10300, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 12);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 13, 'CHK-013', 'Васильев Евгений Николаевич', 'Volkswagen Polo Е004ЕЕ 777', 1300, 800, 2100, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 13);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 14, 'CHK-014', 'Михайлов Дмитрий Сергеевич', 'Skoda Octavia К005КК 777', 9200, 8300, 17500, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 14);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 15, 'CHK-015', 'ООО "АвтоТранс"', 'Renault Duster М006ММ 777', 2500, 2500, 5000, 'Морозов Евгений Александрович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 15);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 16, 'CHK-016', 'ИП "ТаксиПлюс"', 'Nissan Qashqai Н007НН 777', 7500, 800, 8300, 'Петров Иван Петрович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 16);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 17, 'CHK-017', 'Иванов Сергей Иванович', 'Mazda CX-5 О008ОО 777', 3500, 4800, 8300, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 17);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 18, 'CHK-018', 'Кузнецов Владимир Александрович', 'Ford Focus Р009РР 777', 5500, 4300, 9800, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 18);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 19, 'CHK-019', 'Попов Михаил Владимирович', 'Lada Vesta Т010ТТ 777', 1700, 4800, 6500, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 19);

INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
SELECT 20, 'CHK-020', 'Васильев Евгений Николаевич', 'Toyota Camry А001АА 777', 9500, 4300, 13800, 'Морозов Евгений Александрович', 'Менеджеров Менеджер'
WHERE NOT EXISTS (SELECT 1 FROM checks WHERE order_id = 20);
