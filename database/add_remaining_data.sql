-- Добавление автомобилей для клиентов (ID 11-20)
INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number)
VALUES
(11, 'Toyota', 'Camry', 'А001АА 777', 2020, 'Чёрный', 'JTDBR32E000000001'),
(12, 'Hyundai', 'Solaris', 'В002ВВ 777', 2019, 'Серебристый', 'XWEGNC4EAB0000002'),
(13, 'Kia', 'Rio', 'С003СС 777', 2021, 'Белый', 'XWECN81ABLM000003'),
(14, 'Volkswagen', 'Polo', 'Е004ЕЕ 777', 2018, 'Синий', 'XWEC216GKJ0000004'),
(15, 'Skoda', 'Octavia', 'К005КК 777', 2022, 'Серый', 'XWEC21NE8NM000005'),
(16, 'Renault', 'Duster', 'М006ММ 777', 2020, 'Оранжевый', 'X7PAR15ABLM000006'),
(17, 'Nissan', 'Qashqai', 'Н007НН 777', 2019, 'Красный', 'X7LHRAAJ8LW000007'),
(18, 'Mazda', 'CX-5', 'О008ОО 777', 2021, 'Белый', 'JM3KFBHA8M0000008'),
(19, 'Ford', 'Focus', 'Р009РР 777', 2017, 'Чёрный', 'X9FAXXGBMA0000009'),
(20, 'Lada', 'Vesta', 'Т010ТТ 777', 2023, 'Синий', 'XWACG11L8M0000010')
ON CONFLICT (vin_number) DO NOTHING;

-- Добавление заявок
INSERT INTO orders (order_number, client_id, car_id, master_id, service_date_time, status, manager_id, total_price, created_at, updated_at)
VALUES
('ORD-2026-001', 11, 1, 1, NOW() + INTERVAL '2 days', 'pending', 2, NULL, NOW(), NOW()),
('ORD-2026-002', 12, 2, 2, NOW() + INTERVAL '3 days', 'pending', 2, NULL, NOW(), NOW()),
('ORD-2026-003', 13, 3, 3, NOW() + INTERVAL '5 days', 'pending', 2, NULL, NOW(), NOW()),
('ORD-2026-004', 14, 4, 4, NOW() + INTERVAL '7 days', 'pending', 2, NULL, NOW(), NOW()),
('ORD-2026-005', 15, 5, 5, NOW() - INTERVAL '10 days', 'cancelled', 2, NULL, NOW() - INTERVAL '15 days', NOW() - INTERVAL '10 days'),
('ORD-2026-006', 16, 6, 1, NOW() - INTERVAL '5 days', 'cancelled', 2, NULL, NOW() - INTERVAL '10 days', NOW() - INTERVAL '5 days'),
('ORD-2026-007', 17, 7, 2, NOW() - INTERVAL '25 days', 'completed', 2, 5500, NOW() - INTERVAL '30 days', NOW() - INTERVAL '25 days'),
('ORD-2026-008', 18, 8, 3, NOW() - INTERVAL '23 days', 'completed', 2, 8200, NOW() - INTERVAL '28 days', NOW() - INTERVAL '23 days'),
('ORD-2026-009', 19, 9, 4, NOW() - INTERVAL '20 days', 'completed', 2, 3700, NOW() - INTERVAL '25 days', NOW() - INTERVAL '20 days'),
('ORD-2026-010', 20, 10, 5, NOW() - INTERVAL '18 days', 'completed', 2, 12500, NOW() - INTERVAL '23 days', NOW() - INTERVAL '18 days'),
('ORD-2026-011', 11, 1, 1, NOW() - INTERVAL '15 days', 'completed', 2, 4200, NOW() - INTERVAL '20 days', NOW() - INTERVAL '15 days'),
('ORD-2026-012', 12, 2, 2, NOW() - INTERVAL '12 days', 'completed', 2, 6800, NOW() - INTERVAL '17 days', NOW() - INTERVAL '12 days'),
('ORD-2026-013', 13, 3, 3, NOW() - INTERVAL '10 days', 'completed', 2, 2900, NOW() - INTERVAL '15 days', NOW() - INTERVAL '10 days'),
('ORD-2026-014', 14, 4, 4, NOW() - INTERVAL '8 days', 'completed', 2, 9500, NOW() - INTERVAL '13 days', NOW() - INTERVAL '8 days'),
('ORD-2026-015', 15, 5, 5, NOW() - INTERVAL '6 days', 'completed', 2, 3200, NOW() - INTERVAL '11 days', NOW() - INTERVAL '6 days'),
('ORD-2026-016', 16, 6, 1, NOW() - INTERVAL '4 days', 'completed', 2, 7100, NOW() - INTERVAL '9 days', NOW() - INTERVAL '4 days'),
('ORD-2026-017', 17, 7, 2, NOW() - INTERVAL '3 days', 'completed', 2, 4800, NOW() - INTERVAL '8 days', NOW() - INTERVAL '3 days'),
('ORD-2026-018', 18, 8, 3, NOW() - INTERVAL '2 days', 'completed', 2, 5600, NOW() - INTERVAL '7 days', NOW() - INTERVAL '2 days'),
('ORD-2026-019', 19, 9, 4, NOW() - INTERVAL '1 day', 'completed', 2, 3100, NOW() - INTERVAL '6 days', NOW() - INTERVAL '1 day'),
('ORD-2026-020', 20, 10, 5, NOW() - INTERVAL '12 hours', 'completed', 2, 8900, NOW() - INTERVAL '5 days', NOW() - INTERVAL '12 hours')
ON CONFLICT (order_number) DO NOTHING;

-- Добавление чеков
INSERT INTO checks (order_id, check_number, client_name, car_info, services_total, parts_total, total_amount, master_name, manager_name)
VALUES
(7, 'CHK-007', 'Новиков Андрей Иванович', 'Nissan Qashqai Н007НН 777', 4500, 1700, 6200, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'),
(8, 'CHK-008', 'Фёдоров Алексей Петрович', 'Mazda CX-5 О008ОО 777', 9500, 4300, 13800, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'),
(9, 'CHK-009', 'Иванов Сергей Иванович', 'Ford Focus Р009РР 777', 3200, 2500, 5700, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'),
(10, 'CHK-010', 'Смирнов Александр Петрович', 'Lada Vesta Т010ТТ 777', 9500, 6300, 15800, 'Морозов Евгений Александрович', 'Менеджеров Менеджер'),
(11, 'CHK-011', 'Кузнецов Владимир Александрович', 'Hyundai Solaris В002ВВ 777', 4200, 4800, 9000, 'Петров Иван Петрович', 'Менеджеров Менеджер'),
(12, 'CHK-012', 'Попов Михаил Владимирович', 'Kia Rio С003СС 777', 6000, 4300, 10300, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'),
(13, 'CHK-013', 'Васильев Евгений Николаевич', 'Volkswagen Polo Е004ЕЕ 777', 1300, 800, 2100, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'),
(14, 'CHK-014', 'Михайлов Дмитрий Сергеевич', 'Skoda Octavia К005КК 777', 9200, 8300, 17500, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'),
(15, 'CHK-015', 'ООО "АвтоТранс"', 'Renault Duster М006ММ 777', 2500, 2500, 5000, 'Морозов Евгений Александрович', 'Менеджеров Менеджер'),
(16, 'CHK-016', 'ИП "ТаксиПлюс"', 'Nissan Qashqai Н007НН 777', 7500, 800, 8300, 'Петров Иван Петрович', 'Менеджеров Менеджер'),
(17, 'CHK-017', 'Иванов Сергей Иванович', 'Mazda CX-5 О008ОО 777', 3500, 4800, 8300, 'Сидоров Алексей Владимирович', 'Менеджеров Менеджер'),
(18, 'CHK-018', 'Кузнецов Владимир Александрович', 'Ford Focus Р009РР 777', 5500, 4300, 9800, 'Козлов Дмитрий Сергеевич', 'Менеджеров Менеджер'),
(19, 'CHK-019', 'Попов Михаил Владимирович', 'Lada Vesta Т010ТТ 777', 1700, 4800, 6500, 'Волков Андрей Николаевич', 'Менеджеров Менеджер'),
(20, 'CHK-020', 'Васильев Евгений Николаевич', 'Toyota Camry А001АА 777', 9500, 4300, 13800, 'Морозов Евгений Александрович', 'Менеджеров Менеджер')
ON CONFLICT (order_id) DO NOTHING;
