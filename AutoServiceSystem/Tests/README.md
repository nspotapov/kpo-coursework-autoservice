# 🧪 Отчёт по тестированию проекта "Информационная система автосервиса"

## 1. Цель тестирования

Реализовать автоматическое тестирование проекта, подтверждающее выполнение всех запланированных задач по разработке CRUD-операций и функционала поиска/фильтрации.

## 2. Среда тестирования

| Компонент | Версия | Описание |
|-----------|--------|----------|
| **Фреймворк тестирования** | xUnit.net 2.8.2 | Модульное тестирование |
| **Библиотека моков** | Moq 4.20.72 | Изоляция зависимостей |
| **In-Memory БД** | EF Core InMemory 9.0.0 | Тестовая база данных |
| **Платформа** | .NET 9.0 | Среда выполнения |

## 3. Структура тестов

```
Tests/
├── Repositories/           # Модульные тесты репозиториев
│   ├── ClientRepositoryTests.cs
│   ├── OrderRepositoryTests.cs
│   └── CarRepositoryTests.cs
├── Integration/            # Интеграционные тесты
│   └── DatabaseConnectionTests.cs
└── Tests.csproj
```

## 4. Статистика тестов

| Категория | Всего тестов | Пройдено | Пропущено |
|-----------|-------------|----------|-----------|
| **ClientRepository** | 14 | 14 | 0 |
| **OrderRepository** | 17 | 17 | 0 |
| **CarRepository** | 13 | 13 | 0 |
| **Integration** | 2 | 2 | 0 |
| **ИТОГО** | **46** | **46** | **0** |

## 5. Покрытие функциональности

### 5.1 ClientRepositoryTests

| Тест | Описание |
|------|----------|
| `GetAll_EmptyDatabase_ReturnsEmptyList` | Проверка возврата пустого списка |
| `GetAll_WithClients_ReturnsAllActiveClients` | Проверка получения всех активных клиентов |
| `GetById_ValidId_ReturnsClient` | Проверка получения клиента по ID |
| `GetById_InvalidId_ReturnsNull` | Проверка возврата null для несуществующего ID |
| `Create_ValidClient_AddsClient` | Проверка создания клиента |
| `Create_Client_SetsCreatedAt` | Проверка установки времени создания |
| `Update_ValidClient_UpdatesClient` | Проверка обновления клиента |
| `Delete_ValidId_DeactivatesClient` | Проверка деактивации клиента (soft delete) |
| `Delete_InvalidId_DoesNothing` | Проверка удаления несуществующего клиента |
| `Search_EmptyTerm_ReturnsAllClients` | Проверка поиска с пустым запросом |
| `Search_ByLastName_ReturnsMatchingClients` | Проверка поиска по фамилии |
| `Search_ByPhone_ReturnsMatchingClients` | Проверка поиска по телефону |
| `Search_OnlyActiveClients_ReturnsActiveOnly` | Проверка поиска только активных клиентов |

### 5.2 OrderRepositoryTests

| Тест | Описание |
|------|----------|
| `GetAll_EmptyDatabase_ReturnsEmptyList` | Проверка возврата пустого списка |
| `GetAll_WithOrders_ReturnsAllOrders` | Проверка получения всех заявок |
| `GetById_ValidId_ReturnsOrder` | Проверка получения заявки по ID |
| `GetById_InvalidId_ReturnsNull` | Проверка возврата null для несуществующего ID |
| `Create_ValidOrder_AddsOrder` | Проверка создания заявки |
| `Create_Order_SetsTimestamps` | Проверка установки времени создания |
| `Update_ValidOrder_UpdatesOrder` | Проверка обновления заявки |
| `Delete_ValidId_DeletesOrder` | Проверка удаления заявки |
| `Delete_InvalidId_DoesNothing` | Проверка удаления несуществующей заявки |
| `GetByStatus_ValidStatus_ReturnsMatchingOrders` | Проверка фильтрации по статусу |
| `GetByDateRange_ValidRange_ReturnsMatchingOrders` | Проверка фильтрации по датам |
| `Search_EmptyTerm_ReturnsAllOrders` | Проверка поиска с пустым запросом |
| `Search_ByOrderNumber_ReturnsMatchingOrders` | Проверка поиска по номеру заявки |
| `Search_ByClientLastName_ReturnsMatchingOrders` | Проверка поиска по фамилии клиента |
| `UpdateStatus_ValidId_UpdatesStatus` | Проверка обновления статуса |
| `UpdateStatus_InvalidId_DoesNothing` | Проверка обновления статуса несуществующей заявки |

### 5.3 CarRepositoryTests

| Тест | Описание |
|------|----------|
| `GetAll_EmptyDatabase_ReturnsEmptyList` | Проверка возврата пустого списка |
| `GetAll_WithCars_ReturnsAllCars` | Проверка получения всех автомобилей |
| `GetById_ValidId_ReturnsCar` | Проверка получения автомобиля по ID |
| `GetById_InvalidId_ReturnsNull` | Проверка возврата null для несуществующего ID |
| `Create_ValidCar_AddsCar` | Проверка создания автомобиля |
| `Create_Car_SetsCreatedAt` | Проверка установки времени создания |
| `Update_ValidCar_UpdatesCar` | Проверка обновления автомобиля |
| `Delete_ValidId_DeletesCar` | Проверка удаления автомобиля |
| `Delete_InvalidId_DoesNothing` | Проверка удаления несуществующего автомобиля |
| `Search_EmptyTerm_ReturnsAllCars` | Проверка поиска с пустым запросом |
| `Search_ByBrand_ReturnsMatchingCars` | Проверка поиска по марке |
| `Search_ByModel_ReturnsMatchingCars` | Проверка поиска по модели |
| `Search_ByStateMark_ReturnsMatchingCars` | Проверка поиска по госномеру |
| `Search_ByVinNumber_ReturnsMatchingCars` | Проверка поиска по VIN |
| `Search_ByColor_ReturnsMatchingCars` | Проверка поиска по цвету |

## 6. Запуск тестов

### Команда для запуска всех тестов:
```bash
cd AutoServiceSystem
dotnet test Tests
```

### Запуск с генерацией отчёта TRX:
```bash
dotnet test Tests --logger "trx;LogFileName=test-results.trx"
```

### Запуск с покрытием кода:
```bash
dotnet test Tests --collect:"XPlat Code Coverage"
```

## 7. Результаты тестирования

```
Тестовый запуск выполнен.
Всего тестов: 46
     Пройдено: 46
    Пропущено: 0
 Общее время: ~13 секунд
```

**Все тесты пройдены успешно!** ✅

## 8. Выводы

1. **CRUD-операции реализованы корректно** — все тесты на создание, чтение, обновление и удаление прошли успешно.

2. **Поиск и фильтрация работают** — тесты подтверждают корректность поиска по различным полям и фильтрации по статусам/датам.

3. **Изоляция тестов обеспечена** — используется InMemory база данных для каждого теста, что гарантирует независимость тестов друг от друга.

4. **Интеграционные тесты требуют Docker** — для полного покрытия необходимы интеграционные тесты с реальной БД PostgreSQL.

## 9. Рекомендации

- Добавить тесты для `MasterRepository`, `ServiceRepository`, `PartRepository`
- Реализовать UI-тесты с использованием WinAppDriver
- Настроить CI/CD пайплайн с автоматическим запуском тестов
- Добавить тесты на валидацию данных в формах
