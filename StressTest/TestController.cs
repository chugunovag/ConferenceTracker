using System;
using System.Collections.Generic;
using System.Threading;
using Common.data;
using Common.helper;

namespace StressTest {
    /// <summary>
    ///     Контроллер с состоянием для обслуживания действий формы и взаимодействия с центральным серверов посредствон http
    ///     клиента.
    /// </summary>
    public class TestController : IDisposable {
        private static readonly ManualResetEvent StopEvent = new ManualResetEvent(true);

        private static readonly Random Random = new Random();

        public void Dispose() {
            StopAutoTest();
        }

        /// <summary>
        ///     Включаем режим автоматической периодической регистрации/перерегистрации для каждой секции и места.
        ///     Для каждой секции создается поток, в котором периодически происходит регистрация этой секции с новым случайным
        ///     адресом.
        /// </summary>
        /// <param name="url">адрес центрального сервера</param>
        /// <param name="cities">список городов для выбора случайного</param>
        /// <param name="streets">список улиц для выбора случайной</param>
        /// <param name="sections">
        ///     список идентификаторов секций, для каждой из которых будет имитироваться отдельный перифирийный
        ///     сервер конференции
        /// </param>
        public void DoAutoTest(string url, List<string> cities, List<string> streets, List<string> sections) {
            StopEvent.Reset();
            sections.ForEach(s =>
            {
                new Thread(o =>
                {
                    var conference = new Conference
                    {
                        Section = s,
                        Info = new ConferenceInfo
                        {
                            Name = s,
                            City = GetRandom(cities),
                            Location = GetRandom(streets)
                        }
                    };

                    var inPlaceServer = new InPlaceServer(conference, url.EnsureUrl());
                    while (!StopEvent.WaitOne(500)) {
                        inPlaceServer.RegisterSectionData();
                        inPlaceServer.Conference.Info.City = GetRandom(cities);
                        inPlaceServer.Conference.Info.Location = GetRandom(streets);
                    }
                }).Start();
            });
        }

        /// <summary>
        ///     Показывает, активен ли автотест.
        /// </summary>
        /// <returns></returns>
        public bool IsAutoTestRunning() {
            return !StopEvent.WaitOne(0);
        }

        /// <summary>
        ///     останавливает автотест
        /// </summary>
        public void StopAutoTest() {
            StopEvent.Set();
        }

        /// <summary>
        ///     Заготовка для advertise запроса
        /// </summary>
        /// <param name="url"></param>
        /// <param name="section"></param>
        [Obsolete("Возможно, использование этого метода не актуально  надо уточнить задание.")]
        public void RegisterSectionManual(string url, string section) {
            Helpers.Put<Conference>(url.EnsureUrl() + $"conference/{section}/info", null);
        }

        /// <summary>
        ///     Регистрируем секцию с заданными полями
        /// </summary>
        /// <param name="url">адрес центрального сервера</param>
        /// <param name="section"></param>
        /// <param name="city"></param>
        /// <param name="location"></param>
        /// <param name="name"></param>
        public void RegisterSectionManual(string url, string section, string city, string location, string name) {
            Helpers.Put<Conference>(url.EnsureUrl() + $"conference/{section}/info", new ConferenceInfo {City = city, Location = location, Name = name});
        }

        /// <summary>
        ///     Получаем с сервера список всех последних известных секций
        /// </summary>
        /// <param name="url">адрес центрального сервера</param>
        /// <returns></returns>
        public List<Conference> GetAll(string url) {
            return Helpers.Get<List<Conference>>(url.EnsureUrl() + "conference/info");
        }

        /// <summary>
        ///     Ищем на сервере секцию по идентификатору
        /// </summary>
        /// <param name="url">адрес центрального сервера</param>
        /// <param name="section"></param>
        /// <returns></returns>
        public ConferenceInfo GetSection(string url, string section) {
            return Helpers.Get<ConferenceInfo>(url.EnsureUrl() + $"conference/{section}/info");
        }

        /// <summary>
        ///     Возвращает случайную строку из переданного списка
        /// </summary>
        /// <param name="list">список значений для выбора</param>
        /// <returns></returns>
        private static string GetRandom(IReadOnlyList<string> list) {
            return list?[Random.Next(list.Count)];
        }

    }

    static class StringUrlExt {
        /// <summary>
        /// расширение для строки, которое выставляет при необходимости слэш в конце строки (считаем что есть такое соглашение).
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string EnsureUrl(this string url) {
            return url.EndsWith("/") ? url : url + "/";
        }
    }
}