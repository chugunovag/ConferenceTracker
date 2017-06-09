using System;
using ConferenceTracker.core;
using Microsoft.Owin.Hosting;
using NUnit.Framework;

namespace ConferenceTracker.test
{
    [TestFixture]
    public class TestApiStress
    {
        private IDisposable _server;

        [SetUp]
        public void Setup()
        {
            _server= WebApp.Start<Startup>(Program.BaseAddress);
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }

        [Test]
        public void Test()
        {
            
        }

        [Test]
        public void Test2()
        {
            
        }
    }
}
