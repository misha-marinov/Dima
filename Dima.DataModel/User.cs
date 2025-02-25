namespace Dima.DataModel
{
    /// <summary>
    /// Модель таблицы Users
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
    }
}
