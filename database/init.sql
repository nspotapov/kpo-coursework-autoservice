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
INSERT INTO masters (last_name, first_name, experience_years) VALUES
('Петров', 'Алексей', 5),
('Иванов', 'Сергей', 3),
('Сидоров', 'Дмитрий', 7);

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
