namespace Data
{
    /// <summary>
    /// Глобальные константы приложения
    /// </summary>
    public static class AppConstants
    {
        /// <summary>
        /// Время начала рабочего дня
        /// </summary>
        public static readonly TimeSpan WorkDayStart = TimeSpan.FromHours(8); // 08:00
        
        /// <summary>
        /// Время окончания рабочего дня
        /// </summary>
        public static readonly TimeSpan WorkDayEnd = TimeSpan.FromHours(20); // 20:00
        
        /// <summary>
        /// Время начала перерыва
        /// </summary>
        public static readonly TimeSpan BreakStart = TimeSpan.FromHours(13); // 13:00
        
        /// <summary>
        /// Время окончания перерыва
        /// </summary>
        public static readonly TimeSpan BreakEnd = TimeSpan.FromHours(14); // 14:00
        
        /// <summary>
        /// Буфер между заявками (минуты)
        /// </summary>
        public static readonly int BufferMinutes = 15;
    }
}
