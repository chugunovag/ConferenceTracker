using System;
using System.Collections.Generic;
using System.Net;
using ConferenceTracker.core;
using ConferenceTracker.data;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace ConferenceTracker.test
{
    [TestFixture]
    public class TestApi
    {
        private Conference _gisConf;
        private Conference _oilConf;
        private Conference _csConf;

        [TestFixtureSetUp]
        public void Setup()
        {
            _gisConf = Helpers.CreateTestConference("GIS");
            _oilConf = Helpers.CreateTestConference("OIL");
            _csConf = Helpers.CreateTestConference("CS");
        }

        [Test]
        public void TestMissingConference()
        {
            WrapServerContext(delegate
            {
                HttpStatusCode code;
                var conferenceInfo = RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/GIS/info", out code);
                Assert.AreEqual(HttpStatusCode.NotFound, code, "для отсутствующей записи ожидается код 404");
                Assert.IsNull(conferenceInfo, "для отсутствующей записи ожидается пустой ответ");
            });
        }

        [Test]
        public void TestEmptyConferences()
        {
            WrapServerContext(delegate
            {
                var conferences = RequestHelpers.Get<List<Conference>>(Program.BaseAddress + "conference/info");
                Assert.IsEmpty(conferences, "без регистрации ожидается пустой список");
            });
        }


        [Test]
        public void TestRegisterAndFindOne()
        {
            WrapServerContext(delegate
            {
                RequestHelpers.Put<Conference>(Program.BaseAddress + "conference/GIS/info", _gisConf.Info);
                RequestHelpers.Put<Conference>(Program.BaseAddress + "conference/OIL/info", _oilConf.Info);

                var conferenceGis = RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/GIS/info");
                Assert.IsNotNull(conferenceGis, "должна быть гис конференция");
                Assert.AreEqual(_gisConf.Info, conferenceGis, "Объект должен полностью соответствовать зарегистрированному");

                var conferenceOil = RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/OIL/info");
                Assert.IsNotNull(conferenceOil, "должна быть нефтяная конференция");
                Assert.AreEqual(_oilConf.Info, conferenceOil, "Объект должен полностью соответствовать зарегистрированному");
            });
        }

        [Test]
        public void TestRegisterAndFindAll()
        {
            WrapServerContext(delegate
            {
                RequestHelpers.Put<Conference>(Program.BaseAddress + "conference/GIS/info", _gisConf.Info);
                RequestHelpers.Put<Conference>(Program.BaseAddress + "conference/OIL/info", _oilConf.Info);

                var conferenceGis = RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/GIS/info");
                Assert.IsNotNull(conferenceGis, "должна быть гис конференция");
                Assert.AreEqual(_gisConf.Info, conferenceGis, "Объект должен полностью соответствовать зарегистрированному");

                var conferenceOil = RequestHelpers.Get<ConferenceInfo>(Program.BaseAddress + "conference/OIL/info");
                Assert.IsNotNull(conferenceOil, "должна быть нефтяная конференция");
                Assert.AreEqual(_oilConf.Info, conferenceOil, "Объект должен полностью соответствовать зарегистрированному");

                var conferences = RequestHelpers.Get<List<Conference>>(Program.BaseAddress + "conference/info");
                Assert.AreEqual(2, conferences.Count, "должно быть 2 конференции");
            });
        }

        #region "helpers"

      
        private void WrapServerContext(Action action)
        {
            using (WebApp.Start<Startup>(Program.BaseAddress))
            {
                action.Invoke();
            }
        }


        #endregion

    }

}
