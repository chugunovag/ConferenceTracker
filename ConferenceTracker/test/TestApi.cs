using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Common;
using Common.data;
using Common.helper;
using ConferenceTracker.core;
using NUnit.Framework;

namespace ConferenceTracker.test {

    /// <summary>
    /// Тестируем всю функциональность центрального сервера. 
    /// Недостаток данного теста в том, что приходиться поднимать весь функционал, что делает его практически интеграционным.
    /// Но в виду малых масштабов допустимо.
    /// </summary>
    [TestFixture]
    public class TestApi {
        [SetUp]
        public void Setup() {
            Program.DiKernel.Bind<IStorage>().ToConstant(new SqliteStorage(TestDbPath));
            _gisConf = CreateTestConference("GIS");
            _oilConf = CreateTestConference("OIL");
        }

        [TearDown]
        public void TearDown() {
            Db.Close();
            Program.DiKernel.Unbind<IStorage>();
            File.Delete(TestDbPath);
        }

        private static IStorage Db => Program.GetStorage();

        private const string TestDbPath = "test.db";
        private Conference _gisConf;
        private Conference _oilConf;

        private void WrapServerContext(Action action) {
            try {
                Server.Instance.Start("http://localhost:9123/");
                action.Invoke();
            }
            finally {
                Server.Instance.Stop();
            }
        }

        /// <summary>
        ///     вспомогательный метод для создания случайных данных конференции
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private static Conference CreateTestConference(string section) {
            return new Conference
            {
                Section = section,
                Info = new ConferenceInfo
                {
                    Name = "Простая #" + Guid.NewGuid(),
                    Location = "Rabochaya st, " + new Random().Next(1000),
                    City = "Tomsk"
                }
            };
        }

        /// <summary>
        ///     Проверияем нормальный сценарий работы:
        ///     - регистрация сервера
        ///     - отсылка данных о ранее зарегистрированной секции
        /// </summary>
        [Test]
        public void TestAdvertize() {
            WrapServerContext(delegate
            {
                HttpStatusCode code;
                var responseBody = Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info", null,
                    out code);
                Assert.AreEqual(HttpStatusCode.OK, code, "advertize запрос");
                Assert.IsNull(responseBody, "на отправку данных не должно быть ответа");

                responseBody = Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info",
                    _gisConf.Info, out code);
                Assert.AreEqual(HttpStatusCode.OK, code, "Данные после advertize запроса должны сохраняться");
                Assert.IsNull(responseBody, "на отправку данных не должно быть ответа");

                Assert.AreEqual(1, Program.GetStorage().Count, "advertise-запрос не должен создавать новую запись");
            });
        }

        /// <summary>
        ///     Проверяем, что из пустой базы возвражается пустой список.
        /// </summary>
        [Test]
        public void TestEmptyConferences() {
            WrapServerContext(delegate
            {
                var conferences = Helpers.Get<List<Conference>>(Server.Instance.BaseAddress + "conference/info");
                Assert.IsEmpty(conferences, "без регистрации ожидается пустой список");
            });
        }

        /// <summary>
        ///     Данные от серверов не приславших advertise-запрос, не должны сохраняться.
        ///     Таким серверам нужно отвечать пустым ответом с кодом 400 Bad Request.
        ///     Возможно это условие не актуально. В текуще реализации данные принимаются одновременно с регистрацией.
        /// </summary>
        [Test, Ignore("Функциональность advertise под вопросом.")]
        public void TestMissingAdvertize() {
            WrapServerContext(delegate
            {
                HttpStatusCode code;
                var responseBody = Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info",
                    _gisConf.Info, out code);
                Assert.AreEqual(HttpStatusCode.BadRequest, code, "Данные без advertize запроса не сохраняются");
                Assert.IsNull(responseBody, "на отправку данных не должно быть ответа");
            });
        }

        /// <summary>
        ///     Проверяем 404 для отсутсвующей записи, а также отсутствие тела ответа
        /// </summary>
        [Test]
        public void TestMissingConference() {
            WrapServerContext(delegate
            {
                HttpStatusCode code;
                var conferenceInfo = Helpers.Get<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info",
                    out code);
                Assert.AreEqual(HttpStatusCode.NotFound, code, "для отсутствующей записи ожидается код 404");
                Assert.IsNull(conferenceInfo, "для отсутствующей записи ожидается пустой ответ");
            });
        }

        /// <summary>
        ///     При повторной отправке данных, запись должна замениться. Второй записи не должно быть в БД.
        /// </summary>
        [Test]
        public void TestPutTwice() {
            WrapServerContext(delegate
            {
                HttpStatusCode code;

                Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info", null, out code);
                Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info", _gisConf.Info, out code);

                _gisConf.Info.City = "NewCity";
                Helpers.Put<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info", _gisConf.Info, out code);

                var conferences = Helpers.Get<List<Conference>>(Server.Instance.BaseAddress + "conference/info");
                Assert.AreEqual(1, conferences.Count, "должна быть 1 конференция");
                Assert.AreEqual(_gisConf.Info, conferences[0].Info,
                    "Объект должен полностью соответствовать последнему зарегистрированному");
            });
        }

        /// <summary>
        ///     Регистрируем 2 конференции находим 2
        /// </summary>
        [Test]
        public void TestRegisterAndFindAll() {
            WrapServerContext(delegate
            {
                Helpers.Put<Conference>(Server.Instance.BaseAddress + "conference/GIS/info", _gisConf.Info);
                Helpers.Put<Conference>(Server.Instance.BaseAddress + "conference/OIL/info", _oilConf.Info);

                var conferences = Helpers.Get<List<Conference>>(Server.Instance.BaseAddress + "conference/info");
                Assert.AreEqual(2, conferences.Count, "должно быть 2 конференции");
            });
        }

        /// <summary>
        ///     Регистрируем 2 сонференции и находим каждую отдельно по секциям
        /// </summary>
        [Test]
        public void TestRegisterAndFindOne() {
            WrapServerContext(delegate
            {
                Helpers.Put<Conference>(Server.Instance.BaseAddress + "conference/GIS/info", _gisConf.Info);
                Helpers.Put<Conference>(Server.Instance.BaseAddress + "conference/OIL/info", _oilConf.Info);

                var conferenceGis = Helpers.Get<ConferenceInfo>(Server.Instance.BaseAddress + "conference/GIS/info");
                Assert.IsNotNull(conferenceGis, "должна быть гис конференция");
                Assert.AreEqual(_gisConf.Info, conferenceGis,
                    "Объект должен полностью соответствовать зарегистрированному");

                var conferenceOil = Helpers.Get<ConferenceInfo>(Server.Instance.BaseAddress + "conference/OIL/info");
                Assert.IsNotNull(conferenceOil, "должна быть нефтяная конференция");
                Assert.AreEqual(_oilConf.Info, conferenceOil,
                    "Объект должен полностью соответствовать зарегистрированному");
            });
        }
    }
}