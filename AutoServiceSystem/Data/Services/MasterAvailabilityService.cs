using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Services
{
    /// <summary>
    /// Временной слот занятости мастера
    /// </summary>
    public class MasterBusySlot
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OrderId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string CarInfo { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
    }

    /// <summary>
    /// Слот времени для расписания
    /// </summary>
    public class TimeSlot
    {
        public DateTime Time { get; set; }
        public bool IsAvailable { get; set; }
        public string? Reason { get; set; } // Причина занятости (если есть)
    }

    /// <summary>
    /// Сервис проверки доступности мастеров
    /// </summary>
    public class MasterAvailabilityService
    {
        private readonly AutoserviceDbContext _dbContext;

        public MasterAvailabilityService(AutoserviceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Получить занятые слоты мастера на дату
        /// </summary>
        public async Task<List<MasterBusySlot>> GetMasterBusySlotsAsync(int masterId, DateTime date)
        {
            var dateStart = date.Date;
            var dateEnd = date.Date.AddDays(1);

            var orders = await _dbContext.Orders
                .Where(o => o.MasterId == masterId
                         && o.ServiceDateTime >= dateStart
                         && o.ServiceDateTime < dateEnd
                         && o.Status != OrderStatus.Cancelled)
                .Include(o => o.Client)
                .Include(o => o.Car)
                .Include(o => o.OrderServices)
                .ThenInclude(os => os.Service)
                .ToListAsync();

            var busySlots = new List<MasterBusySlot>();

            foreach (var order in orders)
            {
                // Рассчитываем длительность услуг
                var durationMinutes = order.OrderServices.Sum(os => os.Service.DurationMinutes);
                
                // Добавляем буфер
                var endTime = order.ServiceDateTime.AddMinutes(durationMinutes + AppConstants.BufferMinutes);

                busySlots.Add(new MasterBusySlot
                {
                    StartTime = order.ServiceDateTime,
                    EndTime = endTime,
                    OrderId = order.Id,
                    ClientName = order.Client.FullName,
                    CarInfo = $"{order.Car.Brand} {order.Car.Model}",
                    Status = order.Status
                });
            }

            return busySlots;
        }

        /// <summary>
        /// Проверить, доступен ли мастер в указанное время с учётом всех заявок
        /// </summary>
        public async Task<bool> IsMasterAvailableAtAsync(int masterId, DateTime dateTime, int durationMinutes)
        {
            var date = dateTime.Date;
            var busySlots = await GetMasterBusySlotsAsync(masterId, date);
            
            return IsMasterAvailable(busySlots, dateTime, durationMinutes);
        }

        /// <summary>
        /// Проверить, доступен ли мастер в указанное время
        /// </summary>
        public bool IsMasterAvailable(List<MasterBusySlot> busySlots, DateTime requestedTime, int durationMinutes)
        {
            var requestedEnd = requestedTime.AddMinutes(durationMinutes + AppConstants.BufferMinutes);

            foreach (var slot in busySlots)
            {
                // Проверяем пересечение интервалов
                if (requestedTime < slot.EndTime && requestedEnd > slot.StartTime)
                {
                    return false; // Мастер занят
                }
            }

            // Проверяем, не попадает ли время на перерыв
            var breakStart = requestedTime.Date + AppConstants.BreakStart;
            var breakEnd = requestedTime.Date + AppConstants.BreakEnd;

            if (requestedTime < breakEnd && requestedEnd > breakStart)
            {
                return false; // Попадает на перерыв
            }

            // Проверяем, не выходит ли за рамки рабочего дня
            var workDayStart = requestedTime.Date + AppConstants.WorkDayStart;
            var workDayEnd = requestedTime.Date + AppConstants.WorkDayEnd;

            if (requestedTime < workDayStart || requestedEnd > workDayEnd)
            {
                return false; // Выходит за рамки рабочего дня
            }

            return true; // Мастер свободен
        }

        /// <summary>
        /// Получить все доступные слоты для мастера на дату
        /// </summary>
        public async Task<List<TimeSlot>> GetAvailableSlotsForMasterAsync(int masterId, DateTime date)
        {
            var busySlots = await GetMasterBusySlotsAsync(masterId, date);
            var availableSlots = new List<TimeSlot>();

            var workDayStart = date.Date + AppConstants.WorkDayStart;
            var workDayEnd = date.Date + AppConstants.WorkDayEnd;
            var breakStart = date.Date + AppConstants.BreakStart;
            var breakEnd = date.Date + AppConstants.BreakEnd;

            // Генерируем слоты с шагом 30 минут
            var currentTime = workDayStart;
            while (currentTime < workDayEnd)
            {
                var slotEnd = currentTime.AddMinutes(30);
                var isAvailable = true;
                string? reason = null;

                // Проверяем, не попадает ли на перерыв
                if (currentTime < breakEnd && slotEnd > breakStart)
                {
                    isAvailable = false;
                    reason = "Перерыв";
                }
                else
                {
                    // Проверяем занятость
                    foreach (var slot in busySlots)
                    {
                        if (currentTime < slot.EndTime && slotEnd > slot.StartTime)
                        {
                            isAvailable = false;
                            reason = $"Занят: {slot.ClientName}";
                            break;
                        }
                    }
                }

                availableSlots.Add(new TimeSlot
                {
                    Time = currentTime,
                    IsAvailable = isAvailable,
                    Reason = reason
                });

                currentTime = currentTime.AddMinutes(30);
            }

            return availableSlots;
        }

        /// <summary>
        /// Получить всех свободных мастеров на дату и время
        /// </summary>
        public async Task<List<Master>> GetAvailableMastersAsync(DateTime date, DateTime time, int durationMinutes)
        {
            var masters = await _dbContext.Masters
                .Where(m => m.IsActive)
                .ToListAsync();

            var availableMasters = new List<Master>();

            foreach (var master in masters)
            {
                var busySlots = await GetMasterBusySlotsAsync(master.Id, date);
                if (IsMasterAvailable(busySlots, time, durationMinutes))
                {
                    availableMasters.Add(master);
                }
            }

            return availableMasters;
        }
    }
}
