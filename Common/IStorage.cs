using System.Collections.Generic;
using Common.data;

namespace Common
{
    /// <summary>
    /// Простое не универсальное хранилище без разделений по репозиториям. 
    /// Служит только для хранения информации о конференциях.
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Перечислить все конференции с последними данными
        /// </summary>
        /// <returns></returns>
        List<Conference> ListConferences();

        /// <summary>
        ///  Найти конкретную конференцию
        /// </summary>
        /// <param name="section">ключ секции</param>
        /// <returns>подробная информация о конференции либо NULL</returns>
        Conference GetConference(string section);
        
        /// <summary>
        /// Сколько записей о конференциях есть
        /// </summary>
        long Count { get; }

        /// <summary>
        /// Если документ уже существует в БД (скорее всего определяем по ID), то обновим его, если нет, то создадим новый
        /// </summary>
        /// <param name="conference">POKO конференция</param>
        void AddOrUpdate(Conference conference);

        /// <summary>
        /// все действия по закрытию хранилища
        /// </summary>
        void Close();
    }
}
