-- Инициализация базы данных для ИС Автосервис
-- Пароли хэшированы через BCrypt (пароль: admin и manager)

-- Пользователи системы (админ и менеджеры)
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    phone VARCHAR(20),
    birth_date DATE,
    role VARCHAR(20) NOT NULL CHECK (role IN ('admin', 'manager')),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

-- Мастера (отдельная сущность)
CREATE TABLE masters (
    id SERIAL PRIMARY KEY,
    last_name VARCHAR(100) NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    phone VARCHAR(20),
    birth_date DATE,
    experience_years INTEGER DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Клиенты
CREATE TABLE clients (
    id SERIAL PRIMARY KEY,
    type VARCHAR(20) NOT NULL DEFAULT 'individual' CHECK (type IN ('individual', 'legal')),
    last_name VARCHAR(100) NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    phone VARCHAR(20) NOT NULL,
    email VARCHAR(100),
    address VARCHAR(255),
    inn VARCHAR(20),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN DEFAULT TRUE
);

-- Автомобили
CREATE TABLE cars (
    id SERIAL PRIMARY KEY,
    owner_id INTEGER REFERENCES clients(id) ON DELETE SET NULL,
    brand VARCHAR(50) NOT NULL,
    model VARCHAR(50) NOT NULL,
    state_mark VARCHAR(20),
    production_year INTEGER,
    color VARCHAR(50),
    vin_number VARCHAR(17),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Услуги (справочник)
CREATE TABLE services (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL DEFAULT 0,
    duration_minutes INTEGER NOT NULL DEFAULT 60,
    is_active BOOLEAN DEFAULT TRUE
);

-- Запчасти (справочник)
CREATE TABLE parts (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    article VARCHAR(50) UNIQUE,
    price DECIMAL(10, 2) NOT NULL DEFAULT 0,
    quantity_in_stock INTEGER NOT NULL DEFAULT 0,
    is_active BOOLEAN DEFAULT TRUE
);

-- Заявки на обслуживание (заказ-наряды)
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    order_number VARCHAR(20) UNIQUE NOT NULL,
    client_id INTEGER NOT NULL REFERENCES clients(id),
    car_id INTEGER NOT NULL REFERENCES cars(id),
    master_id INTEGER REFERENCES masters(id),
    service_date_time TIMESTAMP NOT NULL,
    status VARCHAR(30) NOT NULL DEFAULT 'pending' CHECK (status IN ('pending', 'in_progress', 'completed', 'overdue', 'cancelled')),
    manager_id INTEGER NOT NULL REFERENCES users(id),
    total_price DECIMAL(10, 2) DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Услуги в заявке (связь многие-ко-многим)
CREATE TABLE order_services (
    id SERIAL PRIMARY KEY,
    order_id INTEGER NOT NULL REFERENCES orders(id) ON DELETE CASCADE,
    service_id INTEGER NOT NULL REFERENCES services(id),
    quantity INTEGER NOT NULL DEFAULT 1,
    price DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Запчасти в заявке (связь многие-ко-многим)
CREATE TABLE order_parts (
    id SERIAL PRIMARY KEY,
    order_id INTEGER NOT NULL REFERENCES orders(id) ON DELETE CASCADE,
    part_id INTEGER NOT NULL REFERENCES parts(id),
    quantity INTEGER NOT NULL DEFAULT 1,
    price DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Чеки (выполненные заявки)
CREATE TABLE checks (
    id SERIAL PRIMARY KEY,
    order_id INTEGER UNIQUE NOT NULL REFERENCES orders(id),
    check_number VARCHAR(20) UNIQUE NOT NULL,
    client_name VARCHAR(200) NOT NULL,
    car_info VARCHAR(200) NOT NULL,
    services_total DECIMAL(10, 2) NOT NULL DEFAULT 0,
    parts_total DECIMAL(10, 2) NOT NULL DEFAULT 0,
    total_amount DECIMAL(10, 2) NOT NULL,
    master_name VARCHAR(200),
    manager_name VARCHAR(200) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Индексы для ускорения поиска
CREATE INDEX idx_orders_status ON orders(status);
CREATE INDEX idx_orders_service_date_time ON orders(service_date_time);
CREATE INDEX idx_orders_client_id ON orders(client_id);
CREATE INDEX idx_orders_master_id ON orders(master_id);
CREATE INDEX idx_cars_owner_id ON cars(owner_id);
CREATE INDEX idx_clients_type ON clients(type);
CREATE INDEX idx_users_role ON users(role);
CREATE INDEX idx_masters_active ON masters(is_active);

-- Начальные данные
-- Пароль для admin: admin
-- Пароль для manager: manager
INSERT INTO users (username, password, last_name, first_name, role) 
VALUES ('admin', '$2a$11$fLR0T9XDBHZobg9NaWqLT.zmXLCiRzbaV7WO3.U/GG8LIG5d3SjMK', 'Администраторов', 'Админ', 'admin');

INSERT INTO users (username, password, last_name, first_name, role) 
VALUES ('manager', '$2a$11$y4SIP9IOxVYpWaLSQZcQ6.T8vNpTRFnCM8jgxb3krxtcDM7seIBnq', 'Менеджеров', 'Менеджер', 'manager');

-- Мастера для тестов
INSERT INTO masters (last_name, first_name, middle_name, phone, experience_years) VALUES
('Петров', 'Алексей', 'Иванович', '+7 (901) 123-45-67', 5),
('Иванов', 'Сергей', 'Петрович', '+7 (902) 234-56-78', 3),
('Сидоров', 'Дмитрий', 'Александрович', '+7 (903) 345-67-89', 7),
('Кузнецов', 'Андрей', 'Владимирович', '+7 (904) 456-78-90', 4),
('Попов', 'Михаил', 'Сергеевич', '+7 (905) 567-89-01', 6);

-- Клиенты - физические лица
INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address) VALUES
('individual', 'Смирнов', 'Александр', 'Владимирович', '+7 (911) 111-22-33', 'smirnov.av@mail.ru', 'г. Москва, ул. Ленина, д. 10, кв. 5'),
('individual', 'Кузнецова', 'Елена', 'Сергеевна', '+7 (911) 222-33-44', 'kuznetsova.es@gmail.com', 'г. Москва, пр. Мира, д. 25, кв. 12'),
('individual', 'Попов', 'Игорь', 'Дмитриевич', '+7 (911) 333-44-55', 'popov.id@yandex.ru', 'г. Химки, ул. Кирова, д. 8, кв. 45'),
('individual', 'Васильева', 'Мария', 'Александровна', '+7 (911) 444-55-66', 'vasilieva.ma@mail.ru', 'г. Подольск, ул. Мира, д. 15, кв. 78'),
('individual', 'Лебедев', 'Павел', 'Игоревич', '+7 (911) 555-66-77', 'lebedev.pi@gmail.com', 'г. Балашиха, ш. Энтузиастов, д. 30, кв. 101');

-- Клиенты - юридические лица
INSERT INTO clients (type, last_name, first_name, middle_name, phone, email, address, inn) VALUES
('legal', 'ООО "АвтоТранс"', 'Контактное лицо: Иванов', 'Петрович', '+7 (495) 111-22-33', 'info@avtotrans.ru', 'г. Москва, ул. Транспортная, д. 5', '7701234567'),
('legal', 'ИП Петров А.В.', 'Петров', 'Александр Васильевич', '+7 (495) 222-33-44', 'petrov.av@yandex.ru', 'г. Москва, ул. Складская, д. 12', '770234567890'),
('legal', 'ООО "Логистика Плюс"', 'Контактное лицо: Сидорова', 'Анна', '+7 (495) 333-44-55', 'logistic-plus@mail.ru', 'г. Химки, ул. Промышленная, д. 8', '7703456789'),
('legal', 'ИП Козлов Н.Н.', 'Козлов', 'Николай Николаевич', '+7 (495) 444-55-66', 'kozlov.nn@gmail.com', 'г. Подольск, ул. Заводская, д. 20', '770456789012'),
('legal', 'ООО "СервисАвто"', 'Контактное лицо: Морозов', 'Игорь', '+7 (495) 555-66-77', 'service-avto@yandex.ru', 'г. Балашиха, пр. Ленина, д. 45', '7705678901');

-- Автомобили для физических лиц
INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number) VALUES
(1, 'Toyota', 'Camry', 'А123АА 799', 2020, 'Черный', 'JTDBF3FG5LJ123456'),
(2, 'Hyundai', 'Solaris', 'В456ВВ 799', 2019, 'Серебристый', 'XWEGN41ABJK234567'),
(3, 'Kia', 'Rio', 'С789СС 799', 2021, 'Белый', 'XWEXN41ABKL345678'),
(4, 'Volkswagen', 'Polo', 'Е012ЕЕ 799', 2018, 'Синий', 'XWEXN41ABJL456789'),
(5, 'Skoda', 'Octavia', 'К345КК 799', 2022, 'Красный', 'XWEXN41ABKM567890');

-- Автомобили для юридических лиц
INSERT INTO cars (owner_id, brand, model, state_mark, production_year, color, vin_number) VALUES
(6, 'Ford', 'Transit', 'М678ММ 799', 2020, 'Белый', 'XWEXN41ABJN678901'),
(7, 'ГАЗ', 'Газель', 'Н901НН 799', 2019, 'Белый', 'XWEXN41ABJP789012'),
(8, 'Mercedes-Benz', 'Sprinter', 'О234ОО 799', 2021, 'Серебристый', 'XWEXN41ABKQ890123'),
(9, 'УАЗ', 'Патриот', 'П567ПП 799', 2018, 'Черный', 'XWEXN41ABJR901234'),
(10, 'Lada', 'Largus', 'Р890РР 799', 2022, 'Серый', 'XWEXN41ABKS012345');

-- Услуги
INSERT INTO services (name, description, price, duration_minutes) VALUES
('Замена масла', 'Замена моторного масла и фильтра', 1500.00, 30),
('Диагностика двигателя', 'Полная компьютерная диагностика', 2500.00, 60),
('Замена тормозных колодок', 'Замена передних или задних колодок', 2000.00, 45),
('Замена шин', 'Сезонная замена шин (комплект)', 1200.00, 30),
('Замена аккумулятора', 'Установка нового аккумулятора', 500.00, 15),
('Ремонт подвески', 'Диагностика и ремонт ходовой части', 3500.00, 120),
('Замена воздушного фильтра', 'Замена фильтра двигателя', 300.00, 10),
('Балансировка колес', 'Балансировка всех колес', 1600.00, 40);

-- Запчасти
INSERT INTO parts (name, article, price, quantity_in_stock) VALUES
('Масло моторное 5W-30 4л', 'OIL-5W30-4L', 3500.00, 50),
('Фильтр масляный', 'FLT-OIL-001', 800.00, 100),
('Колодки тормозные передние', 'BRK-FRT-001', 2500.00, 30),
('Колодки тормозные задние', 'BRK-RR-001', 2000.00, 30),
('Фильтр воздушный', 'FLT-AIR-001', 600.00, 80),
('Аккумулятор 60Ач', 'BAT-60AH', 8000.00, 20),
('Свеча зажигания', 'SPK-001', 500.00, 200),
('Антифриз 5л', 'CLNT-5L', 1200.00, 40);
